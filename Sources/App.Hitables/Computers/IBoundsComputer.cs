using App.Positionables;
using Dom.Shapes;

namespace App.Hitables.Computers
{
    public interface IBoundsComputer
    {
        /// <summary>
        ///     Computes the <see cref="Bounds"/> of a <see cref="PositionableSphere"/>.
        /// </summary>
        /// <param name="positionableSphere">A sphere.</param>
        /// <returns>Bounds for the provided sphere.</returns>
        Bounds Compute(PositionableSphere positionableSphere);
    }
}