﻿using Dom.Raytrace;
using Fou.Maths;
using Materials;
using System.Numerics;

namespace App.Materials
{
    public class ScatterableMetal : IScatterable
    {
        private readonly Metal _material;

        public ScatterableMetal(Metal material)
        {
            _material = material;
        }

        public TraceRay Scatter(TraceRay ray)
        {
            var reflected = Utils.Reflect(Vector3.Normalize(ray.Ray.Direction), ray.Normal);
            var newRay = new Ray(ray.HitPoint, reflected + Utils.GetRandomInSphere() * _material.Fuzz);
            Vector3 newColor;
            if (Vector3.Dot(ray.Ray.Direction, ray.Normal) > 0)
            {
                newColor = ray.Color * _material.Albedo;
            }
            else
            {
                newColor = Vector3.Zero;
            }

            return new TraceRay(newRay,
                    ray.T,
                    ray.TMin,
                    ray.TMax,
                    newColor,
                    ray.Normal,
                    ray.HitPoint,
                    ray.Depth);
        }
    }
}