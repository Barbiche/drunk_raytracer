using Dom.Raytrace;
using Fou.Maths;
using Materials;

namespace App.Materials
{
    public class ScatterableDiffuse : IScatterable
    {
        private readonly Diffuse _material;

        public ScatterableDiffuse(Diffuse material)
        {
            _material = material;
        }

        public TraceRay Scatter(TraceRay ray)
        {
            //var target = ray.HitPoint + ray.Normal + Utils.GetRandomInSphere();
            //var newRay = new Ray(ray.HitPoint, target - ray.HitPoint);
            var newColor = ray.Color * _material.Albedo;
            return new TraceRay(ray.Ray,
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
