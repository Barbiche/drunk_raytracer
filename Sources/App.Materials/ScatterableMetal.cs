using Dom.Raytrace;
using Fou.Maths;
using Materials;
using System.Numerics;

namespace App.Materials
{
    public class ScatterableMetal : IScatterable
    {
        private readonly Metal _material;

        public ScatterableMetal(Metal material)
        {
            _material = material;
        }

        public RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            var reflected = Maths.Reflect(Vector3.Normalize(ray.Direction), hitpoint.Normal);
            var newRay = new Ray(hitpoint.Point, reflected + Maths.GetRandomInSphere() * _material.Fuzz);
            Color newColor;
            if (Vector3.Dot(newRay.Direction, hitpoint.Normal) > 0)
            {
                newColor = new Color(rayColor.Value * _material.Albedo);
            }
            else
            {
                newColor = new Color(Vector3.Zero);
            }

            return new RayScattered(newRay, newColor);
        }
    }
}
