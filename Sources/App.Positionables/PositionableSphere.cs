using System;
using System.Numerics;
using App.Engine;
using Dom.Shapes;
using EnsureThat;
using Equ;

namespace App.Positionables
{
    public readonly struct PositionableSphere : IEquatable<PositionableSphere>, IPositionable
    {
        public IPositionable Positionable { get; }
        public Sphere        Sphere       { get; }

        private static readonly MemberwiseEqualityComparer<PositionableSphere> Comparer =
            MemberwiseEqualityComparer<PositionableSphere>.ByProperties;

        public PositionableSphere(IPositionable positionable, Sphere sphere)
        {
            EnsureArg.IsNotNull(positionable, nameof(positionable));

            Positionable = positionable;
            Sphere       = sphere;
        }

        public bool Equals(PositionableSphere other)
        {
            return Comparer.Equals(other, this);
        }

        public override bool Equals(object obj)
        {
            return obj is PositionableSphere other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public static bool operator ==(PositionableSphere left, PositionableSphere right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PositionableSphere left, PositionableSphere right)
        {
            return !(left == right);
        }

        public void Deconstruct(out IPositionable positionable, out Sphere sphere)
        {
            positionable = Positionable;
            sphere       = Sphere;
        }

        public Vector3 Translation => Positionable.Translation;
    }
}