using System;

namespace Czu.OrientedGraph.Core
{
    public sealed class WeightedTwoWayEdge : TwoWayEdge, IWeightedEdge
    {
        public WeightedTwoWayEdge(Vertex source, Vertex destination, Weight weight)
            : base(source, destination)
        {
            Weight = weight ?? throw new ArgumentNullException(nameof(weight));
        }

        public Weight Weight { get; }
    }
}