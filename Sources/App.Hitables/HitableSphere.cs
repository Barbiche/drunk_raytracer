using App.Hitables.Computers;
using App.Positionables;
using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables
{
    public sealed class HitableSphere : IHitable
    {
        private readonly IHitableSphereComputer _computer;
        private readonly PositionableSphere     _sphere;

        public HitableSphere(PositionableSphere sphere, IHitableSphereComputer computer)
        {
            _sphere   = sphere;
            _computer = computer;
        }

        public Option<RayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary)
        {
            return _computer.TryHit(_sphere, ray, bottomBoundary, topBoundary);
        }
    }
}