using System.Numerics;

namespace RTIOWCS
{
    internal interface IEntity
    {
        float Hit(ref TraceRay traceRay);
    }
}