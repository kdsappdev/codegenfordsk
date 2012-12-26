namespace CodeGenForDsk.CodeGenForDsk
{
    partial class SqlForm
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
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.btnDBConfig = new DevExpress.XtraBars.BarButtonItem();
            this.beiDbConfig = new DevExpress.XtraBars.BarEditItem();
            this.btnReloadDB = new DevExpress.XtraBars.BarButtonItem();
            this.bsiTools = new DevExpress.XtraBars.BarSubItem();
            this.btnCodeGen = new DevExpress.XtraBars.BarSubItem();
            this.btnGenModel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDBWordGen = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportData = new DevExpress.XtraBars.BarButtonItem();
            this.btnFxCopResultAnalyze = new DevExpress.XtraBars.BarButtonItem();
            this.btnMQGen = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bsiStaus = new DevExpress.XtraBars.BarStaticItem();
            this.beiProgreessBar = new DevExpress.XtraBars.BarEditItem();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnExecuteSql = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.memoEdit1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExecuteSql, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(637, 518);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.Location = new System.Drawing.Point(3, 30);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Silver;
            this.memoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.memoEdit1.Size = new System.Drawing.Size(631, 485);
            this.memoEdit1.TabIndex = 0;
            // 
            // btnDBConfig
            // 
            this.btnDBConfig.Caption = "数据库配置";
            this.btnDBConfig.Id = 0;
            this.btnDBConfig.ImageIndex = 3;
            this.btnDBConfig.Name = "btnDBConfig";
            this.btnDBConfig.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // beiDbConfig
            // 
            repositoryItemComboBox1.AutoHeight = false;
            repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.beiDbConfig.Edit = repositoryItemComboBox1;
            this.beiDbConfig.Id = 1;
            this.beiDbConfig.Name = "beiDbConfig";
            // 
            // btnReloadDB
            // 
            this.btnReloadDB.Caption = "重新加载数据库";
            this.btnReloadDB.Id = 2;
            this.btnReloadDB.ImageIndex = 0;
            this.btnReloadDB.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bsiTools
            // 
            this.bsiTools.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiTools.Caption = "工具";
            this.bsiTools.Id = 13;
            this.bsiTools.ImageIndex = 2;
            this.bsiTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCodeGen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGenModel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDBWordGen),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportData),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFxCopResultAnalyze),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMQGen)});
            this.bsiTools.Name = "bsiTools";
            this.bsiTools.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnCodeGen
            // 
            this.btnCodeGen.Caption = "代码生成";
            this.btnCodeGen.Id = 15;
            this.btnCodeGen.Name = "btnCodeGen";
            // 
            // btnGenModel
            // 
            this.btnGenModel.Caption = "实体类属性生成";
            this.btnGenModel.Id = 19;
            this.btnGenModel.ImageIndex = 4;
            this.btnGenModel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnGenModel.Name = "btnGenModel";
            this.btnGenModel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnDBWordGen
            // 
            this.btnDBWordGen.Caption = "数据库文档生成";
            this.btnDBWordGen.Id = 20;
            this.btnDBWordGen.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.btnDBWordGen.Name = "btnDBWordGen";
            // 
            // btnExportData
            // 
            this.btnExportData.Caption = "导出数据";
            this.btnExportData.Id = 24;
            this.btnExportData.ImageIndex = 1;
            this.btnExportData.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnFxCopResultAnalyze
            // 
            this.btnFxCopResultAnalyze.Caption = "FxCop结果分析";
            this.btnFxCopResultAnalyze.Id = 25;
            this.btnFxCopResultAnalyze.Name = "btnFxCopResultAnalyze";
            // 
            // btnMQGen
            // 
            this.btnMQGen.Caption = "MQ触发器生成";
            this.btnMQGen.Id = 26;
            this.btnMQGen.Name = "btnMQGen";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "刷新";
            this.btnRefresh.Id = 23;
            this.btnRefresh.ImageIndex = 5;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // bsiStaus
            // 
            this.bsiStaus.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.bsiStaus.Id = 11;
            this.bsiStaus.Name = "bsiStaus";
            this.bsiStaus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // beiProgreessBar
            // 
            this.beiProgreessBar.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            repositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            repositoryItemProgressBar1.Step = 1;
            this.beiProgreessBar.Edit = repositoryItemProgressBar1;
            this.beiProgreessBar.EditValue = 0;
            this.beiProgreessBar.Id = 12;
            this.beiProgreessBar.Name = "beiProgreessBar";
            // 
            // btnExecuteSql
            // 
            this.btnExecuteSql.Location = new System.Drawing.Point(3, 3);
            this.btnExecuteSql.Name = "btnExecuteSql";
            this.btnExecuteSql.Size = new System.Drawing.Size(62, 21);
            this.btnExecuteSql.TabIndex = 1;
            this.btnExecuteSql.Text = "执行";
            this.btnExecuteSql.UseVisualStyleBackColor = true;
            this.btnExecuteSql.Click += new System.EventHandler(this.btnExecuteSql_Click);
            // 
            // SqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(637, 518);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SqlForm";
            this.Text = "SqlForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private System.Windows.Forms.Button btnExecuteSql;
        private DevExpress.XtraBars.BarButtonItem btnDBConfig;
        private DevExpress.XtraBars.BarEditItem beiDbConfig;
        private DevExpress.XtraBars.BarButtonItem btnReloadDB;
        private DevExpress.XtraBars.BarSubItem bsiTools;
        private DevExpress.XtraBars.BarSubItem btnCodeGen;
        private DevExpress.XtraBars.BarButtonItem btnGenModel;
        private DevExpress.XtraBars.BarButtonItem btnDBWordGen;
        private DevExpress.XtraBars.BarButtonItem btnExportData;
        private DevExpress.XtraBars.BarButtonItem btnFxCopResultAnalyze;
        private DevExpress.XtraBars.BarButtonItem btnMQGen;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarStaticItem bsiStaus;
        private DevExpress.XtraBars.BarEditItem beiProgreessBar;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;


    }
}