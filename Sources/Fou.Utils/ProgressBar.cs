using System;

namespace Fou.Utils
{
    public class ProgressBar
    {
        private const char   Block = '■';
        private const string Back  = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        private       bool   _firstTime;

        public void Update(int percent)
        {
            if (!_firstTime)
            {
                Console.Write(Back);
                _firstTime = false;
            }

            Console.Write("[");
            var p = (int) (percent / 10f + .5f);
            for (var i = 0; i < 10; ++i)
            {
                Console.Write(i >= p ? ' ' : Block);
            }

            Console.Write("] {0,3:##0}%", percent);
        }

        public void Complete()
        {
            Update(100);
            Console.WriteLine("");
        }
    }
}