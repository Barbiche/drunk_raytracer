using App.Cameras;
using Dom.Raytrace;
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
                    var ray = Camera.GetRay(x, y);
                    var unitDirection = Vector3.Normalize(ray.Direction);
                    var t = 0.5f * (unitDirection.Y + 1.0f);
                    var color = (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Scene.BackgroundColor;
                    frame.AddPixel(new Pixel(color), x, y);
                }
            }

            return frame;
        }
    }
}
