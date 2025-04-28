namespace testMWG9_4
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.尾矿库数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spatialStatusStrip1 = new DotSpatial.Controls.SpatialStatusStrip();
            this.spatialToolStrip1 = new DotSpatial.Controls.SpatialToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.map1 = new DotSpatial.Controls.Map();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.spatialStatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.尾矿库数据管理ToolStripMenuItem,
            this.用户信息管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.toolStripMenuItem1.Text = "影像显示";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 尾矿库数据管理ToolStripMenuItem
            // 
            this.尾矿库数据管理ToolStripMenuItem.Name = "尾矿库数据管理ToolStripMenuItem";
            this.尾矿库数据管理ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.尾矿库数据管理ToolStripMenuItem.Text = "尾矿库数据管理";
            this.尾矿库数据管理ToolStripMenuItem.Click += new System.EventHandler(this.尾矿库数据管理ToolStripMenuItem_Click);
            // 
            // 用户信息管理ToolStripMenuItem
            // 
            this.用户信息管理ToolStripMenuItem.Name = "用户信息管理ToolStripMenuItem";
            this.用户信息管理ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.用户信息管理ToolStripMenuItem.Text = "用户信息管理";
            // 
            // spatialStatusStrip1
            // 
            this.spatialStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.spatialStatusStrip1.Location = new System.Drawing.Point(0, 594);
            this.spatialStatusStrip1.Name = "spatialStatusStrip1";
            this.spatialStatusStrip1.ProgressBar = null;
            this.spatialStatusStrip1.ProgressLabel = this.toolStripStatusLabel1;
            this.spatialStatusStrip1.Size = new System.Drawing.Size(904, 22);
            this.spatialStatusStrip1.TabIndex = 1;
            this.spatialStatusStrip1.Text = "spatialStatusStrip1";
            // 
            // spatialToolStrip1
            // 
            this.spatialToolStrip1.ApplicationManager = null;
            this.spatialToolStrip1.Location = new System.Drawing.Point(0, 25);
            this.spatialToolStrip1.Map = this.map1;
            this.spatialToolStrip1.Name = "spatialToolStrip1";
            this.spatialToolStrip1.Size = new System.Drawing.Size(904, 25);
            this.spatialToolStrip1.TabIndex = 2;
            this.spatialToolStrip1.Text = "spatialToolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.legend1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.map1);
            this.splitContainer1.Size = new System.Drawing.Size(904, 544);
            this.splitContainer1.SplitterDistance = 232;
            this.splitContainer1.TabIndex = 3;
            // 
            // legend1
            // 
            this.legend1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 233, 544);
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 187, 428);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(0, 0);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(233, 544);
            this.legend1.TabIndex = 0;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.IsZoomedToMaxExtent = false;
            this.map1.Legend = this.legend1;
            this.map1.Location = new System.Drawing.Point(3, 3);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = this.spatialStatusStrip1;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(662, 541);
            this.map1.TabIndex = 0;
            this.map1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map1_MouseMove);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 616);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.spatialToolStrip1);
            this.Controls.Add(this.spatialStatusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.spatialStatusStrip1.ResumeLayout(false);
            this.spatialStatusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 尾矿库数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户信息管理ToolStripMenuItem;
        private DotSpatial.Controls.SpatialStatusStrip spatialStatusStrip1;
        private DotSpatial.Controls.SpatialToolStrip spatialToolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DotSpatial.Controls.Legend legend1;
        private DotSpatial.Controls.Map map1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}