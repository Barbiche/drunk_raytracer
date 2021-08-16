using System;
using App.Engine;
using App.Hitables;
using App.Materials;
using App.Positionables;
using EnsureThat;

namespace App.RayTrace
{
    public sealed class Element : IEquatable<Element>
    {
        public Element(EntityId id, IHitable hitable, IScatterable scatterable, IPositionable positionable)
        {
            EnsureArg.IsNotNull(hitable, nameof(hitable));
            EnsureArg.IsNotNull(scatterable, nameof(scatterable));
            EnsureArg.IsNotNull(positionable, nameof(positionable));

            Id           = id;
            Hitable      = hitable;
            Scatterable  = scatterable;
            Positionable = positionable;
        }

        public EntityId      Id           { get; }
        public IHitable      Hitable      { get; }
        public IScatterable  Scatterable  { get; }
        public IPositionable Positionable { get; }

        public bool Equals(Element other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is Element other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}