using System.Numerics;

namespace RTIOWCS
{
    internal class TraceRay
    {
        public TraceRay()
        {
        }

        public TraceRay(Ray ray)
        {
            Ray = ray;
        }

        public TraceRay(TraceRay ray)
        {
            Ray = ray.Ray;
            T = ray.T;
            Color = ray.Color;
            Normal = ray.Normal;
            HitPoint = ray.HitPoint;
            tMin = ray.tMin;
            tMax = ray.tMax;
        }

        public Ray Ray { get; set; }
        public float T { get; set; }
        public float tMin { get; set; }
        public float tMax { get; set; }
        public Vector3 Color { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 HitPoint { get; set; }
    }
}