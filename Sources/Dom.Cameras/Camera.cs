using Equ;
using System;
using System.Numerics;

namespace Dom.Camera
{
    public struct Camera : IEquatable<Camera>
    {
        public Camera(Vector3 vertical,
                      Vector3 horizontal,
                      Vector3 lowerLeftCorner,
                      Vector3 origin,
                      Vector3 right,
                      Vector3 down,
                      float lensRadius)
        {
            Vertical = vertical;
            Horizontal = horizontal;
            LowerLeftCorner = lowerLeftCorner;
            Origin = origin;
            Right = right;
            Down = down;
            LensRadius = lensRadius;
        }

        public Vector3 Vertical { get; }
        public Vector3 Horizontal { get; }
        public Vector3 LowerLeftCorner { get; }
        public Vector3 Origin { get; }
        public Vector3 Right { get; }
        public Vector3 Down { get; }
        public float LensRadius { get; }

        private static readonly MemberwiseEqualityComparer<Camera> Comparer = MemberwiseEqualityComparer<Camera>.ByProperties;

        public bool Equals(Camera other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
