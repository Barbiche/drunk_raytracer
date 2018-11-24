using System.Numerics;

namespace RTIOWCS
{
    internal interface IEntity
    {
        bool Hit(TraceRay ray);
    }
}