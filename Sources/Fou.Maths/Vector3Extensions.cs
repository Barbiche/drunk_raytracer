using System;
using System.Numerics;
using EnsureThat;

namespace Fou.Maths
{
    public static class Vector3Extensions
    {
        public static float Enumerate(this Vector3 @this, int index)
        {
            EnsureArg.IsInRange(index, 0, 3, nameof(index));

            return index switch
            {
                0 => @this.X,
                1 => @this.Y,
                2 => @this.Z,
                _ => throw new ApplicationException("Should not be reached.")
            };
        }
    }
}