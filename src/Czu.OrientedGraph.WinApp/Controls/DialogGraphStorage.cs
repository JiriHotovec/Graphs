using Czu.OrientedGraph.Core;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Czu.OrientedGraph.WinApp.Controls
{
    /// <summary>
    /// Form provides user interface for graph storage
    /// </summary>
    public partial class DialogGraphStorage : Form
    {
        private IGraphStorage<WeightedTwoWayEdge> _graphStorage;

        private DialogGraphStorage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="graphStorage">Graph storage</param>
        /// <exception cref="ArgumentNullException">Parameter cannot be null</exception>
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

        /// <summary>
        /// Returns selected graph from user interface
        /// </summary>
        public GraphName SelectedGraphName => this.listBoxGraphs.SelectedItem as GraphName;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}