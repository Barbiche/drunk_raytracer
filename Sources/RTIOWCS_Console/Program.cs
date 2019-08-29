using App.Cameras;
using App.Engine;
using App.RayTrace;
using App.Shapes;
using Inf.PPMWriter;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace RTIOWCS_Console
{
    internal class Program
    {
        private static void Main()
        {
            var task = Task.Run(() => Run());
            task.Wait();
        }

        private static async void Run()
        {
            // Create the scene
            var entities = new HashSet<Entity>()
            {
                new SphereEntity(new Vector3(0.0f, 0.0f, 0.0f), new Dom.Shapes.Sphere(0.5f))
            };

            var cameraFactory = new CameraFactory();
            var camera = cameraFactory.CreateDefaultCamera();

            var scene = new Scene(entities, new Vector3(0.5f, 0.7f, 1.0f));
            var tracer = new BackgroundTracer(scene, camera, 300, 200);
            var frame = tracer.Trace();

            var ppmWriter = new PPMWriter("C:\\Users\\gueth\\Desktop");
            string filePath = ppmWriter.Write(frame, "raytrace.ppm");

            Console.WriteLine($"Successfully written to {filePath} !");
        }
    }
}
