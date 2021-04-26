using Equ;
using System;

namespace Dom.Shapes
{
    public readonly struct Sphere : IEquatable<Sphere>
    {
        public Sphere(float radius)
        {
            Radius = radius;
        }

        private static readonly MemberwiseEqualityComparer<Sphere> Comparer = MemberwiseEqualityComparer<Sphere>.ByProperties;
        public float Radius { get; }

        public bool Equals(Sphere other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
