using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS.Material
{
    class Entity : IEntity
    {
        IShape _shape;
        IMaterial _material;
        IScene _scene;


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
            if (_shape.IsHit(ray))
            {
                return _material.GetColor(ray);
            }

            Vector3 unitDirection = Vector3.Normalize(ray.Direction);
            float t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * _scene.Background;
        }
    }
}
