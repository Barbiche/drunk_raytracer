using System;
using System.Numerics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using App.Cameras;
using Dom.Raytrace;
using EnsureThat;
using Fou.Utils;

namespace App.RayTrace
{
    public class BackgroundTracer : ITracer
    {
        private readonly ISubject<int> _progressSubject = new Subject<int>();
        private readonly int           _sampling;

        public BackgroundTracer(Scene scene, IRayTraceCamera camera, int resolutionX, int resolutionY,
                                int   sampling)
        {
            EnsureArg.IsNotNull(scene, nameof(scene));
            EnsureArg.IsNotNull(camera, nameof(camera));

            Scene       = scene;
            Camera      = camera;
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
            _sampling   = sampling;
        }

        private Scene           Scene       { get; }
        private IRayTraceCamera Camera      { get; }
        public  int             ResolutionX { get; }
        public  int             ResolutionY { get; }

        public IObservable<int> ProgressStream => _progressSubject.AsObservable();

        public Frame Trace()
        {
            var pixels = new Pixel[ResolutionX, ResolutionY];

            for (var y = 0; y < ResolutionY; y++)
            {
                for (var x = 0; x < ResolutionX; x++)
                {
                    var color = Vector3.Zero;
                    for (var s = 0; s < _sampling; s++)
                    {
                        var u = (x + Maths.Rand()) / ResolutionX;
                        var v = (y + Maths.Rand()) / ResolutionY;

                        var ray = Camera.GetRay(u, v);
                        var resultColor = ThrowRay(ray, new RayParameter(0.001f), new RayParameter(float.MaxValue),
                                                   GetBackgroundContribution(ray), 0);
                        color += resultColor.Value;
                    }

                    color /= _sampling;

                    // y axis is up so we reverse y !
                    pixels[x, ResolutionY - 1 - y] = new Pixel(color);
                }

                _progressSubject.OnNext(y * ResolutionX);
            }

            _progressSubject.OnCompleted();

            return new Frame(pixels);
        }

        private Color ThrowRay(Ray ray, RayParameter minParameter, RayParameter maxParameter, Color color, int depth)
        {
            var hitPoint = Scene.TryHit(ray, minParameter, maxParameter);
            if (hitPoint.HasValue)
            {
                // Scatter
                var rayScattered = Scene.Scatterables[hitPoint.Value.Id]
                    .Scatter(ray, hitPoint.Value.Hitpoint, new Color(color.Value));
                if (++depth > 50) return new Color(new Vector3(0.0f));

                return ThrowRay(rayScattered.Scattered, minParameter, hitPoint.Value.Hitpoint.T, rayScattered.Color,
                                depth);
            }

            return color;
        }

        private Color GetBackgroundContribution(Ray ray)
        {
            var unitDirection = Vector3.Normalize(ray.Direction);
            var t             = 0.5f * (unitDirection.Y + 1.0f);
            return new Color((1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Scene.BackgroundColor);
        }
    }
}