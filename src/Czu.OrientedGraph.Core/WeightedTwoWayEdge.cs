namespace Czu.OrientedGraph.Core
{
    public class WeightedTwoWayEdge : TwoWayEdge, IWeightedEdge
    {
        public static readonly Weight DefaultWeight = new Weight(1);

        public WeightedTwoWayEdge(Vertex source, Vertex destination)
            : this(source, destination, DefaultWeight)
        {
        }

        public WeightedTwoWayEdge(Vertex source, Vertex destination, Weight weight)
            : base(source, destination)
        {
            Weight = weight;
        }

        public Weight Weight { get; }

    }
}