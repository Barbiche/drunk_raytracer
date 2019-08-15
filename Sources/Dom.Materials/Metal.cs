using Equ;
using System;
using System.Numerics;

namespace Materials
{
    public struct Metal : IEquatable<Metal>
    {
        public Vector3 Albedo { get; }

        public float Fuzz { get; }

        public Metal(Vector3 albedo, float fuzz)
        {
            Albedo = albedo;
            Fuzz = fuzz;
        }

        private static readonly MemberwiseEqualityComparer<Metal> Comparer = MemberwiseEqualityComparer<Metal>.ByProperties;

        public bool Equals(Metal other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
