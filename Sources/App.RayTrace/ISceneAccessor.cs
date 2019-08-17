using System.Collections.Generic;
using System.Numerics;

namespace App.RayTrace
{
    public interface ISceneAccessor
    {
        ISet<Entity> Entities { get; }

        Vector3 BackgroundColor { get; }
    }
}
