using Dom.Raytrace;
using Dom.Shapes;
using Fou.Maths;
using Fou.Utils;

namespace App.Hitables.Computers
{
    public sealed class HitableBoundsComputer : IHitableBoundsComputer
    {
        public bool Hit(Bounds       bounds,
                        Ray          ray,
                        RayParameter bottomBoundary,
                        RayParameter topBoundary)
        {
            var tMin = bottomBoundary.Value;
            var tMax = topBoundary.Value;

            for (var i = 0; i < 3; ++i)
            {
                var invRayDir = 1                                                       / ray.Direction.Enumerate(i);
                var t0        = (bounds.Minimum.Enumerate(i) - ray.Origin.Enumerate(i)) * invRayDir;
                var t1        = (bounds.Maximum.Enumerate(i) - ray.Origin.Enumerate(i)) * invRayDir;
                if (invRayDir < 0.0f) Maths.Swap(ref t0, ref t1);

                tMin = t0 > tMin ? t0 : tMin;
                tMax = t1 < tMax ? t1 : tMax;
                if (t0 > t1) return false;
            }

            return true;
        }
    }
}