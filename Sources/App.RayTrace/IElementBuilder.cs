using System;
using App.Engine;
using App.Hitables;
using App.Hitables.Computers;
using App.Materials;
using App.Shapes;
using Dom.Materials;
using Dom.Shapes;
using Fou.Utils;

namespace App.RayTrace
{
    public interface IElementBuilder
    {
        IElementBuilder WithPosition(Position   position);
        IElementBuilder WithShape(Sphere        sphere);
        IElementBuilder WithMaterial(Dielectric dielectric);
        IElementBuilder WithMaterial(Diffuse    diffuse);
        IElementBuilder WithMaterial(Metal      metal);
        Element         Build();
    }

    public sealed class ElementBuilder : IElementBuilder
    {
        private readonly IHitableSphereComputer _hitableComputer;
        private readonly EntityId               _id;
        private readonly IScatterableComputer   _scatterableComputer;
        private          Option<IPositionable>  _positionable = Option<IPositionable>.Empty;
        private          Option<IScatterable>   _scatterable  = Option<IScatterable>.Empty;
        private          Option<Sphere>         _shape        = Option<Sphere>.Empty;

        public ElementBuilder(EntityId             id, IHitableSphereComputer hitableComputer,
                              IScatterableComputer scatterableComputer)
        {
            _id                  = id;
            _hitableComputer     = hitableComputer;
            _scatterableComputer = scatterableComputer;
        }

        public IElementBuilder WithPosition(Position position)
        {
            _positionable = new Option<IPositionable>(position);
            return this;
        }

        public IElementBuilder WithShape(Sphere sphere)
        {
            _shape = new Option<Sphere>(sphere);
            return this;
        }

        public IElementBuilder WithMaterial(Dielectric dielectric)
        {
            _scatterable = new Option<IScatterable>(new ScatterableDielectric(dielectric, _scatterableComputer));
            return this;
        }

        public IElementBuilder WithMaterial(Diffuse diffuse)
        {
            _scatterable = new Option<IScatterable>(new ScatterableDiffuse(diffuse, _scatterableComputer));
            return this;
        }

        public IElementBuilder WithMaterial(Metal metal)
        {
            _scatterable = new Option<IScatterable>(new ScatterableMetal(metal, _scatterableComputer));
            return this;
        }

        public Element Build()
        {
            if (_shape.HasValue && _positionable.HasValue && _scatterable.HasValue)
            {
                return new Element(
                    _id, new HitableSphere(new PositionableSphere(_positionable.Value, _shape.Value), _hitableComputer),
                    _scatterable.Value, _positionable.Value);
            }

            throw new ApplicationException("One part of the element is not specified.");
        }
    }
}