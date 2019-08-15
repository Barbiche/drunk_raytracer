using System.Numerics;

namespace RTIOWCS.Shapes
{
    public interface IShape
    {
        bool IsHit(ref TraceRay ray);
    }
}