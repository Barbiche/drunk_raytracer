using System;
using Equ;

namespace Dom.Materials
{
    public readonly struct Dielectric : IEquatable<Dielectric>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public float Index { get; }

        public Dielectric(float index)
        {
            Index = index;
        }

        private static readonly MemberwiseEqualityComparer<Dielectric> Comparer =
            MemberwiseEqualityComparer<Dielectric>.ByProperties;

        public bool Equals(Dielectric other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Dielectric dielectric && Equals(dielectric);
        }

        public static bool operator ==(Dielectric left, Dielectric right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Dielectric left, Dielectric right)
        {
            return !(left == right);
        }
    }
}