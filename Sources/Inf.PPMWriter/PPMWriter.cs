using Dom.Raytrace;
using System.IO;

namespace Inf.PPMWriter
{
    public class PPMWriter : IPPMWriter
    {
        public PPMWriter(string outputFolder)
        {
            OutputFolder = outputFolder;
        }

        public string OutputFolder { get; }

        private int ResolutionX { get; set; }
        private int ResolutionY { get; set; }

        public string Write(Frame frame, string filename)
        {
            var filePath = Path.Combine(OutputFolder, filename);

            ResolutionX = frame.ResolutionX;
            ResolutionY = frame.ResolutionY;

            using (var file = new StreamWriter(filePath))
            {
                file.WriteLine(CreateHeader(frame));

                for (int y = 0; y < ResolutionY; y++)
                {
                    for (int x = 0; x < ResolutionX; x++)
                    {
                        file.WriteLine(CreatePixelLine(frame, x, y));
                    }
                }

                file.Close();
            }

            return filePath;
        }

        private string CreateHeader(Frame frame)
        {
            return $"P3\n{frame.ResolutionX} {frame.ResolutionY}\n255";
        }

        private string CreatePixelLine(Frame frame, int x, int y)
        {
            var pixel = frame.Pixels[x, y];
            return $"{pixel.R} {pixel.G} {pixel.B}";
        }
    }
}
