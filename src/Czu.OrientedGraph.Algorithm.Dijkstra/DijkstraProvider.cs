using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Czu.OrientedGraph.Core;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Algorithm.Dijkstra
{
    public class DijkstraProvider : IDijkstraProvider
    {
        private readonly ICollection<IWeightedEdge> _edges;

        public DijkstraProvider(ICollection<IWeightedEdge> edges)
        {
            _edges = edges ?? throw new ArgumentNullException(nameof(edges));
            if (!_edges.Any())
            {
                throw new ModelException("No edges");
            }
        }

        public Task<IPathResult> GetShortestPathAsync(
            Vertex source,
            Vertex destination,
            CancellationToken cancellationToken = default)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            var retPaths = new List<ParentPath>();
            var allPaths = GetPaths(source).ToList();
            var selPath = allPaths.FirstOrDefault(path => path.CurrentVertex == destination);
            if (selPath != null)
            {
                FillEdges(source, selPath, allPaths, retPaths);
            }

            var edges = new List<IWeightedEdge>();
            foreach (var path in retPaths)
            {
                foreach (var edge in _edges)
                {
                    if ((edge.Source == path.CurrentVertex && edge.Destination == path.ParentVertex) ||
                        (edge.Destination == path.CurrentVertex && edge.Source == path.ParentVertex))
                    {
                        edges.Add(edge);
                    }
                }
            }

            var result = new PathResult(edges);

            return Task.FromResult((IPathResult)result);
        }

        private void FillEdges(Vertex source, ParentPath path, ICollection<ParentPath> allPaths, ICollection<ParentPath> retPaths)
        {
            if (path == null)
            {
                throw new ModelException("Path was not found");
            }

            retPaths.Add(path);

            if (path.ParentVertex == source)
            {
                return;
            }

            var selPath = allPaths.FirstOrDefault(p => p.CurrentVertex == path.ParentVertex);
            FillEdges(source, selPath, allPaths, retPaths);
        }

        private static Vertex GetNextVertexSource(Vertex excluded, IWeightedEdge edge) =>
            edge.Source == excluded ? edge.Destination : edge.Source;

        private IEnumerable<IWeightedEdge> GetAllRelatedEdges(ICollection<Vertex> sources) =>
            _edges.Where(edge => sources.Contains(edge.Source) || sources.Contains(edge.Destination));

        private IEnumerable<ParentPath> GetPaths(Vertex source)
        {
            var result = new Dictionary<Vertex, ParentPath>();
            result.Add(source, new ParentPath(source, source, 0));
            var stepsCount = GetVertices().Count() - 1;
            for (int i = 0; i < stepsCount; i++)
            {
                var minPath = GetMinPath(result.Select(s => s.Value).ToArray());
                if (minPath == null)
                {
                    break;
                }

                result.Add(minPath.CurrentVertex, new ParentPath(minPath.CurrentVertex, minPath.ParentVertex, minPath.SumWeight));
            }

            return result.Select(s => s.Value);
        }

        private ParentPath GetMinPath(ICollection<ParentPath> sources)
        {
            var sourceVertices = sources.Select(s => s.CurrentVertex).ToArray();
            var edges = GetAllRelatedEdges(sourceVertices).ToList();

            var vNeightbours = new List<Vertex>();
            foreach (var source in sources)
            {
                var vertices = edges.Select(edge => GetNextVertexSource(source.CurrentVertex, edge))
                    .Where(vertex => !sourceVertices.Contains(vertex));
                foreach (var vertex in vertices)
                {
                    if (vNeightbours.Contains(vertex))
                    {
                        continue;
                    }
                    vNeightbours.Add(vertex);
                }
            }

            var paths = new Dictionary<Vertex, ParentPath>();
            var minVertexPaths = new Dictionary<Vertex, ParentPath>();
            foreach (var path in sources)
            {
                paths.Add(path.CurrentVertex, new ParentPath(path.CurrentVertex, path.ParentVertex, path.SumWeight));
            }

            foreach (var vertex in vNeightbours)
            {
                if (paths.ContainsKey(vertex))
                {
                    continue;
                }

                var eNeightbours = edges.Where(edge => edge.Source == vertex || edge.Destination == vertex);
                ParentPath minParentPath = null;
                int minPathWeight = 0;
                foreach (var edge in eNeightbours)
                {
                    var parentPath = paths[GetNextVertexSource(vertex, edge)];
                    var pathWeight = edge.Weight + parentPath.SumWeight;
                    if (minPathWeight == 0 || pathWeight < minPathWeight)
                    {
                        minParentPath = new ParentPath(vertex, parentPath.CurrentVertex, pathWeight);
                        minPathWeight = pathWeight;
                    }
                }

                if (minParentPath != null)
                {
                    minVertexPaths.Add(minParentPath.CurrentVertex, new ParentPath(minParentPath.CurrentVertex, minParentPath.ParentVertex, minParentPath.SumWeight));
                }
            }

            var minVertexSumWeight = minVertexPaths.Min(pair => pair.Value.SumWeight);
            var minVertexPath = minVertexPaths.Select(s => s.Value).FirstOrDefault(pair => pair.SumWeight == minVertexSumWeight);

            return minVertexPath;
        }

        private IEnumerable<Vertex> GetVertices()
        {
            var vertices = new List<Vertex>();
            foreach (var edge in _edges)
            {
                vertices.Add(edge.Source);
                vertices.Add(edge.Destination);
            }

            return vertices.Distinct();
        }

        private class ParentPath
        {
            public ParentPath(Vertex currentVertex, Vertex parentVertex, int sumWeight)
            {
                CurrentVertex = currentVertex;
                ParentVertex = parentVertex;
                SumWeight = sumWeight;
            }

            public Vertex CurrentVertex { get; }

            public Vertex ParentVertex { get; }

            public int SumWeight { get; }
        }
    }
}