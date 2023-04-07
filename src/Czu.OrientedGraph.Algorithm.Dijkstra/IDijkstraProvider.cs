using System.Threading;
using System.Threading.Tasks;
using Czu.OrientedGraph.Core;

namespace Czu.OrientedGraph.Algorithm.Dijkstra
{
    public interface IDijkstraProvider
    {
        Task<IPathResult> GetShortestPathAsync(Vertex source, Vertex destination,
            CancellationToken cancellationToken = default);
    }
}