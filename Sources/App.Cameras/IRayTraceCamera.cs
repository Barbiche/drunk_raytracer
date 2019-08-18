using Dom.Raytrace;

namespace App.Cameras
{
    public interface IRayTraceCamera
    {
        Ray GetRay(float s, float t);
    }
}