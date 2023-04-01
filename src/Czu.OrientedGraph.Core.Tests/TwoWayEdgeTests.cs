using System;
using System.Collections.Generic;
using Czu.OrientedGraph.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Czu.OrientedGraph.Core.Tests
{
    public class TwoWayEdgeTests
    {
        [Theory]
        [MemberData(nameof(GetValidInputData))]
        public void Ctor_ValidInput_ReturnsSameValues(Vertex input1, Vertex input2, TwoWayEdge expected)
        {
            var actual = new TwoWayEdge(input1, input2);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Ctor_InvalidInput_ThrowsModelException()
        {
            const string sameName = "SameName";

            Action actual = () =>
            {
                _ = new TwoWayEdge(new Vertex(sameName), new Vertex(sameName));
            };

            actual.Should().Throw<ModelException>();
        }

        [Theory]
        [MemberData(nameof(GetEqualityData))]
        public void OperatorEquals_CompareEdges_ReturnsSuccess(TwoWayEdge leftValue, TwoWayEdge rightValue, bool expected)
        {
            var actual = leftValue == rightValue;

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetHashCode_NoInput_CreatesHash()
        {
            var vertex = new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2"));

            Action actual = () =>
            {
                _ = vertex.GetHashCode();
            };

            actual.Should().NotThrow();
        }

        [Fact]
        public void GetHashCode_SameValues_CreatesSameHash()
        {
            var vertex1 = new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2"));
            var vertex2 = new TwoWayEdge(new Vertex("Name2"), new Vertex("Name1"));

            vertex1.GetHashCode().Should().Be(vertex2.GetHashCode());
        }

        [Fact]
        public void SwitchVertices_Input_ReturnsEdge()
        {
            var edge = new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2"));
            var expected = new TwoWayEdge(new Vertex("Name2"), new Vertex("Name1"));

            var actual = edge.SwitchVertices();

            actual.Source.Should().Be(expected.Source);
            actual.Destination.Should().Be(expected.Destination);
        }

        [Theory]
        [MemberData(nameof(GetHasRelationData))]
        public void HasRelation_EdgeInput_Returns(TwoWayEdge left, TwoWayEdge right, bool expected)
        {
            var actual = left.HasRelation(right);

            actual.Should().Be(expected);
        }

        public static IEnumerable<object[]> GetValidInputData() =>
            new[]
            {
                new object[]
                {
                    new Vertex("Name1"),
                    new Vertex("Name2"),
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2"))
                },
                new object[]
                {
                    new Vertex("Name2"),
                    new Vertex("Name1"),
                    new TwoWayEdge(new Vertex("Name2"), new Vertex("Name1"))
                }
            };

        public static IEnumerable<object[]> GetEqualityData() =>
            new[]
            {
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    true
                },
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name2"), new Vertex("Name1")),
                    true
                },
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name3")),
                    false
                },
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name3"), new Vertex("Name2")),
                    false
                }
            };

        public static IEnumerable<object[]> GetHasRelationData() =>
            new[]
            {
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name2"), new Vertex("Name1")),
                    true
                },
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    true
                },
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name2"), new Vertex("Name3")),
                    true
                },
                new object[]
                {
                    new TwoWayEdge(new Vertex("Name1"), new Vertex("Name2")),
                    new TwoWayEdge(new Vertex("Name3"), new Vertex("Name4")),
                    false
                },
            };
    }
}