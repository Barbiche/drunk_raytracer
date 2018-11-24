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

        public bool Hit(TraceRay ray)
        {
            var hitT = _shape.IsHit(ray.Ray);

            if (hitT < _scene.tMax && hitT > _scene.tMin)
            {
                //Hit the shape: hold the values;
                ray.T = hitT;
                ray.HitPoint = ray.Ray.PointAt(hitT);
                ray.Normal = _shape.GetNormalAtPoint(ray.HitPoint);

                // Bounce and create another
                var target = ray.HitPoint + ray.Normal + _shape.BounceOnShape();
                ray.Ray = new Ray(ray.HitPoint, target - ray.HitPoint);
                _material.ComputeColor(ray);
                _scene.HitScene(ray);
                return true;
            }

            return false;
        }
    }
}