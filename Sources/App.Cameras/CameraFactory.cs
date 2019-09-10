using Dom.Camera;
using System;
using System.Numerics;

namespace App.Cameras
{
    public class CameraFactory : ICameraFactory
    {
        public IRayTraceCamera CreateCamera(Vector3 lookFrom, Vector3 lookAt, Vector3 vUp, float verticalFieldOfView, float aperture, int resolutionX, int resolutionY)
        {
            var lensRadius = aperture / 2;
            var theta = verticalFieldOfView * (float)Math.PI / 180.0f;
            var halfHeight = (float)Math.Tan(theta / 2);
            float aspect = resolutionX / (float)resolutionY;
            var halfWidth = aspect * halfHeight;
            var origin = lookFrom;
            var forward = Vector3.Normalize(lookFrom - lookAt);
            var right = Vector3.Normalize(Vector3.Cross(vUp, forward));
            var down = Vector3.Cross(forward, right);
            float focusDistance = (lookFrom - lookAt).Length();
            var lowerLeftCorner = origin - halfWidth * right * focusDistance - halfHeight * down * focusDistance - forward * focusDistance;
            var horizontal = 2 * halfWidth * right * focusDistance;
            var vertical = 2 * halfHeight * down * focusDistance;

            var cameraDomain = new Camera(vertical, horizontal, lowerLeftCorner, origin, right, down, lensRadius);
            return new RayTraceCamera(cameraDomain);

        }

        public IRayTraceCamera CreateDefaultCamera()
        {
            return CreateCamera
                (new Vector3(0, 0, 8),
                 new Vector3(0, 0, 0),
                 new Vector3(0, 1, 0),
                 20,
                 0.1f,
                 1200,
                 800);
        }
    }
}
