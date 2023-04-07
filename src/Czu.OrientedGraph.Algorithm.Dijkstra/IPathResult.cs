using System.Collections.Generic;
using Czu.OrientedGraph.Core;

namespace Czu.OrientedGraph.Algorithm.Dijkstra
{
    public interface IPathResult
    {
        bool IsSuccess { get; }

        IEnumerable<IWeightedEdge> Paths { get; }
    }
}