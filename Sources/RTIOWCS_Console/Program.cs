using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using App.Cameras;
using App.Engine;
using App.Hitables.Computers;
using App.Materials;
using App.Positionables;
using App.RayTrace;
using Dom.Materials;
using Dom.Raytrace;
using Dom.Shapes;
using Inf.PPMWriter;

namespace RTIOWCS_Console
{
    internal static class Program
    {
        private const string PpmViewerPath =
            @"C:\Users\gueth\source\repos\RTIOWCS\Sources\Pre.PpmVisualizer\bin\Debug\net5.0-windows\Pre.PpmVisualizer.exe";

        private const string OutputFolder =
            @"C:\Users\gueth\source\repos\RTIOWCS\Sources\Pre.PpmVisualizer\bin\Debug\net5.0-windows\";

        private const string FileName             = "raytrace.ppm";
        private const int    ResolutionHorizontal = 400;
        private const int    ResolutionVertical   = 200;
        private const int    Sampling             = 10;

        private static void Main()
        {
            var frame = GenerateFrame();
            SaveFrame(frame);
            OpenFrame();
        }

        private static void OpenFrame()
        {
            if (File.Exists(PpmViewerPath))
            {
                var info = new ProcessStartInfo
                {
                    WindowStyle      = ProcessWindowStyle.Normal,
                    FileName         = PpmViewerPath,
                    WorkingDirectory = Path.GetDirectoryName(PpmViewerPath)!
                };

                using var proc = Process.Start(info);

                if (proc == null) throw new Exception("Process should not be null at this stage.");

                Console.WriteLine("Viewer launched! Waiting for exit...");
                proc.WaitForExit();
            }
            else
            {
                Console.WriteLine("Can't view the ppm directly, the viewer was not found.");
            }
        }

        private static void SaveFrame(Frame frame)
        {
            var ppmWriter = new PpmWriter(OutputFolder);
            var filePath  = ppmWriter.Write(frame, FileName);

            Console.WriteLine($"Successfully written to {filePath} !");
        }

        private static Frame GenerateFrame()
        {
            var entityIdFactory       = new EntityIdFactory();
            var sceneBuilder          = new SceneBuilder(new Vector3(0.2f, 0.0f, 0.43f));
            var scatterableComputer   = new ScatterableComputer();
            var hitableSphereComputer = new HitableSphereComputer();

            // Create the scene
            var elementBuilderFactory =
                new ElementBuilderFactory(entityIdFactory, hitableSphereComputer, scatterableComputer);

            sceneBuilder.AddElement(elementBuilderFactory.Create()
                                        .WithPosition(new Position(new Vector3(0.725f, 0.5f, 0.725f)))
                                        .WithShape(new Sphere(0.5f))
                                        .WithMaterial(new Diffuse(new Vector3(0.0f, 1.0f, 0.0f))).Build());
            sceneBuilder.AddElement(elementBuilderFactory.Create()
                                        .WithPosition(new Position(new Vector3(0.0f, -200.0f, 0.0f)))
                                        .WithShape(new Sphere(200f))
                                        .WithMaterial(new Diffuse(new Vector3(0.5f, 0.5f, 0.5f))).Build());

            var cameraFactory = new CameraFactory();

            var         lookFrom        = new Vector3(0, 8, 10);
            var         lookat          = new Vector3(0, 0, 0);
            var         distanceToFocus = (lookFrom - lookat).Length();
            const float aperture        = 0.1f;
            var camera = cameraFactory.CreateCamera(lookFrom, lookat, new Vector3(0, 1, 0), 20,
                                                    (float) ResolutionHorizontal / ResolutionVertical, aperture,
                                                    distanceToFocus);


            var scene = sceneBuilder.Build();
            var tracer =
                new MonitoringTracer(
                    new BackgroundTracer(scene, camera, ResolutionHorizontal, ResolutionVertical, Sampling));

            return tracer.Trace();
        }
    }
}