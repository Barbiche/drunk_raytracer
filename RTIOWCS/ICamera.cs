using System.Numerics;

namespace RTIOWCS
{
    internal interface ICamera
    {
        Vector3 LookFrom { get; set; }
        Vector3 LookAt { get; set; }
        float VerticalFieldOfView { get; set; }
        float Aperture { get; set; }
        float FocusDistance { get; set; }
        float ResX { get; set; }
        float ResY { get; set; }
        Ray GetRay(float s, float t);
    }
}