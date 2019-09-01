using System.Numerics;

namespace App.Engine
{
    public abstract class Entity : IPositionable
    {
        public EntityId Id { get; }
        public Vector3 Translation { get => _translation; set => _translation = value; }

        protected Vector3 _translation;

        protected Entity(EntityId id)
        {
            Id = id;
        }
    }
}
