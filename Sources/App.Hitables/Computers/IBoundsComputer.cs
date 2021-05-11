using App.Shapes;
using Dom.Shapes;

namespace App.Hitables.Computers
{
    public interface IBoundsComputer
    {
        Bounds Compute(PositionableSphere positionableSphere);
    }
}