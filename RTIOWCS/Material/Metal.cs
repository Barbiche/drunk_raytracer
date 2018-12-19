using System.Numerics;

namespace RTIOWCS.Material
{
    internal class Metal : IMaterial
    {
        public Metal(Vector3 albedo, float fuzz)
        {
            Albedo = albedo;
            Fuzz = fuzz;
        }

        public Vector3 Albedo { get; set; }

        public float Fuzz { get; set; }

        public void Scatter(ref TraceRay ray)
        {
            var reflected = Utils.Reflect(Vector3.Normalize(ray.Ray.Direction), ray.Normal);
            ray.Ray = new Ray(ray.HitPoint, reflected + Utils.GetRandomInSphere() * Fuzz);
            if (Vector3.Dot(ray.Ray.Direction, ray.Normal) > 0)
                ray.Color *= Albedo;
            else
                ray.Color = Vector3.Zero;
        }
    }
}