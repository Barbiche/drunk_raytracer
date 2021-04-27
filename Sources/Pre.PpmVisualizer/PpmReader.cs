using System;
using System.Drawing;
using System.IO;

namespace Pre.PpmVisualizer
{
    public class PpmReader : IPpmReader
    {
        public Bitmap Read(string ppmPath)
        {
            using var reader = new StreamReader(File.OpenRead(ppmPath));

            // header
            var header = reader.ReadLine();
            if (header == null || header != "P3")
            {
                throw new NotSupportedException($"Provided ppm file {ppmPath} is not ASCII.");
            }

            // size
            int width;
            int height;
            var sizeLine = reader.ReadLine();
            if (sizeLine != null)
            {
                var split = sizeLine.Split(" ");
                width  = int.Parse(split[0]);
                height = int.Parse(split[1]);
            }
            else
            {
                throw new NotSupportedException("Size is not defined");
            }

            // maxSize
            var maxSize = 0;
            var l255    = reader.ReadLine();
            if (l255 != null)
            {
                maxSize = int.Parse(l255);
                if (maxSize != 255)
                {
                    throw new NotSupportedException("Support only 255 max pixel value.");
                }
            }
            else
            {
                throw new NotSupportedException("Max size is not defined");
            }

            var bitmap = new Bitmap(width, height);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var line = reader.ReadLine();
                    if (line == null) continue;
                    var split = line.Split(" ");
                    bitmap.SetPixel(
                        x, y, Color.FromArgb(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])));
                }
            }

            return bitmap;
        }
    }
}