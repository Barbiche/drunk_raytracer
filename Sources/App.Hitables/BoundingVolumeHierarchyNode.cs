using App.Hitables.Computers;
using Dom.Raytrace;
using Dom.Shapes;
using EnsureThat;
using Fou.Utils;

namespace App.Hitables
{
    public sealed class BoundingVolumeHierarchyNode : IEntityHitable
    {
        private readonly Bounds                 _bounds;
        private readonly IBoundsComputer        _boundsComputer;
        private readonly IHitableBoundsComputer _hitableBoundsComputer;

        public BoundingVolumeHierarchyNode(IEntityHitable         left,
                                           IEntityHitable         right,
                                           IBoundsComputer        boundsComputer,
                                           IHitableBoundsComputer hitableBoundsComputer)
        {
            EnsureArg.IsNotNull(left, nameof(left));
            EnsureArg.IsNotNull(right, nameof(right));
            EnsureArg.IsNotNull(boundsComputer, nameof(boundsComputer));
            EnsureArg.IsNotNull(hitableBoundsComputer, nameof(hitableBoundsComputer));
            
            Left                   = left;
            Right                  = right;
            _boundsComputer        = boundsComputer;
            _hitableBoundsComputer = hitableBoundsComputer;
        }

        public IEntityHitable Left  { get; }
        public IEntityHitable Right { get; }

        public Option<EntityRayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary)
        {
            if (!_hitableBoundsComputer.Hit(_bounds, ray, bottomBoundary, topBoundary))
            {
                return Option<EntityRayHitpoint>.Empty;
            }

            var leftHit  = Left.TryHit(ray, bottomBoundary, topBoundary);
            var rightHit = Right.TryHit(ray, bottomBoundary, topBoundary);
            return leftHit.HasValue switch
            {
                true when rightHit.HasValue => leftHit.Value.Hitpoint.T < rightHit.Value.Hitpoint.T
                    ? leftHit
                    : rightHit,
                true => leftHit,
                _    => rightHit.HasValue ? rightHit : Option<EntityRayHitpoint>.Empty
            };
        }
    }
}