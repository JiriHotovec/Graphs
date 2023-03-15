using System;
using System.Collections.Generic;
using Czu.WeightedGraph.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Czu.WeightedGraph.Core.Tests
{
    public class WeightedTwoWayEdgeTests
    {
        [Fact]
        public void Ctor_DefaultWeight_ReturnsObject()
        {
            const string srcVertexName = "Name1";
            const string dstVertexName = "Name2";
            var defaultWeight = new Weight(1);
            var expected = new WeightedTwoWayEdge(new Vertex(srcVertexName), new Vertex(dstVertexName), defaultWeight);

            var actual = new WeightedTwoWayEdge(new Vertex(srcVertexName), new Vertex(dstVertexName));

            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(GetWeightInputData))]
        public void Ctor_WeightInput_ReturnsSuccess(Weight leftWeight, Weight rightWeight, bool expected)
        {
            const string srcVertexName = "Name1";
            const string dstVertexName = "Name2";
            var left = new WeightedTwoWayEdge(new Vertex(srcVertexName), new Vertex(dstVertexName), leftWeight);
            var right = new WeightedTwoWayEdge(new Vertex(srcVertexName), new Vertex(dstVertexName), rightWeight);

            var actual = left.Weight == right.Weight;

            actual.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(GetEqualityData))]
        public void OperatorEquals_CompareEdges_ReturnsSuccess(WeightedTwoWayEdge leftValue, WeightedTwoWayEdge rightValue, bool expected)
        {
            var actual = leftValue == rightValue;

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetWeightInputData() =>
            new[]
            {
                new object[]
                {
                    new Weight(1),
                    new Weight(1),
                    true
                },
                new object[]
                {
                    new Weight(1),
                    new Weight(2),
                    false
                }
            };

        public static IEnumerable<object[]> GetEqualityData() =>
            new[]
            {
                new object[]
                {
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    true
                },
                new object[]
                {
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name2"), new Weight(1)),
                    new WeightedTwoWayEdge(new Vertex("Name2"), new Vertex("Name1"), new Weight(1)),
                    true
                },
                new object[]
                {
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name2"), new Weight(1)),
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name2"), new Weight(2)),
                    true
                },
                new object[]
                {
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name2"), new Weight(1)),
                    new WeightedTwoWayEdge(new Vertex("Name1"), new Vertex("Name3"), new Weight(1)),
                    false
                }
            };
    }
}