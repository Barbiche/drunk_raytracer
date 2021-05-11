using System;
using System.Numerics;
using App.Shapes;
using Dom.Raytrace;
using Fou.Utils;

namespace App.Hitables.Computers
{
    public sealed class HitableSphereComputer : IHitableSphereComputer
    {
        public Option<RayHitpoint> TryHit(PositionableSphere positionableSphere, Ray ray, RayParameter bottomBoundary,
                                          RayParameter       topBoundary)
        {
            var (positionable, sphere) = positionableSphere;
            var originToCenter = ray.Origin - positionable.Translation;
            var a              = Vector3.Dot(ray.Direction, ray.Direction);
            var b              = 2.0f * Vector3.Dot(originToCenter, ray.Direction);
            var c = Vector3.Dot(originToCenter, originToCenter) -
                    sphere.Radius * sphere.Radius;
            var discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return Option<RayHitpoint>.Empty;
            }

            var temp = new RayParameter((-b - (float) Math.Sqrt(discriminant)) / (2.0f * a));
            if (temp < topBoundary.Value && temp > bottomBoundary.Value)
            {
                var hitPoint = ray.PointAt(temp);
                var normal   = GetNormalAtPoint(hitPoint, positionableSphere);
                return new Option<RayHitpoint>(new RayHitpoint(hitPoint, normal, temp));
            }

            temp = new RayParameter((-b + (float) Math.Sqrt(discriminant)) / (2.0f * a));
            if (temp < topBoundary.Value && temp > bottomBoundary.Value)
            {
                var hitPoint = ray.PointAt(temp);
                var normal   = GetNormalAtPoint(hitPoint, positionableSphere);
                return new Option<RayHitpoint>(new RayHitpoint(hitPoint, normal, temp));
            }

            return Option<RayHitpoint>.Empty;
        }

        private static Vector3 GetNormalAtPoint(Vector3 point, PositionableSphere sphereEntity)
        {
            var (positionable, sphere) = sphereEntity;
            return (point - positionable.Translation) / sphere.Radius;
        }
    }
}