using Dom.Raytrace;
using Dom.Shapes;
using System;
using System.Numerics;

namespace App.Shapes
{
    public class SphereEntity : IHitable
    {
        public SphereEntity(Sphere sphere)
        {
            Sphere = sphere;
        }

        public Sphere Sphere { get; }

        public bool TryHit(TraceRay traceRay, out Hitpoint hitpoint)
        {
            hitpoint = new Hitpoint();

            var ray = traceRay.Ray;
            var originToCenter = ray.Origin - Sphere.Center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2.0f * Vector3.Dot(originToCenter, ray.Direction);
            var c = Vector3.Dot(originToCenter, originToCenter) - Sphere.Radius * Sphere.Radius;
            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return false;
            }

            var temp = (-b - (float)Math.Sqrt(discriminant)) / (2.0f * a);
            if (temp < traceRay.TMax && temp > traceRay.TMin)
            {
                var hitPoint = ray.PointAt(temp);
                var normal = GetNormalAtPoint(traceRay.HitPoint);
                hitpoint = new Hitpoint(hitPoint, normal);
                return true;
            }

            temp = (-b + (float)Math.Sqrt(discriminant)) / (2.0f * a);
            if (temp < traceRay.TMax && temp > traceRay.TMin)
            {
                var hitPoint = ray.PointAt(temp);
                var normal = GetNormalAtPoint(traceRay.HitPoint);
                hitpoint = new Hitpoint(hitPoint, normal);
                return true;
            }

            return false;
        }

        public Vector3 GetNormalAtPoint(Vector3 point)
        {
            return (point - Sphere.Center) / Sphere.Radius;
        }
    }
}
