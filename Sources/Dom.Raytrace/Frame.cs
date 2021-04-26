using System;
using Equ;

namespace Dom.Raytrace
{
    public readonly struct Frame : IEquatable<Frame>
    {
        public override int GetHashCode()
        {
            return Comparer.GetHashCode(this);
        }

        public Pixel[,] Pixels { get; }

        public Frame(Pixel[,] pixels)
        {
            ResolutionX = pixels.GetLength(0);
            ResolutionY = pixels.GetLength(1);

            Pixels = pixels;
        }


        private static readonly MemberwiseEqualityComparer<Frame> Comparer =
            MemberwiseEqualityComparer<Frame>.ByProperties;

        public int ResolutionX { get; }
        public int ResolutionY { get; }

        public bool Equals(Frame other)
        {
            return Comparer.Equals(this, other);
        }

        public override bool Equals(object obj)
        {
            return obj is Frame frame && Equals(frame);
        }

        public static bool operator ==(Frame left, Frame right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Frame left, Frame right)
        {
            return !(left == right);
        }
    }
}