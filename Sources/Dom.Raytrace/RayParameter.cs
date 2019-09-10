using Equ;
using System;

namespace Dom.Raytrace
{
    public struct RayParameter : IEquatable<RayParameter>
    {
        public float Value { get; }

        public RayParameter(float t)
        {
            Value = t;
        }

        private static readonly MemberwiseEqualityComparer<RayParameter> Comparer = MemberwiseEqualityComparer<RayParameter>.ByProperties;

        public static implicit operator float(RayParameter ray) => ray.Value;
        public static explicit operator RayParameter(float f) => new RayParameter(f);

        public bool Equals(RayParameter other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
