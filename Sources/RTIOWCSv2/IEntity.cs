using App.Materials;
using App.Shapes;

namespace RTIOWCS
{
    public interface IEntity
    {
        IScatterable Material { get; set; }
        IHitable Shape { get; set; }
    }
}