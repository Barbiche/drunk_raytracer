using Dom.Raytrace;
using Fou.Maths;
using Materials;

namespace App.Materials
{
    public class ScatterableDiffuse : IScatterable
    {
        private readonly Diffuse _material;

        public ScatterableDiffuse(Diffuse material)
        {
            _material = material;
        }

        public RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            var target = hitpoint.Point + hitpoint.Normal + Maths.GetRandomInSphere();
            var newRay = new Ray(hitpoint.Point, target - hitpoint.Point);
            var newColor = new Color(rayColor.Value * _material.Albedo);
            return new RayScattered(newRay, newColor);
        }
    }
}
