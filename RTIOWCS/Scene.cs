using System.Collections.Generic;
using System.IO;
using System.Numerics;
using RTIOWCS.Material;

namespace RTIOWCS
{
    internal class Scene : IScene
    {
        private long _currentId;

        private readonly Dictionary<long, IEntity> _entities;
        private readonly string _fileName = "Output.ppm";
        private readonly Vector3 _horizontal = new Vector3(4.0f, 0.0f, 0.0f);

        private readonly Vector3 _lowerLeftCorner = new Vector3(-2.0f, -1.0f, -1.0f);

        private readonly int _nx = 200;
        private readonly int _ny = 100;
        private readonly Vector3 _origin = new Vector3(0.0f, 0.0f, 0.0f);
        private readonly Vector3 _vertical = new Vector3(0.0f, 2.0f, 0.0f);

        public Scene()
        {
            Background = new Vector3(0.5f, 0.7f, 1.0f);
            _entities = new Dictionary<long, IEntity>();
            _currentId = 0;
        }

        public Vector3 Background { get; set; }

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
                for (var i = 0; i < _nx; i++)
                {
                    var u = i / (float) _nx;
                    var v = j / (float) _ny;

                    var ray = new Ray(_origin, _lowerLeftCorner + u * _horizontal + v * _vertical);

                    var col = Vector3.Zero;
                    foreach (var entity1 in _entities.Values)
                    {
                        var entity = (Entity) entity1;
                        col += entity.GetColor(ray);
                    }

                    var ir = (int) (255.99 * col.X);
                    var ig = (int) (255.99 * col.Y);
                    var ib = (int) (255.99 * col.Z);

                    file.WriteLine($"{ir} {ig} {ib}");
                }
            }
        }
    }
}