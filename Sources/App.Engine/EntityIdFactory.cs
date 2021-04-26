namespace App.Engine
{
    public class EntityIdFactory : IEntityIdFactory
    {
        private long _idCount;

        public EntityId Create()
        {
            return new(++_idCount);
        }
    }
}
