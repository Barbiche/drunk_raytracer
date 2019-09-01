namespace App.Engine
{
    public class EntityIdFactory : IEntityIdFactory
    {
        private long _idCount = 0;

        public EntityId Create()
        {
            return new EntityId(++_idCount);
        }
    }
}
