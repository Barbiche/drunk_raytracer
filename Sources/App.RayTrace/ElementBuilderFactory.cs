using App.Engine;
using App.Hitables.Computers;
using App.Materials;

namespace App.RayTrace
{
    public class ElementBuilderFactory
    {
        private readonly EntityIdFactory        _entityIdFactory;
        private readonly IHitableSphereComputer _hitableSphereComputer;
        private readonly IScatterableComputer   _scatterableComputer;


        public ElementBuilderFactory(EntityIdFactory      entityIdFactory, IHitableSphereComputer hitableSphereComputer,
                                     IScatterableComputer scatterableComputer)
        {
            _entityIdFactory       = entityIdFactory;
            _hitableSphereComputer = hitableSphereComputer;
            _scatterableComputer   = scatterableComputer;
        }

        public IElementBuilder Create()
        {
            return new ElementBuilder(_entityIdFactory.Create(), _hitableSphereComputer, _scatterableComputer);
        }
    }
}