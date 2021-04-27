using System.Drawing;

namespace Pre.PpmVisualizer
{
    public interface IPpmReader
    {
        Bitmap Read(string ppmPath);
    }
}