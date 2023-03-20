using System;
using Czu.OrientedGraph.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Czu.OrientedGraph.Core.Tests
{
    public class GraphTests
    {
        [Fact]
        public void UpsertEdge_MaxInputsExceeded_ThrowsModelException()
        {
            const int maxEdges = 100;

            var graph = new Graph<TwoWayEdge>(new GraphName("Name"));
            for (int i = 0; i < maxEdges; i++)
            {
                graph.UpsertEdge(new TwoWayEdge(new Vertex(i.ToString()), new Vertex((maxEdges + i).ToString())));
            }

            Action actual = () =>
            {
                graph.UpsertEdge(new TwoWayEdge(new Vertex("Test1"), new Vertex("Test2")));
            };

            actual.Should().Throw<ModelException>();
        }
    }
}