using System;
using System.Collections.Generic;
using System.Linq;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public sealed class Graph<T> where T : IEdge
    {
        public const int MaxEdges = 100;

        private readonly HashSet<T> _edges = new HashSet<T>();

        private GraphName _name;

        public Graph(GraphName name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public GraphName Name => _name;

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

        public void Rename(GraphName name) =>
            _name = name ?? throw new ArgumentNullException(nameof(name));

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

            if (!_edges.Contains(edge))
            {
                return;
            }

            _edges.Remove(edge);
        }

        public IEnumerable<T> GetEdges() => _edges.ToArray();

        public IEnumerable<Vertex> GetVertices()
        {
            var vertices = new List<Vertex>();
            foreach (var edge in _edges)
            {
                vertices.Add(edge.Source);
                vertices.Add(edge.Destination);
            }

            return vertices.Distinct();
        }

        public void SwitchVertices(T edge)
        {
            if (edge == null)
            {
                throw new ArgumentNullException(nameof(edge));
            }

            UpsertEdge((T)edge.SwitchVertices());
        }
    }
}