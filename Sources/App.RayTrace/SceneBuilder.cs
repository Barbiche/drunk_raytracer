using System;
using System.Collections.Generic;
using System.Numerics;
using App.Engine;
using App.Hitables;
using App.Materials;

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
            return new(new Enumerable(_hitables), _positionables, _scatterables, _background);
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