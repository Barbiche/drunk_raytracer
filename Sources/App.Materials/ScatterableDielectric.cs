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

        public TraceRay Scatter(TraceRay ray)
        {
            Vector3 outwardNormal;
            var reflected = Utils.Reflect(ray.Ray.Direction, ray.Normal);
            float niOverNt;
            float cosine;
            float reflectProb;
            if (Vector3.Dot(ray.Ray.Direction, ray.Normal) > 0)
            {
                outwardNormal = -ray.Normal;
                niOverNt = _material.Index;
                cosine = _material.Index * Vector3.Dot(ray.Ray.Direction, ray.Normal) / ray.Ray.Direction.Length();
            }
            else
            {
                outwardNormal = ray.Normal;
                niOverNt = 1.0f / _material.Index;
                cosine = -Vector3.Dot(ray.Ray.Direction, ray.Normal) / ray.Ray.Direction.Length();
            }

            var refracted = Utils.Refract(ray.Ray.Direction, outwardNormal, niOverNt);
            if (refracted != Vector3.Zero)
            {
                reflectProb = Schlick(cosine, _material.Index);
            }
            else
            {
                reflectProb = 1.0f;
            }

            var newRay = Utils.RandomGenerator.NextDouble() < reflectProb ? new Ray(ray.HitPoint, reflected) : new Ray(ray.HitPoint, refracted);
            var newColor = ray.Color * _material.Attenuation;

            return new TraceRay(newRay,
                                ray.T,
                                ray.TMin,
                                ray.TMax,
                                newColor,
                                ray.Normal,
                                ray.HitPoint,
                                ray.Depth);
        }

        private float Schlick(float cosine, float index)
        {
            var r0 = (1 - index) / (1 + index);
            r0 = r0 * r0;
            return r0 + (1 - r0) * (float)Math.Pow(1 - cosine, 5);
        }
    }
}
