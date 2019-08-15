using App.Materials;
using RTIOWCS.Shapes;

namespace RTIOWCS
{
    public interface IEntity
    {
        IScatterable Material { get; set; }
        IShape Shape { get; set; }
    }
}