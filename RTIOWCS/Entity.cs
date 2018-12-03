using System.Numerics;

namespace RTIOWCS.Material
{
    internal class Entity : IEntity
    {
        private readonly IMaterial _material;
        private readonly IScene _scene;
        private readonly IShape _shape;


        public Entity(IScene scene)
        {
            _scene = scene;
            _shape = new Sphere();
            _material = new DiffuseMaterial();
        }

        public Entity(IScene scene, IShape shape, IMaterial material)
        {
            _scene = scene;
            _shape = shape;
            _material = material;
        }

        float IEntity.Hit(ref TraceRay traceRay)
        {
            if (_shape.IsHit(traceRay))
            {
                var contactT = traceRay.T;
                _material.Scatter(traceRay);
                traceRay = _scene.HitScene(traceRay);
                return contactT;
            }
            return traceRay.tMax;
        }
    }
}