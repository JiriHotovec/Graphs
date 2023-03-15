using System;
using System.Collections.Generic;
using Czu.OrientedGraph.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Czu.OrientedGraph.Core.Tests
{
    public class WeightTests
    {
        [Theory]
        [MemberData(nameof(GetInvalidInputData))]
        public void Ctor_InvalidInput_ThrowsModelException(int input)
        {
            Action actual = () =>
            {
                _ = new Weight(input);
            };

            actual.Should().Throw<ModelException>();
        }

        [Theory]
        [InlineData(1, 1, true)]
        [InlineData(1, 2, false)]
        public void OperatorEquals_CompareWeights_ReturnsSuccess(int leftValue, int rightValue, bool expected)
        {
            var leftWeight = new Weight(leftValue);
            var rightWeight = new Weight(rightValue);

            var actual = leftWeight == rightWeight;

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetHashCode_NoInput_CreatesHash()
        {
            var vertex = new Weight(1);

            Action actual = () =>
            {
                _ = vertex.GetHashCode();
            };

            actual.Should().NotThrow();
        }

        public static IEnumerable<object[]> GetInvalidInputData() =>
            new[]
            {
                new object[] { int.MinValue },
                new object[] { 0 },
                new object[] { 1000001 },
                new object[] { int.MaxValue }
            };
    }
}