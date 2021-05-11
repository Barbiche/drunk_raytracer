using System;
using Equ;

namespace App.Engine
{
    public readonly struct EntityId : IEquatable<EntityId>
    {
        public EntityId(long id)
        {
            Id = id;
        }

        private static readonly MemberwiseEqualityComparer<EntityId> Comparer =
            MemberwiseEqualityComparer<EntityId>.ByProperties;

        private long Id { get; }

        public bool Equals(EntityId other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is EntityId id && Equals(id);
        }

        public override int GetHashCode()
        {
            return Comparer.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public static bool operator ==(EntityId left, EntityId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityId left, EntityId right)
        {
            return !(left == right);
        }
    }
}