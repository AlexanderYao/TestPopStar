namespace TestPopStar
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.saveResumeTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.middleTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.largeTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startTsmi,
            this.saveResumeTsmi,
            this.sizeToolStripMenuItem,
            this.exitTsmi});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startTsmi
            // 
            this.startTsmi.Name = "startTsmi";
            this.startTsmi.Size = new System.Drawing.Size(48, 20);
            this.startTsmi.Text = "Start";
            this.startTsmi.Click += new System.EventHandler(this.startTsmi_Click);
            // 
            // saveResumeTsmi
            // 
            this.saveResumeTsmi.Name = "saveResumeTsmi";
            this.saveResumeTsmi.Size = new System.Drawing.Size(66, 20);
            this.saveResumeTsmi.Text = "Resume";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallTsmi,
            this.middleTsmi,
            this.largeTsmi});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // smallTsmi
            // 
            this.smallTsmi.CheckOnClick = true;
            this.smallTsmi.Name = "smallTsmi";
            this.smallTsmi.Size = new System.Drawing.Size(152, 22);
            this.smallTsmi.Text = "Small";
            this.smallTsmi.Click += new System.EventHandler(this.sizeTsmi_Click);
            // 
            // middleTsmi
            // 
            this.middleTsmi.Checked = true;
            this.middleTsmi.CheckOnClick = true;
            this.middleTsmi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.middleTsmi.Name = "middleTsmi";
            this.middleTsmi.Size = new System.Drawing.Size(152, 22);
            this.middleTsmi.Text = "Middle";
            this.middleTsmi.Click += new System.EventHandler(this.sizeTsmi_Click);
            // 
            // largeTsmi
            // 
            this.largeTsmi.CheckOnClick = true;
            this.largeTsmi.Name = "largeTsmi";
            this.largeTsmi.Size = new System.Drawing.Size(152, 22);
            this.largeTsmi.Text = "Large";
            this.largeTsmi.Click += new System.EventHandler(this.sizeTsmi_Click);
            // 
            // exitTsmi
            // 
            this.exitTsmi.Name = "exitTsmi";
            this.exitTsmi.Size = new System.Drawing.Size(40, 20);
            this.exitTsmi.Text = "Exit";
            this.exitTsmi.Click += new System.EventHandler(this.exitTsmi_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(543, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusToolStrip
            // 
            this.statusToolStrip.Name = "statusToolStrip";
            this.statusToolStrip.Size = new System.Drawing.Size(128, 17);
            this.statusToolStrip.Text = "New Game Started...";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 368);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 414);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PopStar";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startTsmi;
        private System.Windows.Forms.ToolStripMenuItem saveResumeTsmi;
        private System.Windows.Forms.ToolStripMenuItem exitTsmi;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusToolStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallTsmi;
        private System.Windows.Forms.ToolStripMenuItem middleTsmi;
        private System.Windows.Forms.ToolStripMenuItem largeTsmi;
    }
}

