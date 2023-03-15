namespace Czu.OrientedGraph.Core
{
    public interface IEdge
    {
        Vertex Source { get; }

        Vertex Destination { get; }
    }
}