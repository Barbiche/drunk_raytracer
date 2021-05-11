using System;
using System.Numerics;
using Equ;

namespace Dom.Raytrace
{
    public struct Color : IEquatable<Color>
    {
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
    }
}