using Equ;
using System;
using System.Numerics;

namespace Dom.Raytrace
{
    public struct Ray : IEquatable<Ray>
    {
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Vector3 PointAt(float t)
        {
            return Origin + t * Direction;
        }

        private static readonly MemberwiseEqualityComparer<Ray> Comparer = MemberwiseEqualityComparer<Ray>.ByProperties;
        public bool Equals(Ray other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
