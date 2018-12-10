using System;
using System.Numerics;

namespace RTIOWCS.Material
{
    internal class Dielectric : IMaterial

    {
        private readonly Vector3 _attenuation = new Vector3(1.0f, 1.0f, 1.0f);

        public float Index { get; set; }
        public Vector3 Albedo { get; set; }

        public void Scatter(TraceRay ray)
        {
            Vector3 outwardNormal;
            var reflected = Utils.Reflect(ray.Ray.Direction, ray.Normal);
            float niOverNt;
            float cosine;
            float reflectProb;
            if (Vector3.Dot(ray.Ray.Direction, ray.Normal) > 0)
            {
                outwardNormal = -ray.Normal;
                niOverNt = Index;
                cosine = Index * Vector3.Dot(ray.Ray.Direction, ray.Normal) / ray.Ray.Direction.Length();
            }
            else
            {
                outwardNormal = ray.Normal;
                niOverNt = 1.0f / Index;
                cosine = -Vector3.Dot(ray.Ray.Direction, ray.Normal) / ray.Ray.Direction.Length();
            }

            var refracted = Utils.Refract(ray.Ray.Direction, outwardNormal, niOverNt);
            if (refracted != Vector3.Zero)
            {
                reflectProb = Schlick(cosine);
            }
            else
            {
                ray.Ray = new Ray(ray.HitPoint, reflected);
                reflectProb = 1.0f;
            }

            if (Utils.RandomGenerator.NextDouble() < reflectProb)
                ray.Ray = new Ray(ray.HitPoint, reflected);
            else
                ray.Ray = new Ray(ray.HitPoint, refracted);
            ray.Color *= _attenuation;
        }

        private float Schlick(float cosine)
        {
            var r0 = (1 - Index) / (1 + Index);
            r0 = r0 * r0;
            return r0 + (1 - r0) * (float) Math.Pow(1 - cosine, 5);
        }
    }
}