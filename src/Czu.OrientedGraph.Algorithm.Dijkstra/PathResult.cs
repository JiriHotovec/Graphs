using System;
using System.Collections.Generic;
using System.Linq;
using Czu.OrientedGraph.Core;

namespace Czu.OrientedGraph.Algorithm.Dijkstra
{
    public class PathResult : IPathResult
    {
        public PathResult(IEnumerable<IWeightedEdge> paths)
        {
            Paths = paths ?? throw new ArgumentNullException(nameof(paths));
        }

        public bool IsSuccess => Paths.Any();

        public IEnumerable<IWeightedEdge> Paths { get; }
    }
}