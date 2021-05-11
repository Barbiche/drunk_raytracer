using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables
{
    public sealed class BoundingVolumeHierarchy : IHitable
    {
        public Option<RayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary)
        {
            throw new System.NotImplementedException();
        }
    }
}