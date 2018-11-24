using System.Numerics;

namespace RTIOWCS
{
    internal interface IEntity
    {
        Vector3 GetColor(Ray ray);
    }
}