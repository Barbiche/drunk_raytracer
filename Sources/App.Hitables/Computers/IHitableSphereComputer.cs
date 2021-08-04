using App.Positionables;
using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables.Computers
{
    public interface IHitableSphereComputer
    {
        Option<RayHitpoint> TryHit(PositionableSphere positionableSphere,
                                   Ray                ray,
                                   RayParameter       bottomBoundary,
                                   RayParameter       topBoundary);
    }
}