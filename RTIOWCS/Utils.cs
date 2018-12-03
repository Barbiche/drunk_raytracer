using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS
{
    class Utils
    {
        private static readonly Random RandomGenerator = new Random();

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
    }
}
