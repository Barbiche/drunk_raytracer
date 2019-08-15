using System;
using System.Numerics;

namespace RTIOWCS.Shapes
{
    internal class Sphere : IShape
    {
        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        private Vector3 Center { get; }
        private float Radius { get; }

        public bool IsHit(ref TraceRay traceRay)
        {
            var ray = traceRay.Ray;
            var originToCenter = ray.Origin - Center;
            var a = Vector3.Dot(ray.Direction, ray.Direction);
            var b = 2.0f * Vector3.Dot(originToCenter, ray.Direction);
            var c = Vector3.Dot(originToCenter, originToCenter) - Radius * Radius;
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
                return false;

            var temp = (-b - (float) Math.Sqrt(discriminant)) / (2.0f * a);
            if (temp < traceRay.tMax && temp > traceRay.tMin)
            {
                traceRay.T = temp;
                traceRay.HitPoint = ray.PointAt(temp);
                traceRay.Normal = GetNormalAtPoint(traceRay.HitPoint);
                return true;
            }

            temp = (-b + (float) Math.Sqrt(discriminant)) / (2.0f * a);
            if (temp < traceRay.tMax && temp > traceRay.tMin)
            {
                traceRay.T = temp;
                traceRay.HitPoint = ray.PointAt(temp);
                traceRay.Normal = GetNormalAtPoint(traceRay.HitPoint);
                return true;
            }

            return false;
        }

        public Vector3 GetNormalAtPoint(Vector3 point)
        {
            return (point - Center) / Radius;
        }
    }
}