using Dom.Raytrace;
using System.Threading.Tasks;

namespace App.RayTrace
{
    public interface ITracer
    {
        Frame Trace();
    }
}
