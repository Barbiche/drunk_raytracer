using System.Numerics;
using App.Positionables;
using Dom.Shapes;

namespace App.Hitables.Computers
{
    public sealed class BoundsComputer : IBoundsComputer
    {
        public Bounds Compute(PositionableSphere positionableSphere)
        {
            var (positionable, sphere1) = positionableSphere;
            return new Bounds(positionable.Translation - new Vector3(sphere1.Radius),
                              positionable.Translation + new Vector3(sphere1.Radius));
        }
    }
}