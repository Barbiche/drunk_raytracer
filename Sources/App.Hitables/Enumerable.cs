using System.Collections.Generic;
using App.Engine;
using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables
{
    public sealed class Enumerable : IEntityHitable
    {
        private readonly IReadOnlyDictionary<EntityId, IHitable> _hitables;

        public Enumerable(IDictionary<EntityId, IHitable> hitables)
        {
            _hitables = (IReadOnlyDictionary<EntityId, IHitable>) hitables;
        }

        public Option<EntityRayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary)
        {
            var hasHit             = false;
            var candidateParameter = topBoundary;
            var candidateHitpoint  = new EntityRayHitpoint();
            foreach (var (id, hitable) in _hitables)
            {
                var contact = hitable.TryHit(ray, bottomBoundary, topBoundary);
                if (contact.HasValue && contact.Value.T < candidateParameter)
                {
                    candidateParameter = contact.Value.T;
                    candidateHitpoint  = new EntityRayHitpoint(id, contact);
                    hasHit             = true;
                }
            }

            return hasHit
                ? new Option<EntityRayHitpoint>(candidateHitpoint)
                : Option<EntityRayHitpoint>.Empty;
        }
    }
}