using Dom.Raytrace;

namespace Inf.PPMWriter
{
    public interface IPPMWriter
    {
        string Write(Frame frame, string filename);
    }
}
