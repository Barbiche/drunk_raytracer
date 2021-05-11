using Dom.Materials;
using Dom.Raytrace;

namespace App.Materials
{
    public sealed class ScatterableDiffuse : IScatterable
    {
        private readonly IScatterableComputer _computer;
        private readonly Diffuse              _diffuse;

        public ScatterableDiffuse(Diffuse diffuse, IScatterableComputer computer)
        {
            _diffuse  = diffuse;
            _computer = computer;
        }

        public RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor)
        {
            return _computer.Scatter(_diffuse, ray, hitpoint, rayColor);
        }
    }
}