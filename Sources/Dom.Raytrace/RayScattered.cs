using System;
using Equ;

namespace Dom.Raytrace
{
    public readonly struct RayScattered : IEquatable<RayScattered>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        private static readonly MemberwiseEqualityComparer<RayScattered> Comparer =
            MemberwiseEqualityComparer<RayScattered>.ByProperties;

        public RayScattered(Ray scattered, Color color)
        {
            Scattered = scattered;
            Color     = color;
        }

        public Ray   Scattered { get; }
        public Color Color     { get; }

        public bool Equals(RayScattered other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is RayScattered scattered && Equals(scattered);
        }

        public static bool operator ==(RayScattered left, RayScattered right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RayScattered left, RayScattered right)
        {
            return !(left == right);
        }
    }
}