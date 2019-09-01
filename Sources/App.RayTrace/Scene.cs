using App.Engine;
using App.Materials;
using App.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace App.RayTrace
{
    public class Scene : ISceneAccessor
    {
        public Vector3 BackgroundColor { get; }

        public IReadOnlyDictionary<EntityId, IHitable> Hitables => new ReadOnlyDictionary<EntityId, IHitable>(_hitables);

        public IReadOnlyDictionary<EntityId, IScatterable> Scatterables => new ReadOnlyDictionary<EntityId, IScatterable>(_scatterables);

        private readonly IDictionary<EntityId, IHitable> _hitables = new Dictionary<EntityId, IHitable>();
        private readonly IDictionary<EntityId, IScatterable> _scatterables = new Dictionary<EntityId, IScatterable>();

        public Scene(IEnumerable<Entity> entities, Vector3 background)
        {
            foreach (var entity in entities)
            {
                if (entity is IHitable hitable)
                {
                    _hitables.Add(entity.Id, hitable);
                }

                if (entity is IScatterable scatterable)
                {
                    _scatterables.Add(entity.Id, scatterable);
                }
            }
            BackgroundColor = background;
        }
    }
}
