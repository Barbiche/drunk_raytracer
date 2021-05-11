using Dom.Materials;
using Dom.Raytrace;

namespace App.Materials
{
    public sealed class ScatterableDielectric : IScatterable
    {
        private readonly IScatterableComputer _computer;
        private readonly Dielectric           _dielectric;

        public ScatterableDielectric(Dielectric dielectric, IScatterableComputer computer)
        {
            _dielectric = dielectric;
            _computer   = computer;
        }

        public RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            return _computer.Scatter(_dielectric, ray, hitpoint, rayColor);
        }
    }
}