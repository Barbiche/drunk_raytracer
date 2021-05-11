using System;
using System.Numerics;
using Dom.Cameras;

namespace App.Cameras
{
    public class CameraFactory : ICameraFactory
    {
        public IRayTraceCamera CreateCamera(Vector3 lookFrom, Vector3 lookAt,   Vector3 vUp, float verticalFieldOfView,
                                            float   aspect,   float   aperture, float   focusDistance)
        {
            var lensRadius = aperture                              / 2;
            var theta      = verticalFieldOfView * (float) Math.PI / 180.0f;
            var halfHeight = (float) Math.Tan(theta / 2);
            var halfWidth  = aspect * halfHeight;
            var origin     = lookFrom;
            var w          = Vector3.Normalize(lookFrom - lookAt);
            var u          = Vector3.Normalize(Vector3.Cross(vUp, w));
            var v          = Vector3.Cross(w, u);
            var lowerLeftCorner = origin - halfWidth * u * focusDistance - halfHeight * v * focusDistance -
                                  w                  * focusDistance;
            var horizontal = 2 * halfWidth  * focusDistance * u;
            var vertical   = 2 * halfHeight * focusDistance * v;

            var cameraDomain = new Camera(lensRadius, u, v, origin, lowerLeftCorner, horizontal, vertical);
            return new RayTraceCamera(cameraDomain);
        }
    }
}