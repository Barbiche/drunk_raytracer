using System.Numerics;

namespace RTIOWCS.Material
{
    internal class PlainColorMaterial : IMaterial
    {
        public PlainColorMaterial()
        {
            Color = new Vector3(1.0f, 0.0f, 0.0f);
        }

        public PlainColorMaterial(Vector3 color)
        {
            Color = color;
        }

        private Vector3 Color { get; }

        Vector3 IMaterial.GetColor(Ray ray)
        {
            return Color;
        }
    }
}