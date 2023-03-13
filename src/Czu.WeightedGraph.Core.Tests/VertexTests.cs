using System;
using FluentAssertions;
using Xunit;

namespace Czu.WeightedGraph.Core.Tests
{
    public class VertexTests
    {
        [Fact]
        public void Ctor_NullInput_ThrowsArgumentException()
        {
            Action actual = () =>
            {
                _ = new Vertex(null);
            };

            actual.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("Name1", "name1", true)]
        [InlineData("Name1", "name2", false)]
        public void OperatorEquals_CompareIds_ReturnsSuccess(string leftValue, string rightValue, bool expected)
        {
            var leftId = new Vertex(leftValue);
            var rightId = new Vertex(rightValue);

            var actual = leftId == rightId;

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetHashCode_NoInput_CreatesHash()
        {
            var vertex = new Vertex("Name");

            Action actual = () =>
            {
                _ = vertex.GetHashCode();
            };

            actual.Should().NotThrow();
        }

        [Fact]
        public void GetHashCode_SameValues_CreatesSameHash()
        {
            const string name = "Name";
            var vertex1 = new Vertex(name.ToLower());
            var vertex2 = new Vertex(name.ToUpper());

            vertex1.GetHashCode().Should().Be(vertex2.GetHashCode());
        }
    }
}