using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using App.Engine;
using App.Hitables;
using App.Materials;
using Dom.Raytrace;
using EnsureThat;
using Fou.Utils;

namespace App.RayTrace
{
    public sealed class Scene : ISceneAccessor, IEntityHitable
    {
        private readonly IEntityHitable                       _hitableStructure;
        private readonly IDictionary<EntityId, IPositionable> _positionables;
        private readonly IDictionary<EntityId, IScatterable>  _scatterables;

        public Scene(IEntityHitable                       hitableStructure,
                     IDictionary<EntityId, IPositionable> positionables,
                     IDictionary<EntityId, IScatterable>  scatterables,
                     Vector3                              background)
        {
            EnsureArg.IsNotNull(hitableStructure, nameof(hitableStructure));
            EnsureArg.IsNotNull(positionables, nameof(positionables));
            EnsureArg.IsNotNull(scatterables, nameof(scatterables));

            _hitableStructure = hitableStructure;
            _positionables    = positionables;
            _scatterables     = scatterables;
            BackgroundColor   = background;
        }

        public IReadOnlyDictionary<EntityId, IPositionable> Positionables =>
            new ReadOnlyDictionary<EntityId, IPositionable>(_positionables);

        public IReadOnlyDictionary<EntityId, IScatterable> Scatterables =>
            new ReadOnlyDictionary<EntityId, IScatterable>(_scatterables);

        public Option<EntityRayHitpoint> TryHit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary)
        {
            return _hitableStructure.TryHit(ray, bottomBoundary, topBoundary);
        }

        public Vector3 BackgroundColor { get; }
    }
}