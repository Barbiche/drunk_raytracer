using System.Numerics;

namespace RTIOWCS.Material
{
    internal interface IMaterial
    {
        Vector3 Albedo { get; set; }
        void Scatter(ref TraceRay ray);
    }
}