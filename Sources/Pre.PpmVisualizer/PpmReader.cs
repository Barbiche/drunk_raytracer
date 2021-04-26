using System.Drawing;
using System.IO;

namespace Pre.PpmVisualizer
{
    public class PpmReader
    {
        public static Bitmap ReadBitmapFromPPM(string file)
        {
            using var reader   = new StreamReader(File.OpenRead(file));
            var       header   = reader.ReadLine();
            var       sizeLine = reader.ReadLine().Split(" ");
            var       l255     = reader.ReadLine();

            var width  = int.Parse(sizeLine[0]);
            var height = int.Parse(sizeLine[1]);

            var bitmap = new Bitmap(width, height);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var line = reader.ReadLine().Split(" ");
                    bitmap.SetPixel(x, y, Color.FromArgb(int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2])));
                }
            }

            return bitmap;
        }
    }
}