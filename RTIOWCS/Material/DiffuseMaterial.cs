using System;
using System.Numerics;

namespace RTIOWCS.Material
{
    internal class DiffuseMaterial : IMaterial
    {
        public Random RandomGenerator { get; } = new Random();

        public void ComputeColor(TraceRay ray)
        {
            ray.Color = ray.Color * 0.5f;
        }
    }
}