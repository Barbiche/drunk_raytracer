using System.Numerics;
using RTIOWCS.Material;
using RTIOWCS.Shapes;

namespace RTIOWCS
{
    public interface IEntity
    {
        IMaterial Material { get; set; }
        IShape Shape { get; set; }
    }
}