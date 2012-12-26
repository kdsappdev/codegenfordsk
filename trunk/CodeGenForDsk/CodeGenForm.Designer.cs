namespace CodeGenForDsk
{
    partial class CodeGenForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGenForm));
            this.codeGenForDskGUI1 = new CodeGenForDsk.CodeGenForDskGui();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBack = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeGenForDskGUI1
            // 
            this.codeGenForDskGUI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeGenForDskGUI1.Location = new System.Drawing.Point(0, 0);
            this.codeGenForDskGUI1.Name = "codeGenForDskGUI1";
            this.codeGenForDskGUI1.Size = new System.Drawing.Size(559, 430);
            this.codeGenForDskGUI1.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit,
            this.tsmiBack});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 48);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(115, 22);
            this.tsmiExit.Text = "退出(&E)";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiBack
            // 
            this.tsmiBack.Name = "tsmiBack";
            this.tsmiBack.Size = new System.Drawing.Size(115, 22);
            this.tsmiBack.Text = "返回(&F)";
            this.tsmiBack.Click += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // CodeGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 430);
            this.Controls.Add(this.codeGenForDskGUI1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "CodeGenForm";
            this.Text = "开发工具 By Dsk";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CodeGenForm_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CodeGenForDsk.CodeGenForDskGui codeGenForDskGUI1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiBack;
    }
}

