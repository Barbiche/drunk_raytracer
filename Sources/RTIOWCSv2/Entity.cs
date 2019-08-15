using App.Materials;
using App.Shapes;

namespace RTIOWCS.Material
{
    internal class Entity : IEntity
    {
        public IScatterable Material { get; set; }
        public IHitable Shape { get; set; }
    }
}