using App.Engine;
using App.Materials;
using App.Shapes;
using System.Collections.Generic;
using System.Numerics;

namespace App.RayTrace
{
    public interface ISceneAccessor
    {
        IReadOnlyDictionary<EntityId, IScatterable> Scatterables { get; }

        IReadOnlyDictionary<EntityId, IHitable> Hitables { get; }

        Vector3 BackgroundColor { get; }
    }
}
