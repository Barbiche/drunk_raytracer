using Equ;
using System;
using System.Numerics;

namespace Dom.Raytrace
{
    public struct Pixel : IEquatable<Pixel>
    {
        public Pixel(int r, int g, int b)
        {
            R = r < 0 ? 0 : r;
            G = g < 0 ? 0 : g;
            B = b < 0 ? 0 : b;
        }

        public Pixel(Vector3 rgb) : this((int)rgb.X, (int)rgb.Y, (int)rgb.Z) { }

        public int R { get; }

        public int G { get; }

        public int B { get; }

        private static readonly MemberwiseEqualityComparer<Pixel> Comparer = MemberwiseEqualityComparer<Pixel>.ByProperties;
        public bool Equals(Pixel other)
        {
            return Comparer.Equals(this, other);
        }
    }
}
