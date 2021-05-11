using System.IO;
using Dom.Raytrace;

namespace Inf.PPMWriter
{
    public class PpmWriter : IPpmWriter
    {
        private readonly string _outputFolder;

        public PpmWriter(string outputFolder)
        {
            _outputFolder = outputFolder;
        }

        private int ResolutionX { get; set; }
        private int ResolutionY { get; set; }

        public string Write(Frame frame, string filename)
        {
            var filePath = Path.Combine(_outputFolder, filename);

            ResolutionX = frame.ResolutionX;
            ResolutionY = frame.ResolutionY;

            using var file = new StreamWriter(filePath);
            file.WriteLine(CreateHeader(frame));

            for (var y = 0; y < ResolutionY; y++)
            {
                for (var x = 0; x < ResolutionX; x++)
                {
                    file.WriteLine(CreatePixelLine(frame, x, y));
                }
            }

            file.Close();

            return filePath;
        }

        private static string CreateHeader(Frame frame)
        {
            return $"P3\n{frame.ResolutionX} {frame.ResolutionY}\n255";
        }

        private static string CreatePixelLine(Frame frame, int x, int y)
        {
            var pixel = frame.Pixels[x, y];
            return $"{pixel.R} {pixel.G} {pixel.B}";
        }
    }
}