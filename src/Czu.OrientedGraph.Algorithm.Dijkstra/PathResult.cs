﻿using System;
using System.Collections.Generic;
using System.Linq;
using Czu.OrientedGraph.Core;

namespace Czu.OrientedGraph.Algorithm.Dijkstra
{
    /// <summary>
    /// Object result for Dijkstra's provider returned path result
    /// </summary>
    public class PathResult : IPathResult
    {
        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="paths">Returned shortest path collection of edges</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PathResult(IEnumerable<IWeightedEdge> paths)
        {
            Paths = paths ?? throw new ArgumentNullException(nameof(paths));
        }

        /// <summary>
        /// Property returned success state
        /// </summary>
        public bool IsSuccess => Paths.Any();

        /// <summary>
        /// Returned shortest path collection of edges
        /// </summary>
        public IEnumerable<IWeightedEdge> Paths { get; }
    }
}