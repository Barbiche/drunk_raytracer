using RTIOWCS.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RTIOWCS
{
    class Scene : IScene
    {
        private long _currentId;

        Dictionary<long, IEntity> _entities;

        private int _nx = 200;
        private int _ny = 100;
        private string _fileName = "Output.ppm";

        private Vector3 _lowerLeftCorner = new Vector3(-2.0f, -1.0f, -1.0f);
        private Vector3 _horizontal = new Vector3(4.0f, 0.0f, 0.0f);
        private Vector3 _vertical = new Vector3(0.0f, 2.0f, 0.0f);
        private Vector3 _origin = new Vector3(0.0f, 0.0f, 0.0f);

        public Vector3 Background { get; set; }

        public Scene()
        {
            Background = new Vector3(0.5f, 0.7f, 1.0f);
            _entities = new Dictionary<long, IEntity>();
            _currentId = 0;
        }

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
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(_fileName))
            {
                file.WriteLine($"P3\n{_nx} {_ny}\n255");
                for (int j = _ny - 1; j >= 0; j--)
                {
                    for (int i = 0; i < _nx; i++)
                    {
                        float u = i / (float)_nx;
                        float v = j / (float)_ny;

                        Ray ray = new Ray(_origin, _lowerLeftCorner + u * _horizontal + v * _vertical);

                        Vector3 col = Vector3.Zero;
                        foreach (Entity entity in _entities.Values)
                        {
                            col += entity.GetColor(ray);
                        }

                        int ir = (int)(255.99 * col.X);
                        int ig = (int)(255.99 * col.Y);
                        int ib = (int)(255.99 * col.Z);

                        file.WriteLine($"{ir} {ig} {ib}");
                    }
                }
            }
        }
    }
}
