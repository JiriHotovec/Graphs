using Czu.Graphs.Core;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Czu.Graphs.WinApp.Controls;

namespace Czu.Graphs.WinApp
{
    /// <summary>
    /// Main form of application
    /// </summary>
    public partial class FormMain : Form
    {
        private Graph<WeightedTwoWayEdge> _graph;
        private IGraphStorage<WeightedTwoWayEdge> _graphStorage =
            new GraphJsonFileStorage<WeightedTwoWayEdge>();
        private UserControlDijkstra _ucDijkstra;

        /// <summary>
        /// Ctor
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            ResetControlers();
        }

        private void ResetControlers() =>
            RefreshControlers(new Graph<WeightedTwoWayEdge>(new GraphName("New Graph")));

        private void RefreshControlers(Graph<WeightedTwoWayEdge> graph)
        {
            _graph = graph ?? throw new ArgumentNullException(nameof(graph));

            var graphUc = new UserControlGraph(graph);
            graphUc.Dock = DockStyle.Fill;
            graphUc.OnRefreshedUI = OnGraphChanged;
            this.splitContainerGraph.Panel1.Controls.Clear();
            this.splitContainerGraph.Panel1.Controls.Add(graphUc);

            _ucDijkstra = new UserControlDijkstra(graph);
            _ucDijkstra.Dock = DockStyle.Left;
            this.splitContainerGraph.Panel2.Controls.Clear();
            this.splitContainerGraph.Panel2.Controls.Add(_ucDijkstra);
        }

        private void menuItemHelpAbout_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemFileNew_Click(object sender, EventArgs e)
        {
            ResetControlers();
        }

        private async void menuItemFileOpen_Click(object sender, EventArgs e)
        {
            var dialog = new DialogGraphStorage(_graphStorage);
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var selectedGraphName = dialog.SelectedGraphName;
                if (selectedGraphName != null)
                {
                    var graphSnapshot = await _graphStorage.GetAsync(selectedGraphName);
                    var graph = Graph<WeightedTwoWayEdge>.FromSnapshot(graphSnapshot);
                    RefreshControlers(graph);
                }
            }
        }

        private async void menuItemFileSave_Click(object sender, EventArgs e)
        {
            if (await _graphStorage.ExistsAsync(_graph.Name))
            {
                var result = MessageBox.Show(
                    "Saved graph with the same name already exists." +
                    Environment.NewLine +
                    "Would you like to overwrite the file?",
                    "Graph already exists",
                    MessageBoxButtons.OKCancel);

                if (result != DialogResult.OK)
                {
                    return;
                }
            }

            await _graphStorage.UpsertAsync(_graph.ToSnapshot());

            MessageBox.Show("Graph was successfully saved", "Information");
        }

        private void menuItemHelpView_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JiriHotovec/Graphs#readme");
        }

        private void OnGraphChanged()
        {
            _ucDijkstra?.RefreshUI();
        }
    }
}