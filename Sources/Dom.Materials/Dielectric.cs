using Equ;
using System;
using System.Numerics;

namespace Materials
{
    public struct Dielectric : IEquatable<Dielectric>
    {
        public Vector3 Attenuation { get; }
        public float Index { get; }

        public Dielectric(Vector3 attenuation, float index)
        {
            Attenuation = attenuation;
            Index = index;
        }

        private static readonly MemberwiseEqualityComparer<Dielectric> Comparer = MemberwiseEqualityComparer<Dielectric>.ByProperties;

        public bool Equals(Dielectric other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
