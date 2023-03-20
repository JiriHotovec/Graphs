using System;
using System.Collections.Generic;
using System.Linq;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public sealed class Graph<T> where T : IEdge
    {
        private const int MaxEdges = 100;

        private readonly HashSet<T> _edges = new HashSet<T>();

        public Graph(GraphName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public GraphName Name { get; }

        public void UpsertEdge(T edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge));
            }

            if (_edges.Count >= MaxEdges)
            {
                throw new ModelException($"You have exceeded maximum number ({MaxEdges}) of edges in graph");
            }

            TryDeleteEdge(edge);

            _edges.Add(edge);
        }

        public void TryDeleteEdge(T edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge));
            }

            if (_edges.Contains(edge))
            {
                _edges.Remove(edge);
            }
        }

        public SnapshotGraph<T> ToSnapshot() =>
            new SnapshotGraph<T>(Name, _edges.ToArray());

        public static Graph<T> FromSnapshot(SnapshotGraph<T> snapshot)
        {
            if (snapshot is null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            var graph = new Graph<T>(new GraphName(snapshot.Name));
            foreach (var edge in snapshot.Edges)
            {
                graph.UpsertEdge(edge);
            }

            return graph;
        }
    }
}