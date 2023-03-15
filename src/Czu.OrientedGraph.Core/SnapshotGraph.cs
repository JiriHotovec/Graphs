using System;
using System.Collections.Generic;

namespace Czu.OrientedGraph.Core
{
    public sealed class SnapshotGraph<T> where T : IEdge
    {
        public SnapshotGraph(IEnumerable<T> edges)
        {
            Edges = edges ?? throw new ArgumentNullException(nameof(edges));
        }

        public IEnumerable<T> Edges { get; }
    }
}