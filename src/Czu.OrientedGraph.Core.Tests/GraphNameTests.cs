﻿using System;
using System.Collections.Generic;
using Czu.OrientedGraph.Core.Exceptions;
using FluentAssertions;
using Xunit;

namespace Czu.OrientedGraph.Core.Tests
{
    public class GraphNameTests
    {
        [Theory]
        [MemberData(nameof(GetInvalidInputData))]
        public void Ctor_InvalidInput_ThrowsModelException(string input)
        {
            Action actual = () =>
            {
                _ = new GraphName(input);
            };

            actual.Should().Throw<ModelException>();
        }

        [Theory]
        [InlineData("Name1", "name1", true)]
        [InlineData("Name1", "name2", false)]
        public void OperatorEquals_CompareNames_ReturnsSuccess(string leftValue, string rightValue, bool expected)
        {
            var leftName = new GraphName(leftValue);
            var rightName = new GraphName(rightValue);

            var actual = leftName == rightName;

            actual.Should().Be(expected);
        }

        [Fact]
        public void GetHashCode_NoInput_CreatesHash()
        {
            var graphName = new GraphName("Name");

            Action actual = () =>
            {
                _ = graphName.GetHashCode();
            };

            actual.Should().NotThrow();
        }

        [Fact]
        public void GetHashCode_SameValues_CreatesSameHash()
        {
            const string name = "Name";
            var graphName1 = new GraphName(name.ToLower());
            var graphName2 = new GraphName(name.ToUpper());

            graphName1.GetHashCode().Should().Be(graphName2.GetHashCode());
        }

        public static IEnumerable<object[]> GetInvalidInputData() =>
            new[]
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { new string('A', 256) }
            };
    }
}