﻿using System.Collections.Generic;
using Czu.Graphs.Core;

namespace Czu.Graphs.Algorithm.Dijkstra
{
    /// <summary>
    /// An interface for Dijkstra's provider returned path result
    /// </summary>
    public interface IPathResult
    {
        bool IsSuccess { get; }

        IEnumerable<IWeightedEdge> Paths { get; }
    }
}