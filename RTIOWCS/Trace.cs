using System.Numerics;
using RTIOWCS.Material;

namespace RTIOWCS
{
    internal class Trace
    {
        public Trace()
        {
            var scene = new Scene();
            scene.AddEntity(new Sphere(new Vector3(0, 0, -1), 0.5f),
                new DiffuseMaterial(new Vector3(0.8f, 0.3f, 0.3f)));
            scene.AddEntity(new Sphere(new Vector3(0.0f, -100.5f, -1.0f), 100.0f),
                new DiffuseMaterial(new Vector3(0.8f, 0.8f, 0.0f)));
            scene.AddEntity(new Sphere(new Vector3(1, 0, -1), 0.5f), new Metal(new Vector3(0.8f, 0.6f, 0.2f), 0.1f));
            scene.AddEntity(new Sphere(new Vector3(-1, 0, -1), 0.5f), new Metal(new Vector3(0.8f, 0.8f, 0.8f), 0.3f));
            /*scene.AddEntity(new Sphere(new Vector3(0, 0, -1), 0.5f),
                new DiffuseMaterial(new Vector3(0.8f, 0.3f, 0.3f)));
            scene.AddEntity(new Sphere(new Vector3(0, 0, -0.5f), 0.25f),
                new DiffuseMaterial(new Vector3(0.3f, 0.8f, 0.3f)));*/
            scene.RenderScene();
        }

        private static void Main(string[] args)
        {
            var trace = new Trace();
        }
    }
}