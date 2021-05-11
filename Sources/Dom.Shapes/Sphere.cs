using System;
using EnsureThat;
using Equ;

namespace Dom.Shapes
{
    public readonly struct Sphere : IEquatable<Sphere>
    {
        public Sphere(float radius)
        {
            EnsureArg.IsGte(radius, 0, nameof(radius));

            Radius = radius;
        }

        private static readonly MemberwiseEqualityComparer<Sphere> Comparer =
            MemberwiseEqualityComparer<Sphere>.ByProperties;

        public float Radius { get; }

        public bool Equals(Sphere other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Sphere sphere && Equals(sphere);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode();
        }

        public static bool operator ==(Sphere left, Sphere right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Sphere left, Sphere right)
        {
            return !(left == right);
        }
    }
}