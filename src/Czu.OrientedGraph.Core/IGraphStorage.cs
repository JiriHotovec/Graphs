using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Czu.OrientedGraph.Core
{
    public interface IGraphStorage<T> where T : IEdge
    {
        Task UpsertAsync(SnapshotGraph<T> snapshot, CancellationToken cancellationToken = default);

        Task<SnapshotGraph<T>> GetAsync(GraphName name, CancellationToken cancellationToken = default);

        Task<IEnumerable<GraphName>> GetAllGraphNamesAsync(CancellationToken cancellationToken = default);

        Task DeleteAsync(GraphName name, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(GraphName name, CancellationToken cancellationToken = default);
    }
}