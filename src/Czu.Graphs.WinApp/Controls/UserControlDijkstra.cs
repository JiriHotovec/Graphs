using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Czu.Graphs.Algorithm.Dijkstra;
using Czu.Graphs.Core;

namespace Czu.Graphs.WinApp.Controls
{
    /// <summary>
    /// User control provides user interface for Dijkstra's algorithm
    /// </summary>
    public partial class UserControlDijkstra : UserControl
    {
        private readonly Graph<WeightedTwoWayEdge> _graph;

        private UserControlDijkstra()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="graph">Graph object</param>
        /// <exception cref="ArgumentNullException">Parameter cannot be null</exception>
        public UserControlDijkstra(Graph<WeightedTwoWayEdge> graph)
            : this()
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            RefreshUI();
        }

        /// <summary>
        /// Refresh control items
        /// </summary>
        public void RefreshUI()
        {
            var vertices = _graph.GetVertices().OrderBy(o => o.Name).ToList();
            this.comboBoxVertexSource.DataSource = vertices.ToList();
            this.comboBoxVertexSource.Text =
                vertices.Count > 0
                ? vertices[0]
                : string.Empty;
            this.comboBoxVertexDestination.DataSource = vertices.ToList();
            this.comboBoxVertexDestination.Text =
                vertices.Count > 1
                ? vertices[1]
                : this.comboBoxVertexSource.Text;
            this.listBoxResultPaths.DataSource = Array.Empty<string>();
            this.labelPathValue.Text = "->";
            this.labelSumPathWeightValue.Text = "0";
            this.toolTip1.SetToolTip(this.labelPathValue, this.labelPathValue.Text);
        }

        private async void buttonFindPath_Click(object sender, EventArgs e)
        {
            var vSrc = new Vertex(this.comboBoxVertexSource.Text);
            var vDst = new Vertex(this.comboBoxVertexDestination.Text);
            if (vSrc == vDst)
            {
                this.labelPathValue.Text = vSrc;
                this.labelSumPathWeightValue.Text = "0";
                this.listBoxResultPaths.DataSource = Array.Empty<string>();
                this.toolTip1.SetToolTip(this.labelPathValue, this.labelPathValue.Text);
                return;
            }

            var dijkstra = new DijkstraProvider(_graph.GetEdges().ToArray());
            var result = await dijkstra.GetShortestPathAsync(vSrc, vDst);

            if (!result.IsSuccess)
            {
                MessageBox.Show("Path was not found", "Validation");
                RefreshUI();
                return;
            }

            this.listBoxResultPaths.DataSource = result.Paths.ToList();
            this.labelPathValue.Text = GetPathVerticesText(GetPathVertices(result));
            this.labelSumPathWeightValue.Text = GetPathWeightTotal(result).ToString();
            this.toolTip1.SetToolTip(this.labelPathValue, this.labelPathValue.Text);
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