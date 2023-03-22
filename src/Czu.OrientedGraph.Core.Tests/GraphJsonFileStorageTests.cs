using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Czu.OrientedGraph.Core.Tests
{
    public class GraphJsonFileStorageTests
    {
        [Fact]
        public async Task FileWorkflow_TwoWayEdge()
        {
            var graphName = new GraphName(Guid.NewGuid().ToString());
            var snapshot = new SnapshotGraph<TwoWayEdge>(
                graphName.Value,
                new[]
                {
                    new TwoWayEdge(new Vertex("A"), new Vertex("B")),
                    new TwoWayEdge(new Vertex("B"), new Vertex("C")),
                });

            var storage = new GraphJsonFileStorage<TwoWayEdge>();
            var filesCount = (await storage.GetAllGraphNamesAsync()).Count();
            await storage.UpsertAsync(snapshot);

            (await storage.ExistsAsync(graphName)).Should().Be(true);
            (await storage.GetAllGraphNamesAsync()).Should().HaveCount(filesCount + 1);
            (await storage.GetAsync(graphName)).Should().BeEquivalentTo(snapshot);
            await storage.DeleteAsync(graphName);
            (await storage.ExistsAsync(graphName)).Should().Be(false);
        }
    }
}