using Czu.OrientedGraph.Core;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Czu.OrientedGraph.WinApp.Controls
{
    public partial class UserControlGraph : UserControl
    {
        private readonly Graph<WeightedTwoWayEdge> _graph;

        private UserControlGraph()
        {
            InitializeComponent();
        }

        public UserControlGraph(Graph<WeightedTwoWayEdge> graph)
            : this()
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            RefreshUI();
        }

        private void buttonUpsert_Click(object sender, EventArgs e)
        {
            _graph.UpsertEdge(
                CreateEdge(
                    this.comboBoxVertexSource.Text,
                    this.comboBoxVertexDestination.Text,
                    (int)this.numericUpDownWeight.Value));

            RefreshUI();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var edge = this.listBoxEdges.SelectedItem as WeightedTwoWayEdge;

            if (edge != null)
            {
                _graph.TryDeleteEdge(edge);

                RefreshUI();
            }
        }

        private WeightedTwoWayEdge CreateEdge(string vSrc, string vDst, int weight) =>
            new WeightedTwoWayEdge(
                new Vertex(vSrc),
                new Vertex(vDst),
                new Weight(weight));

        public void RefreshUI()
        {
            this.textBoxName.Text = _graph.Name;
            this.listBoxEdges.DataSource = _graph.GetEdges().ToList();
            this.comboBoxVertexSource.DataSource =
                _graph
                    .GetVertices()
                    .OrderBy(o => o.Name)
                    .ToList();
            this.comboBoxVertexSource.Text = string.Empty;
            this.comboBoxVertexDestination.DataSource =
                _graph
                    .GetVertices()
                    .OrderBy(o => o.Name)
                    .ToList();
            this.comboBoxVertexDestination.Text = string.Empty;
            this.numericUpDownWeight.Value = this.numericUpDownWeight.Minimum;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            var name = string.IsNullOrWhiteSpace(this.textBoxName.Text)
                ? new GraphName("New Graph")
                : new GraphName(this.textBoxName.Text);

            _graph.Rename(name);
        }
    }
}