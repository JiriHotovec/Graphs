using System.Threading;
using System.Threading.Tasks;
using Czu.Graphs.Core;

namespace Czu.Graphs.Algorithm.Dijkstra
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