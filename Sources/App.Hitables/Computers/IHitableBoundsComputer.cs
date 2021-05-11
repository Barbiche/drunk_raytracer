using Dom.Raytrace;
using Dom.Shapes;

namespace App.Hitables.Computers
{
    public interface IHitableBoundsComputer
    {
        public bool Hit(Bounds bounds, Ray ray, RayParameter bottomBoundary, RayParameter topBoundary);
    }
}