using Equ;
using System;

namespace App.Engine
{
    public struct EntityId : IEquatable<EntityId>
    {
        public EntityId(long id)
        {
            Id = id;
        }

        private static readonly MemberwiseEqualityComparer<EntityId> Comparer = MemberwiseEqualityComparer<EntityId>.ByProperties;

        public long Id { get; }

        public bool Equals(EntityId other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
