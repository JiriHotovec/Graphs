using System.Collections.Generic;

namespace Czu.OrientedGraph.Core
{
    public sealed class Graph<T> where T : IEdge
    {
        private readonly HashSet<T> _edges = new HashSet<T>();

        public void UpsertEdge(T edge)
        {
            TryDeleteEdge(edge);

            _edges.Add(edge);
        }

        public void TryDeleteEdge(T edge)
        {
            if (_edges.Contains(edge))
            {
                _edges.Remove(edge);
            }
        }

        public SnapshotGraph<T> ToSnapshot() =>
            new SnapshotGraph<T>(_edges);

        public static Graph<T> FromSnapshot(SnapshotGraph<T> snapshot)
        {
            var graph = new Graph<T>();
            foreach (var edge in snapshot.Edges)
            {
                graph.UpsertEdge(edge);
            }

            return graph;
        }
    }
}