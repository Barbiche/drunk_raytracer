using System;
using Dom.Raytrace;
using EnsureThat;
using Fou.Utils;

namespace App.RayTrace
{
    public class MonitoringTracer : ITracer
    {
        private readonly int     _totalProgress;
        private readonly ITracer _tracer;

        public MonitoringTracer(ITracer tracer)
        {
            EnsureArg.IsNotNull(tracer, nameof(tracer));

            _tracer        = tracer;
            _totalProgress = tracer.ResolutionY * tracer.ResolutionX;
        }

        public int              ResolutionX    => _tracer.ResolutionX;
        public int              ResolutionY    => _tracer.ResolutionY;
        public IObservable<int> ProgressStream => _tracer.ProgressStream;

        public Frame Trace()
        {
            var progressBar = new ProgressBar();
            ProgressStream.Subscribe(progress => progressBar.Update(progress * 100 / _totalProgress),
                                     () => progressBar.Complete());
            
            var frame = _tracer.Trace();
            
            Console.WriteLine("Frame finished!");
            return frame;
        }
    }
}