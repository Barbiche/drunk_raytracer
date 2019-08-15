using App.Materials;
using RTIOWCS.Shapes;

namespace RTIOWCS.Material
{
    internal class Entity : IEntity
    {
        public IScatterable Material { get; set; }
        public IShape Shape { get; set; }
    }
}