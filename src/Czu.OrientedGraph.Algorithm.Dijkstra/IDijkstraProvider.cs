using System.Threading;
using System.Threading.Tasks;
using Czu.OrientedGraph.Core;

namespace Czu.OrientedGraph.Algorithm.Dijkstra
{
    /// <summary>
    /// An interface for Dijkstra's provider
    /// </summary>
    public interface IDijkstraProvider
    {
        Task<IPathResult> GetShortestPathAsync(Vertex source, Vertex destination,
            CancellationToken cancellationToken = default);
    }
}