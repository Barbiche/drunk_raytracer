using System;
using System.Numerics;

namespace RTIOWCS
{
    internal class Sphere : IShape
    {
        public Sphere()
        {
            Center = Vector3.Zero;
            Radius = 0.0f;
        }

        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        private Vector3 Center { get; }
        private float Radius { get; }

        public float IsHit(Ray ray)
        {
            var originToCenter = ray.Origin - Center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2.0f * Vector3.Dot(originToCenter, ray.Direction);
            var c = Vector3.Dot(originToCenter, originToCenter) - Radius * Radius;
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
                return -1.0f;
            return (-b - (float) Math.Sqrt(discriminant)) / (2.0f * a);
        }
    }
}