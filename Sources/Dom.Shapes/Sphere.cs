using Equ;
using System;
using System.Numerics;

namespace Dom.Shapes
{
    public struct Sphere : IEquatable<Sphere>
    {
        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        private static readonly MemberwiseEqualityComparer<Sphere> Comparer = MemberwiseEqualityComparer<Sphere>.ByProperties;

        public Vector3 Center { get; }
        public float Radius { get; }

        public bool Equals(Sphere other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
