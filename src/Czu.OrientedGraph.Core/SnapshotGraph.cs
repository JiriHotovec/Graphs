using System;
using System.Collections.Generic;

namespace Czu.OrientedGraph.Core
{
    public sealed class SnapshotGraph<T> where T : IEdge
    {
        public SnapshotGraph(string name, IEnumerable<T> edges)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            Edges = edges ?? throw new ArgumentNullException(nameof(edges));
        }

        public string Name { get; }

        public IEnumerable<T> Edges { get; }
    }
}