using System.Numerics;

namespace App.RayTrace
{
    public interface ISceneAccessor
    {
        Vector3 BackgroundColor { get; }
    }
}