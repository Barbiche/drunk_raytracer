using System.Numerics;

namespace RTIOWCS
{
    internal interface IShape
    {
        bool IsHit(ref TraceRay ray);
        Vector3 GetNormalAtPoint(Vector3 point);
    }
}