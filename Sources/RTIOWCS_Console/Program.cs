using App.Cameras;
using App.Engine;
using App.Materials;
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
            var entityIdFactory = new EntityIdFactory();
            var sphereEntityFactory = new SphereEntityFactory(entityIdFactory);

            // Create the scene
            var entities = new HashSet<Entity>()
            {
                sphereEntityFactory.Create(new Vector3(0.0f, -0.5f, 0.5f), new Dom.Shapes.Sphere(0.5f), new ScatterableDiffuse(new Materials.Diffuse(new Vector3(1.0f, 0.7f, 0.0f)))),
                sphereEntityFactory.Create(new Vector3(0.8f, -0.5f, -0.2f), new Dom.Shapes.Sphere(0.5f), new ScatterableDielectric(new Materials.Dielectric(1.5f))),
                sphereEntityFactory.Create(new Vector3(-0.8f, -0.5f, -0.2f), new Dom.Shapes.Sphere(0.5f), new ScatterableMetal(new Materials.Metal(new Vector3(0.0f, 0.6f, 1.0f), 0.1f))),
                sphereEntityFactory.Create(new Vector3(0.0f, 200.0f, 0.0f), new Dom.Shapes.Sphere(200f), new ScatterableDiffuse(new Materials.Diffuse(new Vector3(0.5f, 0.5f, 0.5f))))
            };

            var cameraFactory = new CameraFactory();
            var camera = cameraFactory.CreateDefaultCamera();
            var scene = new Scene(entities, new Vector3(0.2f, 0.0f, 0.43f));
            var tracer = new BackgroundTracer(scene, camera, 1200, 800, 10);
            var frame = tracer.Trace();
            var ppmWriter = new PPMWriter("C:\\Users\\gueth\\Desktop");
            var filePath = ppmWriter.Write(frame, "raytrace.ppm");

            Console.WriteLine($"Successfully written to {filePath} !");
        }
    }
}
