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
                new PlainColorMaterial(new Vector3(1.0f, 0.0f, 0.0f)));
            scene.RenderScene();
        }

        private static void Main(string[] args)
        {
            var trace = new Trace();
        }
    }
}