using Dom.Raytrace;

namespace App.Shapes
{
    public interface IHitable
    {
        bool TryHit(ref TraceRay traceRay, out Hitpoint hitpoint);
    }
}
