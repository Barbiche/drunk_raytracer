using System;
using System.Numerics;
using Dom.Materials;
using Dom.Raytrace;
using Fou.Utils;

namespace App.Materials
{
    public class ScatterableComputer : IScatterableComputer
    {
        public RayScattered Scatter(Dielectric dielectric, Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            Vector3 outwardNormal;
            var     reflected = Maths.Reflect(ray.Direction, hitpoint.Normal);
            float   niOverNt;
            float   cosine;
            if (Vector3.Dot(ray.Direction, hitpoint.Normal) > 0)
            {
                outwardNormal = -hitpoint.Normal;
                niOverNt      = dielectric.Index;
                cosine        = Vector3.Dot(ray.Direction, hitpoint.Normal) / ray.Direction.Length();
                cosine        = (float) Math.Sqrt(1 - dielectric.Index * dielectric.Index * (1 - cosine * cosine));
            }
            else
            {
                outwardNormal = hitpoint.Normal;
                niOverNt      = 1.0f                                         / dielectric.Index;
                cosine        = -Vector3.Dot(ray.Direction, hitpoint.Normal) / ray.Direction.Length();
            }

            var refracted   = Maths.Refract(ray.Direction, outwardNormal, niOverNt);
            var reflectProb = refracted.HasValue ? Schlick(cosine, dielectric.Index) : 1.0f;

            var newRay = Maths.RandomGenerator.NextDouble() < reflectProb
                ? new Ray(hitpoint.Point, reflected)
                : new Ray(hitpoint.Point, refracted);

            return new RayScattered(newRay, rayColor);
        }

        public RayScattered Scatter(Diffuse diffuse, Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            var target   = hitpoint.Point + hitpoint.Normal + Maths.GetRandomInSphere();
            var newRay   = new Ray(hitpoint.Point, target - hitpoint.Point);
            var newColor = new Color(rayColor.Value * diffuse.Albedo);
            return new RayScattered(newRay, newColor);
        }

        public RayScattered Scatter(Metal metal, Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            var   reflected = Maths.Reflect(Vector3.Normalize(ray.Direction), hitpoint.Normal);
            var   newRay    = new Ray(hitpoint.Point, reflected + Maths.GetRandomInSphere() * metal.Fuzz);
            Color newColor;
            newColor = Vector3.Dot(newRay.Direction, hitpoint.Normal) > 0
                ? new Color(rayColor.Value * metal.Albedo)
                : new Color(Vector3.Zero);

            return new RayScattered(newRay, newColor);
        }

        private static float Schlick(float cosine, float index)
        {
            var r0 = (1 - index) / (1 + index);
            r0 *= r0;
            return r0 + (1 - r0) * (float) Math.Pow(1 - cosine, 5);
        }
    }
}