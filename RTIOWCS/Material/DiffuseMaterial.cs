using System.Numerics;

namespace RTIOWCS.Material
{
    internal class DiffuseMaterial : IMaterial
    {
        public DiffuseMaterial(Vector3 albedo)
        {
            Albedo = albedo;
        }

        public Vector3 Albedo { get; set; }

        public void Scatter(ref TraceRay ray)
        {
            var target = ray.HitPoint + ray.Normal + Utils.GetRandomInSphere();
            ray.Ray = new Ray(ray.HitPoint, target - ray.HitPoint);
            ray.Color *= Albedo;
        }
    }
}