using System.Numerics;

namespace RTIOWCS
{
    internal interface IShape
    {
        float IsHit(Ray ray);
        Vector3 GetNormalAtPoint(Vector3 point);
        Vector3 BounceOnShape();
    }
}