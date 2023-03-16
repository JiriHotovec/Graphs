namespace Czu.OrientedGraph.Core
{
    public interface IWeightedEdge : IEdge
    {
        Weight Weight { get; }
    }
}