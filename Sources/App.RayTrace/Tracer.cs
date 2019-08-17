using Dom.Raytrace;

namespace App.RayTrace
{
    public class Tracer : ITracer
    {

        public Tracer(ISceneAccessor scene, int resolutionX, int resolutionY)
        {
            Scene = scene;
            ResolutionX = resolutionX;
            ResolutionY = resolutionY;
        }

        public ISceneAccessor Scene { get; }
        public int ResolutionX { get; }
        public int ResolutionY { get; }

        public Frame Trace()
        {
            var frame = new Frame(ResolutionX, ResolutionY);
            for (int y = 0; y < ResolutionY; y++)
            {
                for (int x = 0; x < ResolutionX; x++)
                {
                    frame.AddPixel(new Pixel(Scene.BackgroundColor), x, y);
                }
            }

            return frame;
        }
    }
}
