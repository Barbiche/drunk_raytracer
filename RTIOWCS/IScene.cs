using System.Numerics;

namespace RTIOWCS
{
    internal interface IScene
    {
        Vector3 HitScene(TraceRay ray);
        Vector3 Background { get; set; }
        float tMin { get; set; }
        float tMax { get; set; }
    }
}