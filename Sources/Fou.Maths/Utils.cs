using System;
using System.Numerics;

namespace Fou.Maths
{
    public static class Utils
    {
        public static readonly Random RandomGenerator = new Random();

        /// <summary>
        ///     Compute a reflected direction.
        /// </summary>
        /// <param name="v">Ray direction</param>
        /// <param name="n">Normal</param>
        /// <returns>Reflected direction.</returns>
        public static Vector3 Reflect(Vector3 v, Vector3 n)
        {
            return v - 2 * Vector3.Dot(v, n) * n;
        }

        /// <summary>
        ///     Compute a refracted vector, if possible.
        /// </summary>
        /// <param name="v">Ray direction</param>
        /// <param name="n">Normal</param>
        /// <param name="niOverNt">Index ratio</param>
        /// <returns>Refracted direction, Vector null if not possible</returns>
        public static bool Refract(Vector3 v, Vector3 n, float niOverNt, out Vector3 refracted)
        {
            var uv = Vector3.Normalize(v);
            var dt = Vector3.Dot(uv, n);
            var discriminant = 1.0f - niOverNt * niOverNt * (1 - dt * dt);
            if (discriminant > 0)
            {
                refracted = niOverNt * (uv - n * dt) - n * (float)Math.Sqrt(discriminant);
                return true;
            }

            refracted = new Vector3(0.0f);
            return false;
        }

        public static Vector3 GetRandomInSphere()
        {
            Vector3 p;
            do
            {
                p = 2.0f * new Vector3((float)RandomGenerator.NextDouble(), (float)RandomGenerator.NextDouble(),
                        (float)RandomGenerator.NextDouble()) - Vector3.One;
            } while (p.LengthSquared() >= 1.0f);

            return p;
        }

        public static Vector3 GetRandomInDisk()
        {
            Vector3 p;
            do
            {
                p = 2.0f * new Vector3(Rand(), Rand(), 0) - new Vector3(1, 1, 0);
            } while (Vector3.Dot(p, p) >= 1.0);

            return p;
        }

        public static float Rand()
        {
            return (float)RandomGenerator.NextDouble();
        }
    }
}