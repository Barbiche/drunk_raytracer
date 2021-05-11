using Dom.Materials;
using Dom.Raytrace;

namespace App.Materials
{
    public sealed class ScatterableMetal : IScatterable
    {
        private readonly IScatterableComputer _computer;
        private readonly Metal                _metal;

        public ScatterableMetal(Metal metal, IScatterableComputer computer)
        {
            _metal    = metal;
            _computer = computer;
        }

        public RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            return _computer.Scatter(_metal, ray, hitpoint, rayColor);
        }
    }
}