using System;
using System.Numerics;
using Equ;

namespace App.Shapes
{
    public struct Hitpoint : IEquatable<Hitpoint>
    {
        private static readonly MemberwiseEqualityComparer<Hitpoint> Comparer = MemberwiseEqualityComparer<Hitpoint>.ByProperties;

        public Hitpoint(Vector3 point, Vector3 normal)
        {
            Point = point;
            Normal = normal;
        }

        public Vector3 Point { get; }
        public Vector3 Normal { get; }

        public bool Equals(Hitpoint other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
