using Dom.Raytrace;

namespace App.Shapes
{
    public interface IHitable
    {
        bool TryHit(TraceRay traceRay, out RayHitpoint hitpoint);
    }
}
