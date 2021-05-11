using System;
using System.Numerics;
using Equ;

namespace Dom.Shapes
{
    public readonly struct Bounds : IEquatable<Bounds>
    {
        private static readonly MemberwiseEqualityComparer<Bounds> Comparer =
            MemberwiseEqualityComparer<Bounds>.ByProperties;

        public Vector3 Minimum { get; }
        public Vector3 Maximum { get; }

        public Bounds(Vector3 p1, Vector3 p2)
        {
            Minimum = new Vector3(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Min(p1.Z, p2.Z));
            Maximum = new Vector3(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y), Math.Max(p1.Z, p2.Z));
        }

        public bool Equals(Bounds other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Bounds other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public static bool operator ==(Bounds left, Bounds right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Bounds left, Bounds right)
        {
            return !(left == right);
        }
    }
}