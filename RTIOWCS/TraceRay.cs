using System.Numerics;

namespace RTIOWCS
{
    public class TraceRay
    {
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
            Depth = ray.Depth;
        }

        public Ray Ray { get; set; }
        public float T { get; set; }
        public float tMin { get; set; }
        public float tMax { get; set; }
        public Vector3 Color { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 HitPoint { get; set; }
        public int Depth { get; set; }
    }
}