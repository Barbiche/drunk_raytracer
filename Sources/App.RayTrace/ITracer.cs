using System;
using Dom.Raytrace;

namespace App.RayTrace
{
    public interface ITracer
    {
        public int              ResolutionX    { get; }
        public int              ResolutionY    { get; }
        public IObservable<int> ProgressStream { get; }
        Frame                   Trace();
    }
}