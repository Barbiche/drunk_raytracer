using Dom.Raytrace;
using System.Collections.Generic;
using System.Numerics;

namespace RTIOWCS
{
    public interface IScene
    {
        Dictionary<long, IEntity> Entities { get; }
        Vector3 ComputeBackground(Ray ray);
        float TMin { get; set; }
        float TMax { get; set; }
    }
}