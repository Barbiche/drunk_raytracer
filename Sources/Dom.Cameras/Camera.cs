using Equ;
using System;
using System.Numerics;

namespace Dom.Camera
{
    public struct Camera : IEquatable<Camera>
    {
        private static readonly MemberwiseEqualityComparer<Camera> Comparer = MemberwiseEqualityComparer<Camera>.ByProperties;

        public Camera(float lensRadius, Vector3 u, Vector3 v, Vector3 origin, Vector3 lowerLeftCorner, Vector3 horizontal, Vector3 vertical)
        {
            LensRadius = lensRadius;
            U = u;
            V = v;
            Origin = origin;
            LowerLeftCorner = lowerLeftCorner;
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public float LensRadius { get; }
        public Vector3 U { get; }
        public Vector3 V { get; }
        public Vector3 Origin { get; }
        public Vector3 LowerLeftCorner { get; }
        public Vector3 Horizontal { get; }
        public Vector3 Vertical { get; }

        public bool Equals(Camera other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
