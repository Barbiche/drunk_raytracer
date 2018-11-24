using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS
{
    class Sphere : IShape
    {
        Vector3 Center { get; set; }
        float Radius { get; set; }

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

        public bool IsHit(Ray ray)
        {
            Vector3 OriginToCenter = ray.Origin - Center;
            float a = Vector3.Dot(ray.Direction, ray.Direction);
            float b = 2.0f * Vector3.Dot(OriginToCenter, ray.Direction);
            float c = Vector3.Dot(OriginToCenter, OriginToCenter) - Radius * Radius;
            float discriminant = b * b - 4 * a * c;
            return (discriminant > 0);
        }
    }
}
