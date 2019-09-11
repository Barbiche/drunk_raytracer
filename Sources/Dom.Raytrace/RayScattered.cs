using Equ;
using System;

namespace Dom.Raytrace
{
    public struct RayScattered : IEquatable<RayScattered>
    {
        private static readonly MemberwiseEqualityComparer<RayScattered> Comparer = MemberwiseEqualityComparer<RayScattered>.ByProperties;

        public RayScattered(Ray scattered, Color color)
        {
            Scattered = scattered;
            Color = color;
        }

        public Ray Scattered { get; }
        public Color Color { get; }

        public bool Equals(RayScattered other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
