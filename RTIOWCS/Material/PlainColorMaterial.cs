using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS.Material
{
    class PlainColorMaterial : IMaterial
    {
        Vector3 Color { get; set; }

        public PlainColorMaterial()
        {
            Color = new Vector3(1.0f, 0.0f, 0.0f);
        }

        public PlainColorMaterial(Vector3 color)
        {
            Color = color;
        }

        Vector3 IMaterial.GetColor(Ray ray)
        {
            return Color;
        }
    }
}
