using App.Engine;
using App.Materials;
using Dom.Shapes;
using System.Numerics;

namespace App.Shapes
{
    public class SphereEntityFactory : ISphereEntityFactory
    {
        private readonly IEntityIdFactory _idFactory;

        public SphereEntityFactory(IEntityIdFactory idFactory)
        {
            this._idFactory = idFactory;
        }

        public SphereEntity Create(Vector3 center, Sphere sphere, IScatterable material)
        {
            return new SphereEntity(_idFactory.Create(), center, sphere, material);
        }

        public SphereEntity Create(Sphere sphere, IScatterable material)
        {
            return new SphereEntity(_idFactory.Create(), sphere, material);
        }
    }
}
