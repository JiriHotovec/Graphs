
namespace Czu.OrientedGraph.WinApp.Controls
{
    partial class UserControlDijkstra
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelVertexSource = new System.Windows.Forms.Label();
            this.comboBoxVertexSource = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelVertexDestination = new System.Windows.Forms.Label();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.listBoxResultPaths = new System.Windows.Forms.ListBox();
            this.labelSumPathWeight = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.toolTipPath = new System.Windows.Forms.ToolTip(this.components);
            this.labelDijkstraTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelVertexSource
            // 
            this.labelVertexSource.AutoSize = true;
            this.labelVertexSource.Location = new System.Drawing.Point(3, 27);
            this.labelVertexSource.Name = "labelVertexSource";
            this.labelVertexSource.Size = new System.Drawing.Size(63, 13);
            this.labelVertexSource.TabIndex = 0;
            this.labelVertexSource.Text = "Vertex (src.)";
            // 
            // comboBoxVertexSource
            // 
            this.comboBoxVertexSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVertexSource.FormattingEnabled = true;
            this.comboBoxVertexSource.Location = new System.Drawing.Point(72, 24);
            this.comboBoxVertexSource.Name = "comboBoxVertexSource";
            this.comboBoxVertexSource.Size = new System.Drawing.Size(159, 21);
            this.comboBoxVertexSource.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // labelVertexDestination
            // 
            this.labelVertexDestination.AutoSize = true;
            this.labelVertexDestination.Location = new System.Drawing.Point(3, 54);
            this.labelVertexDestination.Name = "labelVertexDestination";
            this.labelVertexDestination.Size = new System.Drawing.Size(63, 13);
            this.labelVertexDestination.TabIndex = 2;
            this.labelVertexDestination.Text = "Vertex (dst.)";
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindPath.Location = new System.Drawing.Point(72, 78);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(159, 23);
            this.buttonFindPath.TabIndex = 4;
            this.buttonFindPath.Text = "Find path";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            // 
            // listBoxResultPaths
            // 
            this.listBoxResultPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResultPaths.FormattingEnabled = true;
            this.listBoxResultPaths.Location = new System.Drawing.Point(6, 138);
            this.listBoxResultPaths.Name = "listBoxResultPaths";
            this.listBoxResultPaths.Size = new System.Drawing.Size(225, 186);
            this.listBoxResultPaths.TabIndex = 5;
            // 
            // labelSumPathWeight
            // 
            this.labelSumPathWeight.AutoSize = true;
            this.labelSumPathWeight.Location = new System.Drawing.Point(3, 104);
            this.labelSumPathWeight.Name = "labelSumPathWeight";
            this.labelSumPathWeight.Size = new System.Drawing.Size(68, 13);
            this.labelSumPathWeight.TabIndex = 6;
            this.labelSumPathWeight.Text = "Weight Sum:";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(3, 120);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(32, 13);
            this.labelPath.TabIndex = 7;
            this.labelPath.Text = "Path:";
            // 
            // labelDijkstraTitle
            // 
            this.labelDijkstraTitle.AutoSize = true;
            this.labelDijkstraTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDijkstraTitle.Location = new System.Drawing.Point(3, 3);
            this.labelDijkstraTitle.Name = "labelDijkstraTitle";
            this.labelDijkstraTitle.Size = new System.Drawing.Size(142, 16);
            this.labelDijkstraTitle.TabIndex = 8;
            this.labelDijkstraTitle.Text = "Dijkstra\'s Algorithm";
            // 
            // UserControlDijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelDijkstraTitle);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelSumPathWeight);
            this.Controls.Add(this.listBoxResultPaths);
            this.Controls.Add(this.buttonFindPath);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelVertexDestination);
            this.Controls.Add(this.comboBoxVertexSource);
            this.Controls.Add(this.labelVertexSource);
            this.Name = "UserControlDijkstra";
            this.Size = new System.Drawing.Size(237, 332);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVertexSource;
        private System.Windows.Forms.ComboBox comboBoxVertexSource;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelVertexDestination;
        private System.Windows.Forms.Button buttonFindPath;
        private System.Windows.Forms.ListBox listBoxResultPaths;
        private System.Windows.Forms.Label labelSumPathWeight;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.ToolTip toolTipPath;
        private System.Windows.Forms.Label labelDijkstraTitle;
    }
}
