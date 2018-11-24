using System.Numerics;

namespace RTIOWCS.Material
{
    internal interface IMaterial
    {
        Vector3 GetColor(Ray ray);
    }
}