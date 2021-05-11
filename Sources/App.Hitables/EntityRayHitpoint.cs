using System;
using App.Engine;
using Dom.Raytrace;
using Equ;

namespace App.Hitables
{
    public readonly struct EntityRayHitpoint : IEquatable<EntityRayHitpoint>
    {
        public EntityRayHitpoint(EntityId id, RayHitpoint hitpoint)
        {
            Id       = id;
            Hitpoint = hitpoint;
        }

        private static readonly MemberwiseEqualityComparer<EntityRayHitpoint> Comparer =
            MemberwiseEqualityComparer<EntityRayHitpoint>.ByProperties;

        public EntityId    Id       { get; }
        public RayHitpoint Hitpoint { get; }

        public bool Equals(EntityRayHitpoint other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is EntityRayHitpoint other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode();
        }

        public static bool operator ==(EntityRayHitpoint left, EntityRayHitpoint right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityRayHitpoint left, EntityRayHitpoint right)
        {
            return !(left == right);
        }

        public void Deconstruct(out EntityId id, out RayHitpoint hitpoint)
        {
            id       = Id;
            hitpoint = Hitpoint;
        }
    }
}