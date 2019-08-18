using App.Cameras;
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
                new SphereEntity(new Dom.Shapes.Sphere(1.0f))
            };

            var cameraFactory = new CameraFactory();
            var camera = cameraFactory.CreateDefaultCamera();

            var scene = new Scene(entities, new Vector3(255.0f, 168f, 22f));
            var tracer = new BackgroundTracer(scene, camera, 200, 200);
            var frame = tracer.Trace();

            var ppmWriter = new PPMWriter("C:\\Users\\gueth\\Desktop");
            string filePath = ppmWriter.Write(frame, "raytrace.ppm");

            Console.WriteLine($"Successfully written to {filePath} !");
        }
    }
}
