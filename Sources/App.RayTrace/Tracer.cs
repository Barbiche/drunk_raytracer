using App.Cameras;
using Dom.Raytrace;
using Fou.Maths;
using System.Numerics;

namespace App.RayTrace
{
    public class BackgroundTracer : ITracer
    {

        public BackgroundTracer(ISceneAccessor scene, IRayTraceCamera camera, int resolutionX, int resolutionY)
        {
            Scene = scene;
            Camera = camera;
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
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
                    for (var s = 0; s < 50; s++)
                    {
                        var u = (x + Utils.Rand()) / ResolutionX;
                        var v = (y + Utils.Rand()) / ResolutionY;

                        var ray = Camera.GetRay(u, v);
                        var newColor = GetBackgroundContribution(ray);
                        var traceray = new TraceRay(ray, 0, 0.001f, float.MaxValue, newColor, Vector3.Zero, Vector3.Zero, 10);

                        foreach (var hitable in Scene.Hitables)
                        {
                            var result = hitable.Value.TryHit(traceray, out var hitpoint);
                            if (result)
                            {
                                var id = hitable.Key;
                                var resultRay = Scene.Scatterables[id].Scatter(traceray);
                                newColor = resultRay.Color;
                                break;
                            }
                        }
                        color += newColor;
                    }

                    color /= 50;
                    frame.AddPixel(new Pixel(color), x, y);
                }
            }

            return frame;
        }

        private Vector3 GetBackgroundContribution(Ray ray)
        {
            var unitDirection = Vector3.Normalize(ray.Direction);
            var t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Scene.BackgroundColor;
        }
    }
}
