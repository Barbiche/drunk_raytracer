using System.Numerics;

namespace RTIOWCS.Material
{
    public interface IMaterial
    {
        /// <summary>
        ///     Compute the material contribution for the ray.
        /// </summary>
        /// <param name="ray">Ray which hits the material.</param>
        void Scatter(ref TraceRay ray);
    }
}