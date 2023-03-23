namespace Czu.OrientedGraph.WinApp
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemFileNew = new System.Windows.Forms.MenuItem();
            this.menuItemFileOpen = new System.Windows.Forms.MenuItem();
            this.menuItemFileSave = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemHelpView = new System.Windows.Forms.MenuItem();
            this.menuItemHelpAbout = new System.Windows.Forms.MenuItem();
            this.splitContainerGraph = new System.Windows.Forms.SplitContainer();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGraph)).BeginInit();
            this.splitContainerGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            //
            // mainMenu
            //
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemHelp});
            //
            // menuItemFile
            //
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFileNew,
            this.menuItemFileOpen,
            this.menuItemFileSave});
            this.menuItemFile.Text = "File";
            //
            // menuItemFileNew
            //
            this.menuItemFileNew.Index = 0;
            this.menuItemFileNew.Text = "New";
            //
            // menuItemFileOpen
            //
            this.menuItemFileOpen.Index = 1;
            this.menuItemFileOpen.Text = "Open";
            //
            // menuItemFileSave
            //
            this.menuItemFileSave.Index = 2;
            this.menuItemFileSave.Text = "Save";
            //
            // menuItemHelp
            //
            this.menuItemHelp.Index = 1;
            this.menuItemHelp.MdiList = true;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemHelpView,
            this.menuItemHelpAbout});
            this.menuItemHelp.Text = "Help";
            //
            // menuItemHelpView
            //
            this.menuItemHelpView.Index = 0;
            this.menuItemHelpView.Text = "View Help";
            //
            // menuItemHelpAbout
            //
            this.menuItemHelpAbout.Index = 1;
            this.menuItemHelpAbout.Text = "About Application";
            //
            // splitContainerGraph
            //
            this.splitContainerGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGraph.Location = new System.Drawing.Point(0, 0);
            this.splitContainerGraph.Name = "splitContainerGraph";
            this.splitContainerGraph.Panel1MinSize = 170;
            this.splitContainerGraph.Panel2MinSize = 300;
            this.splitContainerGraph.Size = new System.Drawing.Size(784, 300);
            this.splitContainerGraph.SplitterDistance = 185;
            this.splitContainerGraph.TabIndex = 0;
            //
            // splitContainerMain
            //
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainerMain.Panel1
            //
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerGraph);
            this.splitContainerMain.Panel1MinSize = 300;
            this.splitContainerMain.Panel2MinSize = 0;
            this.splitContainerMain.Size = new System.Drawing.Size(784, 361);
            this.splitContainerMain.SplitterDistance = 300;
            this.splitContainerMain.TabIndex = 0;
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "FormMain";
            this.Text = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGraph)).EndInit();
            this.splitContainerGraph.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemFileNew;
        private System.Windows.Forms.MenuItem menuItemFileOpen;
        private System.Windows.Forms.MenuItem menuItemFileSave;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemHelpView;
        private System.Windows.Forms.MenuItem menuItemHelpAbout;
        private System.Windows.Forms.SplitContainer splitContainerGraph;
        private System.Windows.Forms.SplitContainer splitContainerMain;
    }
}