namespace App.RayTrace
{
    public interface ISceneBuilder
    {
        Scene         Build();
        ISceneBuilder AddElement(Element element);
    }
}