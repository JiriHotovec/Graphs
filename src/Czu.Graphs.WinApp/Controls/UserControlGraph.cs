using Czu.Graphs.Core;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Czu.Graphs.WinApp.Controls
{
    /// <summary>
    /// User control provides user interface for graph
    /// </summary>
    public partial class UserControlGraph : UserControl
    {
        private readonly Graph<WeightedTwoWayEdge> _graph;

        private UserControlGraph()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="graph">Graph object</param>
        /// <exception cref="ArgumentNullException">Parameter cannot be null</exception>
        public UserControlGraph(Graph<WeightedTwoWayEdge> graph)
            : this()
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            RefreshUI();
        }

        /// <summary>
        /// Action called on RefreshUI method
        /// </summary>
        public Action OnRefreshedUI { get; set; }

        /// <summary>
        /// Refresh control items
        /// </summary>
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

            OnRefreshedUI?.Invoke();
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

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            var name = string.IsNullOrWhiteSpace(this.textBoxName.Text)
                ? new GraphName("New Graph")
                : new GraphName(this.textBoxName.Text);

            _graph.Rename(name);
        }

        private void listBoxEdges_Click(object sender, EventArgs e)
        {
            var edge = this.listBoxEdges.SelectedItem as IWeightedEdge;
            if (edge is null)
            {
                return;
            }

            this.comboBoxVertexSource.Text = edge.Source;
            this.comboBoxVertexDestination.Text = edge.Destination;
            this.numericUpDownWeight.Value = edge.Weight;
        }
    }
}