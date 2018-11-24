using RTIOWCS.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS
{
    class Trace
    {
        private Scene _scene;

        static void Main(string[] args)
        {
            Trace trace = new Trace();
        }

        public Trace()
        {
            _scene = new Scene();
            _scene.AddEntity(new Sphere(new Vector3(0, 0, -1), 0.5f), new PlainColorMaterial(new Vector3(1.0f, 0.0f, 0.0f)));
            _scene.RenderScene();
        }
    }
}
