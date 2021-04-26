using System;
using System.Collections.Generic;
using System.Numerics;
using App.Cameras;
using App.Engine;
using App.Materials;
using App.RayTrace;
using App.Shapes; 
using Dom.Raytrace;
using Dom.Shapes;
using Inf.PPMWriter;
using Materials;

namespace RTIOWCS_Console
{
    internal static class Program
    {
        private const int ResolutionHorizontal = 1600;
        private const int ResolutionVertical   = 900;
        private const int Sampling             = 50;

        private static void Main()
        {
            var frame = GenerateFrame();
            SaveFrame(frame);
        }

        private static void SaveFrame(Frame frame)
        {
            var ppmWriter = new PpmWriter("C:\\Users\\gueth\\Desktop");
            var filePath  = ppmWriter.Write(frame, "raytrace.ppm");

            Console.WriteLine($"Successfully written to {filePath} !");
        }

        private static Frame GenerateFrame()
        {
            var entityIdFactory     = new EntityIdFactory();
            var sphereEntityFactory = new SphereEntityFactory(entityIdFactory);

            // Create the scene
            var entities = new HashSet<Entity>
            {
                sphereEntityFactory.Create(new Vector3(0.725f, 0.5f, 0.725f), new Sphere(0.5f),
                                           new ScatterableDiffuse(new Diffuse(new Vector3(1.0f, 0.0f, 0.0f)))),
                sphereEntityFactory.Create(new Vector3(0.725f, 0.5f, -0.725f), new Sphere(0.5f),
                                           new ScatterableDiffuse(new Diffuse(new Vector3(0.0f, 1.0f, 0.0f)))),
                sphereEntityFactory.Create(new Vector3(-0.725f, 0.5f, 0.725f), new Sphere(0.5f),
                                           new ScatterableDiffuse(new Diffuse(new Vector3(0.0f, 0.0f, 1.0f)))),
                sphereEntityFactory.Create(new Vector3(-0.725f, 0.5f, -0.725f), new Sphere(0.5f),
                                           new ScatterableDiffuse(new Diffuse(new Vector3(1.0f, 1.0f, 0.0f)))),
                sphereEntityFactory.Create(new Vector3(0.0f, 0.5f, 3.0f), new Sphere(0.5f),
                                           new ScatterableDielectric(new Dielectric(1.5f))),
                sphereEntityFactory.Create(new Vector3(3.0f, 0.5f, 0.0f), new Sphere(0.5f),
                                           new ScatterableDielectric(new Dielectric(1.5f))),
                sphereEntityFactory.Create(new Vector3(0.0f, 0.5f, -3.0f), new Sphere(0.5f),
                                           new ScatterableDielectric(new Dielectric(1.5f))),
                sphereEntityFactory.Create(new Vector3(-3.0f, 0.5f, 0.0f), new Sphere(0.5f),
                                           new ScatterableDielectric(new Dielectric(1.5f))),
                sphereEntityFactory.Create(new Vector3(0.0f, 0.5f, 0.0f), new Sphere(0.5f),
                                           new ScatterableMetal(new Metal(new Vector3(0.0f, 1.0f, 1.0f), 0.1f))),
                sphereEntityFactory.Create(new Vector3(0.0f, -200.0f, 0.0f), new Sphere(200f),
                                           new ScatterableDiffuse(new Diffuse(new Vector3(0.5f, 0.5f, 0.5f))))
            };

            var cameraFactory = new CameraFactory();

            var         lookFrom        = new Vector3(0, 8, 10);
            var         lookat          = new Vector3(0, 0, 0);
            var         distanceToFocus = (lookFrom - lookat).Length();
            const float aperture        = 0.1f;
            var camera = cameraFactory.CreateCamera(lookFrom, lookat, new Vector3(0, 1, 0), 20,
                                                    (float) ResolutionHorizontal / ResolutionVertical, aperture,
                                                    distanceToFocus);


            var scene = new Scene(entities, new Vector3(0.2f, 0.0f, 0.43f));
            var tracer =
                new MonitoringTracer(
                    new BackgroundTracer(scene, camera, ResolutionHorizontal, ResolutionVertical, Sampling));

            return tracer.Trace();
        }
    }
}