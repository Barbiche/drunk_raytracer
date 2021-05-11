using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables
{
    public interface IEntityHitable
    {
        Option<EntityRayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary);
    }
}