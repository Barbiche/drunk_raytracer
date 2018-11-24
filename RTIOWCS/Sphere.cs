using System;
using System.Numerics;

namespace RTIOWCS
{
    internal class Sphere : IShape
    {
        private readonly Random RandomGenerator = new Random();

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

        public Vector3 GetNormalAtPoint(Vector3 point)
        {
            return (point - Center) / Radius;
        }

        public Vector3 BounceOnShape()
        {
            Vector3 p;
            do
            {
                p = 2.0f * new Vector3((float) RandomGenerator.NextDouble(), (float) RandomGenerator.NextDouble(),
                        (float) RandomGenerator.NextDouble()) - Vector3.One;
            } while (p.LengthSquared() >= 1.0f);

            return p;
        }
    }
}