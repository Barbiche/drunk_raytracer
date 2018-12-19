using System.Numerics;
using RTIOWCS.Material;

namespace RTIOWCS
{
    internal interface IEntity
    {
        IMaterial Material { get; set; }
        IShape Shape { get; set; }
    }
}