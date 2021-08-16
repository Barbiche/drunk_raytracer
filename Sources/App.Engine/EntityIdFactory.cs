using System;

namespace App.Engine
{
    public sealed class EntityIdFactory : IEntityIdFactory
    {
        public EntityId Create()
        {
            return new EntityId(Guid.NewGuid());
        }
    }
}