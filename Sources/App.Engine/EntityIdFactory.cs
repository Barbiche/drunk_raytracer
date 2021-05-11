namespace App.Engine
{
    public sealed class EntityIdFactory : IEntityIdFactory
    {
        private long _idCount;

        public EntityId Create()
        {
            return new(++_idCount);
        }
    }
}