using System;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public class TwoWayEdge : IEdge, IEquatable<TwoWayEdge>
    {
        public Vertex Source { get; }

        public Vertex Destination { get; }

        public TwoWayEdge(Vertex source, Vertex destination)
        {
            if (source == destination)
            {
                throw new ModelException("Edge must have different vertices set");
            }

            Source = source;
            Destination = destination;
        }

        public override string ToString() => $"({Source}, {Destination})";

        public bool Equals(TwoWayEdge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Source.Equals(other.Source) && Destination.Equals(other.Destination) ||
                   Source.Equals(other.Destination) && Destination.Equals(other.Source);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TwoWayEdge)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Source.GetHashCode() + Destination.GetHashCode();
            }
        }

        public static bool operator ==(TwoWayEdge left, TwoWayEdge right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TwoWayEdge left, TwoWayEdge right)
        {
            return !Equals(left, right);
        }
    }
}