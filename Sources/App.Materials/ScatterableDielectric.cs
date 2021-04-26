
using Dom.Raytrace;
using Fou.Maths;
using Materials;
using System;
using System.Numerics;

namespace App.Materials
{
    public class ScatterableDielectric : IScatterable
    {
        public ScatterableDielectric(Dielectric dielectric)
        {
            _material = dielectric;
        }

        private readonly Dielectric _material;

        private float Schlick(float cosine, float index)
        {
            var r0 = (1 - index) / (1 + index);
            r0 *= r0;
            return r0 + (1 - r0) * (float)Math.Pow(1 - cosine, 5);
        }

        public RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            Vector3 outwardNormal;
            var reflected = Maths.Reflect(ray.Direction, hitpoint.Normal);
            float niOverNt;
            float cosine;
            float reflectProb;
            if (Vector3.Dot(ray.Direction, hitpoint.Normal) > 0)
            {
                outwardNormal = -hitpoint.Normal;
                niOverNt = _material.Index;
                cosine = Vector3.Dot(ray.Direction, hitpoint.Normal) / ray.Direction.Length();
                cosine = (float)Math.Sqrt(1 - _material.Index * _material.Index * (1 - cosine * cosine));
            }
            else
            {
                outwardNormal = hitpoint.Normal;
                niOverNt = 1.0f / _material.Index;
                cosine = -Vector3.Dot(ray.Direction, hitpoint.Normal) / ray.Direction.Length();
            }

            var refracted = Maths.Refract(ray.Direction, outwardNormal, niOverNt);
            if (refracted.HasValue)
            {
                reflectProb = Schlick(cosine, _material.Index);
            }
            else
            {
                reflectProb = 1.0f;
            }

            Ray newRay = Maths.RandomGenerator.NextDouble() < reflectProb ? new Ray(hitpoint.Point, reflected) : new Ray(hitpoint.Point, refracted);

            return new RayScattered(newRay, rayColor);
        }
    }
}
