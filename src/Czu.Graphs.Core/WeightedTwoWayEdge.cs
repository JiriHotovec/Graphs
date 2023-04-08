using System;

namespace Czu.Graphs.Core
{
    /// <summary>
    /// Weighted edge (A, B) = (B, A)
    /// </summary>
    public sealed class WeightedTwoWayEdge : TwoWayEdge, IWeightedEdge
    {
        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="source">Vertex source</param>
        /// <param name="destination">Vertex destination</param>
        /// <param name="weight">Edge's weight</param>
        /// <exception cref="ArgumentNullException">Parameter cannot be null</exception>
        public WeightedTwoWayEdge(Vertex source, Vertex destination, Weight weight)
            : base(source, destination)
        {
            Weight = weight ?? throw new ArgumentNullException(nameof(weight));
        }

        /// <summary>
        /// Edge weight
        /// </summary>
        public Weight Weight { get; }

        /// <inheritdoc />
        public override string ToString() => $"({Source}, {Destination}) {Weight}";

        /// <inheritdoc />
        public override IEdge SwitchVertices() =>
            new WeightedTwoWayEdge(Destination, Source, Weight);
    }
}