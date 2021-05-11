using App.Hitables.Computers;
using Dom.Raytrace;
using Dom.Shapes;

namespace App.Hitables
{
    public sealed class HitableBounds : IBoundsHitable
    {
        private readonly Bounds                 _bounds;
        private readonly IHitableBoundsComputer _computer;

        public HitableBounds(Bounds bounds, IHitableBoundsComputer computer)
        {
            _bounds   = bounds;
            _computer = computer;
        }

        public bool Hit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary)
        {
            return _computer.Hit(_bounds, ray, bottomBoundary, topBoundary);
        }
    }
}