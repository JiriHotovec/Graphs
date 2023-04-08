using Czu.Graphs.Algorithm.Dijkstra;
using Czu.Graphs.Core;
using FluentAssertions;
using Xunit;

namespace Czu.Graphs.Algorithm.Dijkstra.Tests
{
    public class DijkstraProviderTests
    {
        [Fact]
        public async void GetShortestPathAsync_ValidInputs_ReturnResult()
        {
            var edgeAB = new WeightedTwoWayEdge(new Vertex("A"), new Vertex("B"), new Weight(1));
            var edgeBC = new WeightedTwoWayEdge(new Vertex("B"), new Vertex("C"), new Weight(1));
            var edgeAC = new WeightedTwoWayEdge(new Vertex("A"), new Vertex("C"), new Weight(3));
            var edges = new[] { edgeAB, edgeBC, edgeAC };
            var dijkstra = new DijkstraProvider(edges);
            var expected = new[] { edgeAB, edgeBC };

            var actual = await dijkstra.GetShortestPathAsync(new Vertex("A"), new Vertex("C"));

            actual.Paths.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async void GetShortestPathAsync_ManyInputs_ReturnResult()
        {
            var edgeSA = new WeightedTwoWayEdge(new Vertex("S"), new Vertex("A"), new Weight(6));
            var edgeSB = new WeightedTwoWayEdge(new Vertex("S"), new Vertex("B"), new Weight(2));
            var edgeSC = new WeightedTwoWayEdge(new Vertex("S"), new Vertex("C"), new Weight(3));
            var edgeSD = new WeightedTwoWayEdge(new Vertex("S"), new Vertex("D"), new Weight(9));

            var edgeAB = new WeightedTwoWayEdge(new Vertex("A"), new Vertex("B"), new Weight(3));
            var edgeBC = new WeightedTwoWayEdge(new Vertex("B"), new Vertex("C"), new Weight(2));
            var edgeCD = new WeightedTwoWayEdge(new Vertex("C"), new Vertex("D"), new Weight(5));

            var edgeAE = new WeightedTwoWayEdge(new Vertex("A"), new Vertex("E"), new Weight(4));
            var edgeBE = new WeightedTwoWayEdge(new Vertex("B"), new Vertex("E"), new Weight(7));
            var edgeBF = new WeightedTwoWayEdge(new Vertex("B"), new Vertex("F"), new Weight(3));
            var edgeEF = new WeightedTwoWayEdge(new Vertex("E"), new Vertex("F"), new Weight(3));
            var edgeCF = new WeightedTwoWayEdge(new Vertex("C"), new Vertex("F"), new Weight(1));
            var edgeDG = new WeightedTwoWayEdge(new Vertex("D"), new Vertex("G"), new Weight(1));
            var edgeFG = new WeightedTwoWayEdge(new Vertex("F"), new Vertex("G"), new Weight(2));


            var edges = new[]
            {
                edgeSA,
                edgeSB,
                edgeSC,
                edgeSD,
                edgeAB,
                edgeBC,
                edgeCD,
                edgeAE,
                edgeBE,
                edgeBF,
                edgeEF,
                edgeCF,
                edgeDG,
                edgeFG
            };
            var dijkstra = new DijkstraProvider(edges);
            var expected = new[]
            {
                edgeSC,
                edgeCF,
                edgeFG,
                edgeDG
            };

            var actual = await dijkstra.GetShortestPathAsync(new Vertex("S"), new Vertex("D"));

            actual.Paths.Should().BeEquivalentTo(expected);
        }
    }
}