using System.Numerics;

namespace RTIOWCS
{
    internal class Ray
    {
        public Ray(Vector3 origin, Vector3 direction)
        {
            Origin = origin;
            Direction = direction;
        }

        public Vector3 Origin { get; set; }
        public Vector3 Direction { get; set; }

        public Vector3 PointAt(float t)
        {
            return Origin + t * Direction;
        }
    }
}