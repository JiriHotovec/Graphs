namespace Czu.WeightedGraph.Core
{
    public interface IEdge
    {
        Vertex Source { get; }

        Vertex Destination { get; }
    }
}