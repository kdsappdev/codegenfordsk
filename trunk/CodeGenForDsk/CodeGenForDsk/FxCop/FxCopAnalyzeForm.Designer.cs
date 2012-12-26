namespace CodeGenForDsk.CodeGenForDsk.FxCop
{
    partial class FxCopAnalyzeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxCopAnalyzeForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAnalyze = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.teFilePath = new DevExpress.XtraEditors.TextEdit();
            this.btnOpenFile = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teFilePath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Controls.Add(this.btnAnalyze, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.teFilePath, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenFile, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 97);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(226, 52);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(55, 23);
            this.btnAnalyze.TabIndex = 2;
            this.btnAnalyze.Text = "分析";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(34, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "文件:";
            // 
            // teFilePath
            // 
            this.teFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teFilePath.Location = new System.Drawing.Point(43, 23);
            this.teFilePath.Name = "teFilePath";
            this.teFilePath.Size = new System.Drawing.Size(177, 21);
            this.teFilePath.TabIndex = 1;
            this.teFilePath.EditValueChanged += new System.EventHandler(this.teFilePath_EditValueChanged);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(226, 23);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(55, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "浏览";
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "FxCop文件(*.xml)|*.xml";
            this.openFileDialog1.Title = "打开FxCop文件";
            // 
            // FxCopAnalyzeForm
            // 
            this.AcceptButton = this.btnOpenFile;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 97);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FxCopAnalyzeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FxCop结果分析";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teFilePath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton btnAnalyze;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit teFilePath;
        private DevExpress.XtraEditors.SimpleButton btnOpenFile;
    }
}