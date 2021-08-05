using System;
using System.Numerics;
using Equ;

namespace App.Positionables
{
    public readonly struct Position : IEquatable<Position>, IPositionable
    {
        public Position(Vector3 translation)
        {
            Translation = translation;
        }

        private static readonly MemberwiseEqualityComparer<Position> Comparer =
            MemberwiseEqualityComparer<Position>.ByProperties;

        public Vector3 Translation { get; }

        public bool Equals(Position other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Position other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}