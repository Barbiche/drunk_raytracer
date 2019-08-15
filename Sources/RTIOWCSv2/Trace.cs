using System.Numerics;
using Fou.Maths;
using Materials;
using RTIOWCS.Material;
using RTIOWCS.Shapes;

namespace RTIOWCS
{
    internal class Trace
    {
        public static void RandomScene()
        {
            var n = 500;
            var scene = new Scene();
            scene.AddEntity(new Sphere(new Vector3(0, -1000, 0), 1000),
                new Diffuse(new Vector3(0.5f, 0.5f, 0.5f)));
            for (var a = -11; a < 11; a++)
                for (var b = -11; b < 11; b++)
                {
                    var chooseMat = Utils.Rand();
                    var center = new Vector3(a + 0.9f * Utils.Rand(), 0.2f, b + 0.9f * Utils.Rand());
                    if ((center - new Vector3(4, 0.2f, 0)).Length() > 0.9f)
                        if (chooseMat < 0.8f)
                            scene.AddEntity(new Sphere(center, 0.2f),
                                new DiffuseMaterial(new Vector3(Utils.Rand() * Utils.Rand(),
                                    Utils.Rand() * Utils.Rand(),
                                    Utils.Rand() * Utils.Rand())));
                        else if (chooseMat < 0.95)
                            scene.AddEntity(new Sphere(center, 0.2f),
                                new Metal(new Vector3(0.5f * (1 + Utils.Rand()),
                                        0.5f * (1 + Utils.Rand()),
                                        0.5f * (1 + Utils.Rand())), 0.5f * Utils.Rand()));
                        else
                            scene.AddEntity(new Sphere(center, 0.2f),
                                new Dielectric { Index = 1.5f });
                }

            scene.AddEntity(new Sphere(new Vector3(0, 1, 0), 1.0f), new Dielectric { Index = 1.5f });
            scene.AddEntity(new Sphere(new Vector3(-4, 1, 0), 1.0f),
                new DiffuseMaterial(new Vector3(0.4f, 0.2f, 0.1f)));
            scene.AddEntity(new Sphere(new Vector3(4, 1, 0), 1.0f), new Metal(new Vector3(0.7f, 0.6f, 0.5f), 0.0f));
            scene.RenderScene();
        }

        /// <summary>
        ///     This is the main of RTIOWCS.
        /// </summary>
        private static void Main()
        {
            var LookFrom = new Vector3(0 , 0, 4);
            var LookAt = new Vector3(0, 0, 0);
            var scene = new Scene
            {
                FileName = "output.ppm",
                FilePath = "C:\\Users\\gueth\\Desktop\\",
                Camera = new Camera
                {
                    LookFrom = LookFrom,
                    LookAt = LookAt,
                    VUp = new Vector3(0, 1, 0),
                    VerticalFieldOfView = 20,
                    Aperture = 0.1f,
                    FocusDistance = (LookFrom-LookAt).Length(),
                    ResX = 400,
                    ResY = 200
                }
            };
            scene.AddEntity(new Sphere(new Vector3(0, 0, -1), 0.5f),
                new DiffuseMaterial(new Vector3(0.1f, 0.2f, 0.5f)));
            scene.AddEntity(new Sphere(new Vector3(0.0f, -100.5f, -1.0f), 100.0f),
                new DiffuseMaterial(new Vector3(0.8f, 0.8f, 0.0f)));
            scene.AddEntity(new Sphere(new Vector3(1, 0, -1), 0.5f), new Metal(new Vector3(0.8f, 0.6f, 0.2f), 0.1f));
            scene.AddEntity(new Sphere(new Vector3(-1, 0, -1), 0.5f), new Dielectric { Index = 1.5f });
            scene.RenderScene();
        }
    }
      
}