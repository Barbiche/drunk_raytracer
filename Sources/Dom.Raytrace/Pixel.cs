using System;
using System.Numerics;
using Equ;

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

        public Pixel(Vector3 rgb)
        {
            rgb = new Vector3((float) Math.Sqrt(rgb.X), (float) Math.Sqrt(rgb.Y), (float) Math.Sqrt(rgb.Z));
            R   = (int) (255.99 * rgb.X);
            G   = (int) (255.99 * rgb.Y);
            B   = (int) (255.99 * rgb.Z);
        }

        public int R { get; }

        public int G { get; }

        public int B { get; }

        private static readonly MemberwiseEqualityComparer<Pixel> Comparer =
            MemberwiseEqualityComparer<Pixel>.ByProperties;

        public bool Equals(Pixel other)
        {
            return Comparer.Equals(this, other);
        }
    }
}