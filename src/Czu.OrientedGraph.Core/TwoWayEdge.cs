using System;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    /// <summary>
    /// Edge (A, B) = (B, A)
    /// </summary>
    public class TwoWayEdge : IEdge, IEquatable<TwoWayEdge>
    {
        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="source">Vertex source</param>
        /// <param name="destination">Vertex destination</param>
        /// <exception cref="ModelException">Custom exception for model validation</exception>
        /// <exception cref="ArgumentNullException">Parameter cannot be null</exception>
        public TwoWayEdge(Vertex source, Vertex destination)
        {
            if (source == destination)
            {
                throw new ModelException("Edge must have different vertices set");
            }

            Source = source ?? throw new ArgumentNullException(nameof(source));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
        }

        /// <inheritdoc />
        public Vertex Source { get; }

        /// <inheritdoc />
        public Vertex Destination { get; }

        /// <inheritdoc />
        public virtual IEdge SwitchVertices() =>
            new TwoWayEdge(Destination, Source);

        /// <inheritdoc />
        public bool HasRelation(IEdge other) =>
            Source == other.Source ||
            Source == other.Destination ||
            Destination == other.Source ||
            Destination == other.Destination;

        /// <inheritdoc />
        public override string ToString() => $"({Source}, {Destination})";

        /// <inheritdoc />
        public bool Equals(TwoWayEdge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Source.Equals(other.Source) && Destination.Equals(other.Destination) ||
                   Source.Equals(other.Destination) && Destination.Equals(other.Source);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TwoWayEdge)obj);
        }

        /// <inheritdoc />
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