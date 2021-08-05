using System;
using System.Numerics;
using Equ;

namespace Dom.Materials
{
    public readonly struct Diffuse : IEquatable<Diffuse>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public Vector3 Albedo { get; }

        public Diffuse(Vector3 albedo)
        {
            Albedo = albedo;
        }

        private static readonly MemberwiseEqualityComparer<Diffuse> Comparer =
            MemberwiseEqualityComparer<Diffuse>.ByProperties;

        public bool Equals(Diffuse other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Diffuse diffuse && Equals(diffuse);
        }

        public static bool operator ==(Diffuse left, Diffuse right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Diffuse left, Diffuse right)
        {
            return !(left == right);
        }
    }
}