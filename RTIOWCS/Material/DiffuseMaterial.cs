using System;
using System.Numerics;

namespace RTIOWCS.Material
{
    internal class DiffuseMaterial : IMaterial
    {
        public Vector3 Albedo { get; set; }

        public DiffuseMaterial()
        {
            Albedo = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public DiffuseMaterial(Vector3 albedo)
        {
            Albedo = albedo;
        }

        public void Scatter(TraceRay ray)
        {
            Vector3 target = ray.HitPoint + ray.Normal + Utils.GetRandomInSphere();
            ray.Ray = new Ray(ray.HitPoint, target - ray.HitPoint);
            ray.Color *= Albedo;
        }
    }
}