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
            _material = new PlainColorMaterial();
        }

        public Entity(IScene scene, IShape shape, IMaterial material)
        {
            _scene = scene;
            _shape = shape;
            _material = material;
        }

        public Vector3 GetColor(Ray ray)
        {
            var t = _shape.IsHit(ray);
            if (t > 0.0f)
            {
                var normal = Vector3.Normalize(ray.PointAt(t) + Vector3.UnitZ);
                return 0.5f * new Vector3(normal.X + 1, normal.Y + 1, normal.Z + 1);
            }

            var unitDirection = Vector3.Normalize(ray.Direction);
            t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * _scene.Background;
        }
    }
}