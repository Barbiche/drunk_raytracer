using Equ;
using System;
using System.Numerics;

namespace Dom.Raytrace
{
    public struct TraceRay : IEquatable<TraceRay>
    {
        public TraceRay(Ray ray, float T, float tMin, float tMax, Vector3 Color, Vector3 Normal, Vector3 HitPoint, int Depth)
        {
            Ray = ray;
            this.T = T;
            TMin = tMin;
            TMax = tMax;
            this.Color = Color;
            this.Normal = Normal;
            this.HitPoint = HitPoint;
            this.Depth = Depth;
        }


        private static readonly MemberwiseEqualityComparer<TraceRay> Comparer = MemberwiseEqualityComparer<TraceRay>.ByProperties;

        public Ray Ray { get; }
        public float T { get; set; }
        public float TMin { get;  }
        public float TMax { get; set; }
        public Vector3 Color { get; }
        public Vector3 Normal { get; set; }
        public Vector3 HitPoint { get; set; }
        public int Depth { get; set; }

        public bool Equals(TraceRay other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
