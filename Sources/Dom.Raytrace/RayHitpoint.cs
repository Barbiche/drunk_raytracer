using System;
using System.Numerics;
using Equ;

namespace Dom.Raytrace
{
    public struct RayHitpoint : IEquatable<RayHitpoint>
    {
        private static readonly MemberwiseEqualityComparer<RayHitpoint> Comparer =
            MemberwiseEqualityComparer<RayHitpoint>.ByProperties;

        public RayHitpoint(Vector3 point, Vector3 normal, RayParameter t)
        {
            Point  = point;
            Normal = normal;
            T      = t;
        }

        public Vector3      Point  { get; }
        public Vector3      Normal { get; }
        public RayParameter T      { get; }

        public bool Equals(RayHitpoint other)
        {
            return Comparer.Equals(this, other);
        }
    }
}