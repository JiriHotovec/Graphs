using System.Threading;
using System.Threading.Tasks;

namespace Czu.OrientedGraph.Core
{
    public interface IDataStorage<T> where T : IEdge
    {
        Task UpsertAsync(SnapshotGraph<T> snapshot, CancellationToken cancellationToken = default);

        Task<SnapshotGraph<T>> GetAsync(string name, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}