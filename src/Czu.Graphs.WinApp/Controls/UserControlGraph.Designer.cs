
namespace Czu.Graphs.WinApp.Controls
{
    partial class UserControlGraph
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
            this.comboBoxVertexSource = new System.Windows.Forms.ComboBox();
            this.comboBoxVertexDestination = new System.Windows.Forms.ComboBox();
            this.labelVertexSource = new System.Windows.Forms.Label();
            this.labelVertexDestination = new System.Windows.Forms.Label();
            this.buttonUpsert = new System.Windows.Forms.Button();
            this.labelWeight = new System.Windows.Forms.Label();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listBoxEdges = new System.Windows.Forms.ListBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxVertexSource
            // 
            this.comboBoxVertexSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVertexSource.FormattingEnabled = true;
            this.comboBoxVertexSource.Location = new System.Drawing.Point(76, 29);
            this.comboBoxVertexSource.Name = "comboBoxVertexSource";
            this.comboBoxVertexSource.Size = new System.Drawing.Size(104, 21);
            this.comboBoxVertexSource.TabIndex = 2;
            // 
            // comboBoxVertexDestination
            // 
            this.comboBoxVertexDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxVertexDestination.FormattingEnabled = true;
            this.comboBoxVertexDestination.Location = new System.Drawing.Point(76, 56);
            this.comboBoxVertexDestination.Name = "comboBoxVertexDestination";
            this.comboBoxVertexDestination.Size = new System.Drawing.Size(104, 21);
            this.comboBoxVertexDestination.TabIndex = 3;
            // 
            // labelVertexSource
            // 
            this.labelVertexSource.AutoSize = true;
            this.labelVertexSource.Location = new System.Drawing.Point(3, 32);
            this.labelVertexSource.Name = "labelVertexSource";
            this.labelVertexSource.Size = new System.Drawing.Size(63, 13);
            this.labelVertexSource.TabIndex = 2;
            this.labelVertexSource.Text = "Vertex (src.)";
            // 
            // labelVertexDestination
            // 
            this.labelVertexDestination.AutoSize = true;
            this.labelVertexDestination.Location = new System.Drawing.Point(3, 59);
            this.labelVertexDestination.Name = "labelVertexDestination";
            this.labelVertexDestination.Size = new System.Drawing.Size(63, 13);
            this.labelVertexDestination.TabIndex = 3;
            this.labelVertexDestination.Text = "Vertex (dst.)";
            // 
            // buttonUpsert
            // 
            this.buttonUpsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpsert.Location = new System.Drawing.Point(76, 110);
            this.buttonUpsert.Name = "buttonUpsert";
            this.buttonUpsert.Size = new System.Drawing.Size(104, 23);
            this.buttonUpsert.TabIndex = 5;
            this.buttonUpsert.Text = "Add/Update";
            this.buttonUpsert.UseVisualStyleBackColor = true;
            this.buttonUpsert.Click += new System.EventHandler(this.buttonUpsert_Click);
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(3, 86);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(41, 13);
            this.labelWeight.TabIndex = 5;
            this.labelWeight.Text = "Weight";
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownWeight.Location = new System.Drawing.Point(76, 84);
            this.numericUpDownWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(104, 20);
            this.numericUpDownWeight.TabIndex = 4;
            this.numericUpDownWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(6, 110);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(64, 23);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listBoxEdges
            // 
            this.listBoxEdges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEdges.FormattingEnabled = true;
            this.listBoxEdges.Location = new System.Drawing.Point(6, 139);
            this.listBoxEdges.Name = "listBoxEdges";
            this.listBoxEdges.Size = new System.Drawing.Size(174, 225);
            this.listBoxEdges.TabIndex = 6;
            this.listBoxEdges.Click += new System.EventHandler(this.listBoxEdges_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 6);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(67, 13);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "Graph Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(76, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(104, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // UserControlGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.listBoxEdges);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.numericUpDownWeight);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.buttonUpsert);
            this.Controls.Add(this.labelVertexDestination);
            this.Controls.Add(this.labelVertexSource);
            this.Controls.Add(this.comboBoxVertexDestination);
            this.Controls.Add(this.comboBoxVertexSource);
            this.Name = "UserControlGraph";
            this.Size = new System.Drawing.Size(186, 369);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVertexSource;
        private System.Windows.Forms.ComboBox comboBoxVertexDestination;
        private System.Windows.Forms.Label labelVertexSource;
        private System.Windows.Forms.Label labelVertexDestination;
        private System.Windows.Forms.Button buttonUpsert;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBoxEdges;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
    }
}
