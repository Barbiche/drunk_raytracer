using System;
using Equ;

namespace Dom.Raytrace
{
    public readonly struct RayParameter : IEquatable<RayParameter>
    {
        public float Value { get; }

        public RayParameter(float t)
        {
            Value = t;
        }

        private static readonly MemberwiseEqualityComparer<RayParameter> Comparer =
            MemberwiseEqualityComparer<RayParameter>.ByProperties;

        public static implicit operator float(RayParameter ray)
        {
            return ray.Value;
        }

        public static explicit operator RayParameter(float f)
        {
            return new(f);
        }

        public bool Equals(RayParameter other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is RayParameter parameter && Equals(parameter);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public static bool operator ==(RayParameter left, RayParameter right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RayParameter left, RayParameter right)
        {
            return !(left == right);
        }
    }
}