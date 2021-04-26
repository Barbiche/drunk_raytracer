using Equ;
using System;
using System.Numerics;

namespace Dom.Raytrace
{
    public readonly struct Ray : IEquatable<Ray>
    {
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Vector3 PointAt(RayParameter t)
        {
            return Origin + t.Value * Direction;
        }

        private static readonly MemberwiseEqualityComparer<Ray> Comparer = MemberwiseEqualityComparer<Ray>.ByProperties;
        public bool Equals(Ray other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Ray other && Comparer.Equals(this, other);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public static bool operator ==(Ray left, Ray right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Ray left, Ray right)
        {
            return !(left == right);
        }
    }
}
