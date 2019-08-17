using System.Collections.Generic;
using System.Numerics;

namespace App.RayTrace
{
    public class Scene : ISceneAccessor
    {
        public ISet<Entity> Entities { get; }

        public Vector3 BackgroundColor { get; }

        public Scene(IEnumerable<Entity> entities, Vector3 background)
        {
            Entities = new HashSet<Entity>(entities);
            BackgroundColor = background;
        }
    }
}
