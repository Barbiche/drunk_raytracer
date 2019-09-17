using Dom.Camera;
using Dom.Raytrace;
using Fou.Maths;

namespace App.Cameras
{
    public class RayTraceCamera : IRayTraceCamera
    {
        public RayTraceCamera(Camera camera)
        {
            Camera = camera;
        }

        public Camera Camera { get; }

        public Ray GetRay(float s, float t)
        {
            var rd = Camera.LensRadius * Maths.GetRandomInDisk();
            var offset = Camera.U * rd.X + Camera.V * rd.Y;
            return new Ray(Camera.Origin + offset,
                           Camera.LowerLeftCorner + s * Camera.Horizontal + t * Camera.Vertical - Camera.Origin - offset);
        }
    }
}
