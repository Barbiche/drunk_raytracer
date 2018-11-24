using System.Numerics;

namespace RTIOWCS.Material
{
    internal interface IMaterial
    {
        void ComputeColor(TraceRay ray);
    }
}