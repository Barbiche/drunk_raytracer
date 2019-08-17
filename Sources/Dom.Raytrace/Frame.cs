using EnsureThat;
using Equ;
using System;

namespace Dom.Raytrace
{
    public struct Frame : IEquatable<Frame>
    {
        public Pixel[,] Pixels { get; }

        public Frame(int resolutionX, int resolutionY)
        {
            Ensure.That(resolutionX).IsGt(0);
            Ensure.That(resolutionY).IsGt(0);

            ResolutionX = resolutionX;
            ResolutionY = resolutionY;

            Pixels = new Pixel[ResolutionX, ResolutionY];
        }


        private static readonly MemberwiseEqualityComparer<Frame> Comparer = MemberwiseEqualityComparer<Frame>.ByProperties;

        public int ResolutionX { get; }
        public int ResolutionY { get; }

        public bool Equals(Frame other)
        {
            return Comparer.Equals(this, other);
        }

        public void AddPixel(Pixel pixel, int x, int y)
        {
            Ensure.That(x).IsInRange(0, ResolutionX);
            Ensure.That(y).IsInRange(0, ResolutionX);

            Pixels[x, y] = pixel;
        }
    }
}
