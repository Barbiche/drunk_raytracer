using App.Engine;
using App.Shapes;
using System.Collections.Generic;
using System.Numerics;

namespace App.RayTrace
{
    public interface ISceneAccessor
    {
        IEnumerable<Entity> Entities { get; }

        IEnumerable<IHitable> Hitables { get; }

        Vector3 BackgroundColor { get; }
    }
}
