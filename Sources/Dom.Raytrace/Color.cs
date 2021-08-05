using System;
using System.Numerics;
using Equ;

namespace Dom.Raytrace
{
    public readonly struct Color : IEquatable<Color>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public Color(Vector3 color)
        {
            Value = color;
        }

        private static readonly MemberwiseEqualityComparer<Color> Comparer =
            MemberwiseEqualityComparer<Color>.ByProperties;

        public Vector3 Value { get; }

        public bool Equals(Color other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Color color && Equals(color);
        }

        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Color left, Color right)
        {
            return !(left == right);
        }
    }
}