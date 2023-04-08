using System;
using System.Linq;
using System.Threading.Tasks;
using Czu.Graphs.Core;
using FluentAssertions;
using Xunit;

namespace Czu.Graphs.Core.Tests
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
            await storage.UpsertAsync(snapshot);

            (await storage.ExistsAsync(graphName)).Should().Be(true);
            (await storage.GetAllGraphNamesAsync()).Should().HaveCount(1);
            (await storage.GetAsync(graphName)).Should().BeEquivalentTo(snapshot);
            await storage.DeleteAsync(graphName);
            (await storage.ExistsAsync(graphName)).Should().Be(false);
        }
    }
}