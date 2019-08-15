using Dom.Raytrace;

namespace App.Materials
{
    public interface IScatterable
    {
        /// <summary>
        ///     Compute the material contribution for the ray.
        /// </summary>
        /// <param name="ray">Ray which hits the material.</param>
        TraceRay Scatter(TraceRay ray);
    }
}
