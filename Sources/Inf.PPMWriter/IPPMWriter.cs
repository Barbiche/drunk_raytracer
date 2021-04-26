using Dom.Raytrace;

namespace Inf.PPMWriter
{
    public interface IPpmWriter
    {
        string Write(Frame frame, string filename);
    }
}
