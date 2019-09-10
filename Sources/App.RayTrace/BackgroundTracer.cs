using App.Cameras;
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

        public ISceneAccessor Scene { get; }
        public IRayTraceCamera Camera { get; }
        public int ResolutionX { get; }
        public int ResolutionY { get; }

        public Frame Trace()
        {
            var frame = new Frame(ResolutionX, ResolutionY);

            for (int y = 0; y < ResolutionY; y++)
            {
                for (int x = 0; x < ResolutionX; x++)
                {
                    var color = Vector3.Zero;
                    for (var s = 0; s < _sampling; s++)
                    {
                        var u = (x + Maths.Rand()) / ResolutionX;
                        var v = (y + Maths.Rand()) / ResolutionY;

                        var ray = Camera.GetRay(u, v);
                        var newColor = GetBackgroundContribution(ray);
                        var traceray = new TraceRay(ray, new RayParameter(0.001f), new RayParameter(float.MaxValue), newColor, Vector3.Zero, Vector3.Zero, 0);


                        var resultRay = ThrowRay(traceray);
                        color += resultRay.Color;
                    }

                    color /= _sampling;
                    frame.AddPixel(new Pixel(color), x, y);
                }
            }

            return frame;
        }

        private TraceRay ThrowRay(TraceRay traceray)
        {
            foreach (var hitable in Scene.Hitables)
            {
                var contact = hitable.Value.TryHit(traceray.Ray, traceray.TMin, traceray.TMax);
                if (contact.HasValue)
                {
                    if (contact.Value.T < traceray.TMax)
                    {
                        traceray.TMax = contact.Value.T;    
                        traceray.Normal = contact.Value.Normal;
                        traceray.HitPoint = contact.Value.Point;

                        var id = hitable.Key;
                        traceray = Scene.Scatterables[id].Scatter(traceray);

                        traceray.Depth++;

                        if (traceray.Depth > 50)
                        {
                            traceray.Color = new Vector3(0.0f);
                            break;
                        }
                        return ThrowRay(traceray);
                    } 
                }
            }
            return traceray;
        }

        private Vector3 GetBackgroundContribution(Ray ray)
        {
            var unitDirection = Vector3.Normalize(ray.Direction);
            var t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Scene.BackgroundColor;
        }
    }
}
