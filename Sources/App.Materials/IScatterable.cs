using Dom.Raytrace;

namespace App.Materials
{
    public interface IScatterable
    {
        /// <summary>
        ///     Compute the material contribution for the ray.
        /// </summary>
        /// <param name="ray">Ray which hits the material.</param>
        RayScattered Scatter(Ray ray, RayHitpoint hitpoint, Color rayColor);
    }
}
