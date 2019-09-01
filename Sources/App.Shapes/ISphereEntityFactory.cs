using App.Materials;
using Dom.Shapes;
using System.Numerics;

namespace App.Shapes
{
    public interface ISphereEntityFactory
    {
        SphereEntity Create(Vector3 center, Sphere sphere, IScatterable material);
        SphereEntity Create(Sphere sphere, IScatterable material);
    }
}
