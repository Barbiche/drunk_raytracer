using System.Numerics;

namespace RTIOWCS
{
    public class Calculator
    {
        private IScene _scene;

        public Calculator(IScene scene)
        {
            _scene = scene;
        }

        public TraceRay ThrowRayInScene(TraceRay traceRay)
        {
            var defTraceRay = new TraceRay(traceRay);
            var hasHit = false;
            long idEntity = -1;
            var maxT = _scene.TMax;
            foreach (var entity in _scene.Entities)
            {
                var tempRay = new TraceRay(traceRay);
                tempRay.tMax = maxT;
                if (entity.Value.Shape.TryHit(tempRay, out var hitpoint))
                {
                    hasHit = true;
                    maxT = tempRay.T;
                    defTraceRay = new TraceRay(tempRay);
                    idEntity = entity.Key;
                }
            }

            if (hasHit)
            {
                if (defTraceRay.Depth < 50)
                {
                    _scene.Entities[idEntity].Material.Scatter(ref defTraceRay);
                    defTraceRay.Depth++;
                    return ThrowRayInScene(defTraceRay);
                }

                defTraceRay.Color = Vector3.Zero;
            }

            return defTraceRay;
        }
    }
}