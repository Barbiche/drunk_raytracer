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
                new PlainColorMaterial());
            scene.AddEntity(new Sphere(new Vector3(0.0f, -100.5f, -1.0f), 100.0f),
                new PlainColorMaterial(Vector3.UnitY));
            scene.RenderScene();
        }

        private static void Main(string[] args)
        {
            var trace = new Trace();
        }
    }
}