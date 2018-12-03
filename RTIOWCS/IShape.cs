using System.Numerics;

namespace RTIOWCS
{
    internal interface IShape
    {
        bool IsHit(TraceRay ray);
        Vector3 GetNormalAtPoint(Vector3 point);
    }
}