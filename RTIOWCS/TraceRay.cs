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

        public Ray Ray { get; set; }
        public float T { get; set; }
        public Vector3 Color { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 HitPoint { get; set; }
    }
}