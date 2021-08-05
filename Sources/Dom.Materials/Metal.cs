using System;
using System.Numerics;
using Equ;

namespace Dom.Materials
{
    public readonly struct Metal : IEquatable<Metal>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public Vector3 Albedo { get; }

        public float Fuzz { get; }

        public Metal(Vector3 albedo, float fuzz)
        {
            Albedo = albedo;
            Fuzz   = fuzz;
        }

        private static readonly MemberwiseEqualityComparer<Metal> Comparer =
            MemberwiseEqualityComparer<Metal>.ByProperties;

        public bool Equals(Metal other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Metal metal && Equals(metal);
        }

        public static bool operator ==(Metal left, Metal right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Metal left, Metal right)
        {
            return !(left == right);
        }
    }
}