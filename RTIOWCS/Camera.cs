using System;
using System.Numerics;

namespace RTIOWCS
{
    internal class Camera : ICamera
    {
        public Camera()
        {
            Origin = new Vector3(0.0f, 0.0f, 0.0f);
            Vertical = new Vector3(0.0f, 2.0f, 0.0f);
            Horizontal = new Vector3(4.0f, 0.0f, 0.0f);
            LowerLeftCorner = new Vector3(-2.0f, -1.0f, -1.0f);
        }

        public Ray GetRay(float u, float v)
        {
            return new Ray(Origin, LowerLeftCorner + u * Horizontal + v * Vertical - Origin);
        }

        public Vector3 Origin { get; set; }
        public Vector3 LowerLeftCorner { get; set; }
        public Vector3 Horizontal { get; set; }
        public Vector3 Vertical { get; set; }
    }
}