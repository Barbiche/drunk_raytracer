using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables
{
    public interface IHitable
    {
        Option<RayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary);
    }
}