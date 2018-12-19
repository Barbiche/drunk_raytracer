using System.Numerics;

namespace RTIOWCS.Material
{
    internal class Entity : IEntity
    {
        public IMaterial Material { get; set; }
        public IShape Shape { get; set; }
    }
}