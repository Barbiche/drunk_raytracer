using App.Engine;
using App.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace App.RayTrace
{
    public class Scene : ISceneAccessor
    {
        private readonly ISet<Entity> _entities;
        public IEnumerable<Entity> Entities => _entities;

        public Vector3 BackgroundColor { get; }

        public IEnumerable<IHitable> Hitables => Entities.OfType<IHitable>();

        public Scene(IEnumerable<Entity> entities, Vector3 background)
        {
            _entities = new HashSet<Entity>(entities);
            BackgroundColor = background;
        }
    }
}
