using Equ;
using System;
using System.Numerics;

namespace Dom.Raytrace
{
    public class TraceRay : IEquatable<TraceRay>
    {
        public TraceRay(Ray ray, RayParameter tMin, RayParameter tMax, Vector3 color, Vector3 normal, Vector3 hitPoint, int depth)
        {
            Ray = ray;
            TMin = tMin;
            TMax = tMax;
            Color = color;
            Normal = normal;
            HitPoint = hitPoint;
            Depth = depth;
        }

        private TraceRay() { }

        public TraceRay(Ray ray)
        {
            Ray = ray;
        }

        private static readonly MemberwiseEqualityComparer<TraceRay> Comparer = MemberwiseEqualityComparer<TraceRay>.ByProperties;

        public Ray Ray { get; set; }
        public RayParameter TMin { get; set; }
        public RayParameter TMax { get; set; }
        public Vector3 Color { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 HitPoint { get; set; }
        public int Depth { get; set; }

        public bool Equals(TraceRay other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
