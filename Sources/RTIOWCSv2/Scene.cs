﻿using App.Materials;
using App.Shapes;
using Dom.Raytrace;
using Fou.Maths;
using RTIOWCS.Material;
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace RTIOWCS
{
    internal class Scene : IScene
    {
        private readonly int _ns = 100;
        private long _currentId;
        private readonly Calculator _calculator;

        public Scene()
        {
            Background = new Vector3(0.5f, 0.7f, 1.0f);
            Entities = new Dictionary<long, IEntity>();
            _currentId = 0;
            TMin = 0.001f;
            TMax = float.MaxValue;
            _calculator = new Calculator(this);
        }

        public string FileName { get; set; } = "Output.ppm";
        public string FilePath { get; set; } = "";

        public ICamera Camera { get; set; }
        public Vector3 Background { get; set; }
        public float TMin { get; set; }
        public float TMax { get; set; }

        public Dictionary<long, IEntity> Entities { get; }

        public long AddEntity(IHitable shape, IScatterable material)
        {
            Entities.Add(GenerateId(), new Entity { Shape = shape, Material = material });
            return _currentId;
        }

        private long GenerateId()
        {
            return ++_currentId;
        }

        public void RenderScene()
        {
            using (var file =
                new StreamWriter(FilePath + FileName))
            {
                file.WriteLine($"P3\n{Camera.ResX} {Camera.ResY}\n255");
                for (var j = Camera.ResY - 1; j >= 0; j--)
                {
                    for (var i = 0; i < Camera.ResX; i++)
                    {
                        var col = Vector3.Zero;
                        for (var s = 0; s < _ns; s++)
                        {
                            var u = (i + Utils.Rand()) / Camera.ResX;
                            var v = (j + Utils.Rand()) / Camera.ResY;

                            var ray = Camera.GetRay(u, v);
                            var traceRay = new TraceRay(ray)
                            {
                                Color = ComputeBackground(ray),
                                tMax = TMax,
                                tMin = TMin,
                                Depth = 0
                            };
                            var defTraceRay = _calculator.ThrowRayInScene(traceRay);
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

        public Vector3 ComputeBackground(Ray ray)
        {
            var unitDirection = Vector3.Normalize(ray.Direction);
            var t = 0.5f * (unitDirection.Y + 1.0f);
            return (1.0f - t) * new Vector3(1.0f, 1.0f, 1.0f) + t * Background;
        }
    }
}