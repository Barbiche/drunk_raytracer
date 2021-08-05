using System;
using System.Numerics;
using Equ;

namespace Dom.Raytrace
{
    public readonly struct RayHitpoint : IEquatable<RayHitpoint>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

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

        public override bool Equals(object obj)
        {
            return obj is RayHitpoint hitpoint && Equals(hitpoint);
        }

        public static bool operator ==(RayHitpoint left, RayHitpoint right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RayHitpoint left, RayHitpoint right)
        {
            return !(left == right);
        }
    }
}