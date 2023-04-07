using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Czu.OrientedGraph.Algorithm.Dijkstra;
using Czu.OrientedGraph.Core;

namespace Czu.OrientedGraph.WinApp.Controls
{
    public partial class UserControlDijkstra : UserControl
    {
        private readonly Graph<WeightedTwoWayEdge> _graph;

        private UserControlDijkstra()
        {
            InitializeComponent();
        }

        public UserControlDijkstra(Graph<WeightedTwoWayEdge> graph)
            : this()
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            RefreshUI();
        }

        private async void buttonFindPath_Click(object sender, EventArgs e)
        {
            var dijkstra = new DijkstraProvider(_graph.GetEdges().ToArray());
            var result = await dijkstra.GetShortestPathAsync(
                new Vertex(this.comboBoxVertexSource.Text),
                new Vertex(this.comboBoxVertexDestination.Text));

            if (!result.IsSuccess)
            {
                MessageBox.Show("Path was not found", "Validation");
                RefreshUI();
                return;
            }

            this.listBoxResultPaths.DataSource = result.Paths.ToList();
            this.labelPathValue.Text = GetPathVerticesText(GetPathVertices(result));
            this.labelSumPathWeightValue.Text = GetPathWeightTotal(result).ToString();
        }

        private void RefreshUI()
        {
            var vertices = _graph.GetVertices().OrderBy(o => o.Name).ToList();
            this.comboBoxVertexSource.DataSource = vertices.ToList();
            this.comboBoxVertexDestination.DataSource = vertices.ToList();
            this.listBoxResultPaths.Items.Clear();
        }

        private int GetPathWeightTotal(IPathResult result) => result.Paths.Sum(s => s.Weight);

        private IEnumerable<Vertex> GetPathVertices(IPathResult result)
        {
            var path = result.Paths.ToList();
            var vertices = new List<Vertex>();
            var vertex = new Vertex(this.comboBoxVertexSource.Text);
            while (vertex != null)
            {
                if (vertices.Contains(vertex))
                {
                    break;
                }

                vertices.Add(new Vertex(vertex.Name));
                vertex = GetNextVertex(vertex, path.FirstOrDefault(edge => edge.Source == vertex || edge.Destination == vertex));
            }

            return vertices;
        }

        private Vertex GetNextVertex(Vertex vertex, IEdge edge) =>
            vertex is null || edge is null ? null :
            edge.Source == vertex ? edge.Destination : edge.Source;

        private string GetPathVerticesText(IEnumerable<Vertex> vertices) => string.Join(" -> ", vertices);
    }
}