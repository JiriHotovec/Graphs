using Czu.OrientedGraph.Core;
using Czu.OrientedGraph.WinApp.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Czu.OrientedGraph.WinApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            var graph = new Graph<WeightedTwoWayEdge>(new GraphName("New Graph"));
            var graphUc = new UserControlGraph(graph);
            graphUc.Dock = DockStyle.Fill;
            this.splitContainerGraph.Panel1.Controls.Add(graphUc);
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
    }
}