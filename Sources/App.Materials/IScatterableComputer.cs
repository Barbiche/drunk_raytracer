using Dom.Materials;
using Dom.Raytrace;

namespace App.Materials
{
    public interface IScatterableComputer
    {
        RayScattered Scatter(Dielectric dielectric, Ray ray, RayHitpoint hitpoint, Color rayColor);
        RayScattered Scatter(Diffuse    diffuse,    Ray ray, RayHitpoint hitpoint, Color rayColor);
        RayScattered Scatter(Metal      metal,      Ray ray, RayHitpoint hitpoint, Color rayColor);
    }
}