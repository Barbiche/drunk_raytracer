using App.Cameras;
using App.Engine;
using Dom.Raytrace;
using Fou.Maths;
using System.Numerics;

namespace App.RayTrace
{
    public class BackgroundTracer : ITracer
    {
        private readonly int _sampling;

        public BackgroundTracer(ISceneAccessor scene, IRayTraceCamera camera, int resolutionX, int resolutionY, int sampling)
        {
            Scene = scene;
            Camera = camera;
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
            _sampling = sampling;
        }

        private ISceneAccessor  Scene       { get; }
        private IRayTraceCamera Camera      { get; }
        private int             ResolutionX { get; }
        private int             ResolutionY { get; }

        public Frame Trace()
        {
            var pixels = new Pixel[ResolutionX, ResolutionY];

            for (var y = 0; y < ResolutionY ; y++)
            {
                for (var x = 0; x < ResolutionX; x++)
                {
                    var color = Vector3.Zero;
                    for (var s = 0; s < _sampling; s++)
                    {
                        var u = (x + Maths.Rand()) / ResolutionX;
                        var v = (y + Maths.Rand()) / ResolutionY;

                        var ray = Camera.GetRay(u, v);
                        var resultColor = ThrowRay(ray, new RayParameter(0.001f), new RayParameter(float.MaxValue), GetBackgroundContribution(ray), 0);
                        color += resultColor.Value;
                    }

                    color /= _sampling;
                    
                    // y axis is up so we reverse y !
                    pixels[x, ResolutionY - 1 - y] = new Pixel(color);
                }
            }

            return new Frame(pixels);
        }

        private Color ThrowRay(Ray ray, RayParameter minParameter, RayParameter maxParameter, Color color, int depth)
        {
            var hasHit = false;
            var candidateParameter = maxParameter;
            var candidateHitpoint = new RayHitpoint();
            var candidateId = new EntityId();
            foreach (var hitable in Scene.Hitables)
            {
                var contact = hitable.Value.TryHit(ray, minParameter, maxParameter);
                if (contact.HasValue && contact.Value.T < candidateParameter)
                {
                    candidateParameter = contact.Value.T;
                    candidateHitpoint = contact;
                    candidateId = hitable.Key;
                    hasHit = true;
                }
            }

            if (hasHit)
            {
                // Scatter
                var rayScattered = Scene.Scatterables[candidateId].Scatter(ray, candidateHitpoint, new Color(color.Value));
                if (++depth > 50)
                {
                    return new Color(new Vector3(0.0f));
                }
                return ThrowRay(rayScattered.Scattered, minParameter, candidateParameter, rayScattered.Color, depth);
            }
            return color;
        }

        private Color GetBackgroundContribution(Ray ray)
        {
            var unitDirection = Vector3.Normalize(ray.Direction);
            var t = 0.5f * (unitDirection.Y + 1.0f);
            return new Color((1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Scene.BackgroundColor);
        }
    }
}
