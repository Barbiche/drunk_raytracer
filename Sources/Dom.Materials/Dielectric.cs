using Equ;
using System;

namespace Materials
{
    public struct Dielectric : IEquatable<Dielectric>
    {
        public float Index { get; }

        public Dielectric(float index)
        {
            Index = index;
        }

        private static readonly MemberwiseEqualityComparer<Dielectric> Comparer = MemberwiseEqualityComparer<Dielectric>.ByProperties;

        public bool Equals(Dielectric other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
