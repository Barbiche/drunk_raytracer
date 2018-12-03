using System.Numerics;

namespace RTIOWCS
{
    internal interface IScene
    {
        TraceRay HitScene(TraceRay ray);
        Vector3 Background { get; set; }
        float TMin { get; set; }
        float TMax { get; set; }
    }
}