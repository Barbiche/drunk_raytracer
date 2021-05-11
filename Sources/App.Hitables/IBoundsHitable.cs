using Dom.Raytrace;

namespace App.Hitables
{
    public interface IBoundsHitable
    {
        bool Hit(Ray ray, RayParameter bottomBoundary, RayParameter topBoundary);
    }
}