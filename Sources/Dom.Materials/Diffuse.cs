using System;
using System.Numerics;
using Equ;

namespace Dom.Materials
{
    public struct Diffuse : IEquatable<Diffuse>
    {
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
    }
}