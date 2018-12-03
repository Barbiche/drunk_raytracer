using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using RTIOWCS.Material;

namespace RTIOWCS
{
    internal class Scene : IScene
    {
        private readonly ICamera _camera;
        private readonly Dictionary<long, IEntity> _entities;
        private readonly string _fileName = "Output.ppm";
        private readonly int _ns = 100;
        private readonly int _nx = 200;
        private readonly int _ny = 100;
        private readonly Random _randomGenerator;
        private long _currentId;

        public Scene()
        {
            Background = new Vector3(0.5f, 0.7f, 1.0f);
            _entities = new Dictionary<long, IEntity>();
            _camera = new Camera();
            _currentId = 0;
            _randomGenerator = new Random();
            TMin = 0.001f;
            TMax = float.MaxValue;
        }

        public Vector3 Background { get; set; }
        public float TMin { get; set; }
        public float TMax { get; set; }

        public long AddEntity(IShape shape, IMaterial material)
        {
            _entities.Add(GenerateId(), new Entity(this, shape, material));
            return _currentId;
        }

        private long GenerateId()
        {
            return ++_currentId;
        }

        public void RenderScene()
        {
            using (var file =
                new StreamWriter(_fileName))
            {
                file.WriteLine($"P3\n{_nx} {_ny}\n255");
                for (var j = _ny - 1; j >= 0; j--)
                {
                    for (var i = 0; i < _nx; i++)
                    {
                        var col = Vector3.Zero;
                        for (var s = 0; s < _ns; s++)
                        {
                            var u = (float)(i + _randomGenerator.NextDouble()) / _nx;
                            var v = (float)(j + _randomGenerator.NextDouble()) / _ny;

                            var ray = _camera.GetRay(u, v);
                            TraceRay traceRay = new TraceRay(ray)
                            {
                                Color = ComputeBackground(ray),
                                tMax =  TMax,
                                tMin = TMin
                            };
                            var defTraceRay = HitScene(traceRay);
                            col += defTraceRay.Color;
                        }

                        col /= _ns;
                        col = new Vector3((float)Math.Sqrt(col.X), (float)Math.Sqrt(col.Y), (float)Math.Sqrt(col.Z));
                        var ir = (int)(255.99 * col.X);
                        var ig = (int)(255.99 * col.Y);
                        var ib = (int)(255.99 * col.Z);

                        file.WriteLine($"{ir} {ig} {ib}");
                    }
                }
            }
        }

        public TraceRay HitScene(TraceRay traceRay)
        {
            var maxT = TMax;
            var defTraceRay = new TraceRay(traceRay);
            foreach (var entity in _entities.Values)
            {
                var tempRay = new TraceRay(traceRay);
                var tempT = entity.Hit(ref tempRay);
                if (tempT < maxT)
                {
                    defTraceRay = tempRay;
                    maxT = tempT;
                }
            }
           return defTraceRay;
        }

        private Vector3 ComputeBackground(Ray ray)
        {
            var unitDirection = Vector3.Normalize(ray.Direction);
            var t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Background;
        }
    }
}