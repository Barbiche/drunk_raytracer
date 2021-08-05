using System;
using System.Numerics;
using Equ;

namespace Dom.Raytrace
{
    public readonly struct Pixel : IEquatable<Pixel>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

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

        public override bool Equals(object obj)
        {
            return obj is Pixel pixel && Equals(pixel);
        }

        public static bool operator ==(Pixel left, Pixel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Pixel left, Pixel right)
        {
            return !(left == right);
        }
    }
}