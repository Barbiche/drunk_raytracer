using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using App.Engine;
using App.Hitables;
using App.Hitables.Computers;
using App.Materials;
using App.Positionables;
using Enumerable = App.Hitables.Enumerable;

namespace App.RayTrace
{
    public class SceneBuilder : ISceneBuilder
    {
        private readonly Vector3                             _background;
        private readonly Dictionary<EntityId, IHitable>      _hitables;
        private readonly Dictionary<EntityId, IPositionable> _positionables;
        private readonly Dictionary<EntityId, IScatterable>  _scatterables;

        public SceneBuilder(Vector3 background)
        {
            _background    = background;
            _hitables      = new Dictionary<EntityId, IHitable>();
            _scatterables  = new Dictionary<EntityId, IScatterable>();
            _positionables = new Dictionary<EntityId, IPositionable>();
        }

        public Scene Build()
        {
            // split along X
            var elementsByX = _hitables.OrderBy(pair => _positionables[pair.Key].Translation.X)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            var left  = new Dictionary<EntityId, IHitable>(elementsByX.Take(elementsByX.Count / 2));
            var right = new Dictionary<EntityId, IHitable>(elementsByX.Skip(elementsByX.Count / 2));

            return new Scene(new BoundingVolumeHierarchyNode(new Enumerable(left), new Enumerable(right),
                                                             new BoundsComputer(),
                                                             new HitableBoundsComputer()),
                             _positionables, _scatterables, _background);
        }

        public ISceneBuilder AddElement(Element element)
        {
            _positionables.Add(element.Id, element.Positionable);
            _hitables.Add(element.Id, element.Hitable);
            _scatterables.Add(element.Id, element.Scatterable);
            return this;
        }
    }
}