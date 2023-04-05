using Czu.OrientedGraph.Core;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Czu.OrientedGraph.WinApp.Controls
{
    public partial class DialogGraphStorage : Form
    {
        private IGraphStorage<WeightedTwoWayEdge> _graphStorage;

        private DialogGraphStorage()
        {
            InitializeComponent();
        }

        public DialogGraphStorage(IGraphStorage<WeightedTwoWayEdge> graphStorage)
            : this()
        {
            _graphStorage = graphStorage ?? throw new ArgumentNullException(nameof(graphStorage));

            var graphNames = _graphStorage
                    .GetAllGraphNamesAsync()
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
            this.listBoxGraphs.DataSource = graphNames.ToList();
        }

        public GraphName SelectedGraphName => this.listBoxGraphs.SelectedItem as GraphName;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
