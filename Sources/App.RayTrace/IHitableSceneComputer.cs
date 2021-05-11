using Dom.Raytrace;
using Fou.Utils;

namespace App.RayTrace
{
    public interface IHitableSceneComputer
    {
        Option<RayHitpoint> TryHit(ISceneAccessor scene,
                                   Ray            ray,
                                   RayParameter   bottomBoundary,
                                   RayParameter   topBoundary);
    }
}