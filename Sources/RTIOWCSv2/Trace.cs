using App.Materials;
using App.Shapes;
using Dom.Shapes;
using Materials;
using System.Numerics;

namespace RTIOWCS
{
    internal class Trace
    {

        /// <summary>
        ///     This is the main of RTIOWCS.
        /// </summary>
        private static void Main()
        {
            var LookFrom = new Vector3(0, 0, 4);
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
                    FocusDistance = (LookFrom - LookAt).Length(),
                    ResX = 400,
                    ResY = 200
                }
            };
            scene.AddEntity(new SphereEntity(new Sphere(new Vector3(0, 0, -1), 0.5f)),
                new ScatterableDiffuse(new Diffuse(new Vector3(0.1f, 0.2f, 0.5f))));
            scene.AddEntity(new SphereEntity(new Sphere(new Vector3(0.0f, -100.5f, -1.0f), 100.0f)),
                new ScatterableDiffuse(new Diffuse(new Vector3(0.8f, 0.8f, 0.0f))));
            scene.AddEntity(new SphereEntity(new Sphere(new Vector3(1, 0, -1), 0.5f)), new ScatterableMetal(new Metal(new Vector3(0.8f, 0.6f, 0.2f), 0.1f)));
            scene.AddEntity(new SphereEntity(new Sphere(new Vector3(-1, 0, -1), 0.5f)), new ScatterableDielectric(new Dielectric(new Vector3(1.0f, 1.0f, 1.0f), 1.5f)));
            scene.RenderScene();
        }
    }

}