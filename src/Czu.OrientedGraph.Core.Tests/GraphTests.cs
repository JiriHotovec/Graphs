using System;
using System.Collections.Generic;
using Czu.OrientedGraph.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Czu.OrientedGraph.Core.Tests
{
    public class GraphTests
    {
        [Fact]
        public void Ctor_NullInput_ThrowsArgumentNullException()
        {
            Action actual = () =>
            {
                _ = new Graph<TwoWayEdge>(null);
            };

            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpsertEdge_NullInput_ThrowsArgumentNullException()
        {
            var graph = new Graph<TwoWayEdge>(new GraphName("Name"));

            Action actual = () =>
            {
                graph.UpsertEdge(null);
            };

            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpsertEdge_MaxInputsExceeded_ThrowsModelException()
        {
            const int maxEdges = Graph<TwoWayEdge>.MaxEdges;

            var graph = new Graph<TwoWayEdge>(new GraphName("Name"));
            for (int i = 0; i < maxEdges; i++)
            {
                graph.UpsertEdge(new TwoWayEdge(new Vertex("SameVertex"), new Vertex(i.ToString())));
            }

            Action actual = () =>
            {
                graph.UpsertEdge(new TwoWayEdge(new Vertex("SameVertex"), new Vertex("DiffVertex")));
            };

            actual.Should().Throw<ModelException>();
        }

        [Theory]
        [MemberData(nameof(GetValidTwoWayEdges))]
        public void UpsertEdge_ValidTwoWayEdges_ReturnsCount(IEnumerable<TwoWayEdge> inputs, int expected)
        {
            var graph = new Graph<TwoWayEdge>(new GraphName("Name"));
            foreach (var edge in inputs)
            {
                graph.UpsertEdge(edge);
            }

            graph.GetEdges().Should().HaveCount(c => c == expected);
        }

        [Fact]
        public void TryDelete_NullInput_ThrowsArgumentNullException()
        {
            var graph = new Graph<TwoWayEdge>(new GraphName("Name"));

            Action actual = () =>
            {
                graph.TryDeleteEdge(null);
            };

            actual.Should().Throw<ArgumentNullException>();
        }

        public static IEnumerable<object[]> GetValidTwoWayEdges() =>
            new[]
            {
                new object[]
                {
                    Array.Empty<TwoWayEdge>(),
                    0
                },
                new object[]
                {
                    new[]
                    {
                        new TwoWayEdge(new Vertex("A"), new Vertex("B"))
                    },
                    1
                },
                new object[]
                {
                    new[]
                    {
                        new TwoWayEdge(new Vertex("A"), new Vertex("B")),
                        new TwoWayEdge(new Vertex("B"), new Vertex("A"))
                    },
                    1
                },
                new object[]
                {
                    new[]
                    {
                        new TwoWayEdge(new Vertex("A"), new Vertex("B")),
                        new TwoWayEdge(new Vertex("A"), new Vertex("C")),
                        new TwoWayEdge(new Vertex("A"), new Vertex("D")),
                    },
                    3
                }
            };
    }
}