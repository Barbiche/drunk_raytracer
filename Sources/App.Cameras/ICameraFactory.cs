using System.Numerics;

namespace App.Cameras
{
    public interface ICameraFactory
    {
        IRayTraceCamera CreateCamera(Vector3 lookFrom, Vector3 lookAt,   Vector3 vUp, float verticalFieldOfView,
                                     float   aspect,   float   aperture, float   focusDistance);
    }
}