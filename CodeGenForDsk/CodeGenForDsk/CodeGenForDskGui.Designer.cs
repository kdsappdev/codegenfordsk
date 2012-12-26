namespace CodeGenForDsk.CodeGenForDsk
{
    partial class CodeGenForDskGui
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeGenForDskGui));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tvDB = new System.Windows.Forms.TreeView();
            this.mdiPanel1 = new CodeGenForDsk.MdiPanel();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnDBConfig = new DevExpress.XtraBars.BarButtonItem();
            this.beiDbConfig = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnReloadDB = new DevExpress.XtraBars.BarButtonItem();
            this.bsiTools = new DevExpress.XtraBars.BarSubItem();
            this.btnCodeGen = new DevExpress.XtraBars.BarSubItem();
            this.btnGenModel = new DevExpress.XtraBars.BarButtonItem();
            this.btnDBWordGen = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportData = new DevExpress.XtraBars.BarButtonItem();
            this.btnFxCopResultAnalyze = new DevExpress.XtraBars.BarButtonItem();
            this.btnMQGen = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bsiStaus = new DevExpress.XtraBars.BarStaticItem();
            this.beiProgreessBar = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.standaloneBarDockControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainerControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 422);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(3, 3);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(616, 27);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(3, 36);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.tvDB);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.mdiPanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(616, 383);
            this.splitContainerControl1.SplitterPosition = 191;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tvDB
            // 
            this.tvDB.CheckBoxes = true;
            this.tvDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDB.Location = new System.Drawing.Point(0, 0);
            this.tvDB.Name = "tvDB";
            this.tvDB.Size = new System.Drawing.Size(187, 379);
            this.tvDB.TabIndex = 0;
            this.tvDB.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvDB_AfterCheck);
            // 
            // mdiPanel1
            // 
            this.mdiPanel1.BackColor = System.Drawing.Color.Silver;
            this.mdiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdiPanel1.Location = new System.Drawing.Point(0, 0);
            this.mdiPanel1.Name = "mdiPanel1";
            this.mdiPanel1.Size = new System.Drawing.Size(415, 379);
            this.mdiPanel1.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDBConfig,
            this.beiDbConfig,
            this.btnReloadDB,
            this.bsiStaus,
            this.beiProgreessBar,
            this.bsiTools,
            this.btnCodeGen,
            this.btnGenModel,
            this.btnDBWordGen,
            this.btnRefresh,
            this.btnExportData,
            this.btnFxCopResultAnalyze,
            this.btnMQGen});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 27;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemProgressBar1});
            this.barManager1.StatusBar = this.bar1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDBConfig, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiDbConfig, "", true, true, true, 103),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReloadDB, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiTools),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar2.Text = "Main menu";
            // 
            // btnDBConfig
            // 
            this.btnDBConfig.Caption = "数据库配置";
            this.btnDBConfig.Id = 0;
            this.btnDBConfig.ImageIndex = 3;
            this.btnDBConfig.Name = "btnDBConfig";
            this.btnDBConfig.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDBConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBConfig_ItemClick);
            // 
            // beiDbConfig
            // 
            this.beiDbConfig.Edit = this.repositoryItemComboBox1;
            this.beiDbConfig.Id = 1;
            this.beiDbConfig.Name = "beiDbConfig";
            this.beiDbConfig.EditValueChanged += new System.EventHandler(this.beiDbConfig_EditValueChanged);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnReloadDB
            // 
            this.btnReloadDB.Caption = "重新加载数据库";
            this.btnReloadDB.Id = 2;
            this.btnReloadDB.ImageIndex = 0;
            this.btnReloadDB.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnReloadDB.Name = "btnReloadDB";
            this.btnReloadDB.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnReloadDB.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReloadDB_ItemClick);
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
            this.btnGenModel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGenModel_ItemClick);
            // 
            // btnDBWordGen
            // 
            this.btnDBWordGen.Caption = "数据库文档生成";
            this.btnDBWordGen.Id = 20;
            this.btnDBWordGen.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.btnDBWordGen.Name = "btnDBWordGen";
            this.btnDBWordGen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDBWordGen_ItemClick);
            // 
            // btnExportData
            // 
            this.btnExportData.Caption = "导出数据";
            this.btnExportData.Id = 24;
            this.btnExportData.ImageIndex = 1;
            this.btnExportData.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E));
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExportData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportData_ItemClick);
            // 
            // btnFxCopResultAnalyze
            // 
            this.btnFxCopResultAnalyze.Caption = "FxCop结果分析";
            this.btnFxCopResultAnalyze.Id = 25;
            this.btnFxCopResultAnalyze.Name = "btnFxCopResultAnalyze";
            this.btnFxCopResultAnalyze.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFxCopResultAnalyze_ItemClick);
            // 
            // btnMQGen
            // 
            this.btnMQGen.Caption = "MQ触发器生成";
            this.btnMQGen.Id = 26;
            this.btnMQGen.Name = "btnMQGen";
            this.btnMQGen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMQGen_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "刷新";
            this.btnRefresh.Id = 23;
            this.btnRefresh.ImageIndex = 5;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiStaus),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiProgreessBar, "", false, true, true, 211)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
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
            this.beiProgreessBar.Edit = this.repositoryItemProgressBar1;
            this.beiProgreessBar.EditValue = 0;
            this.beiProgreessBar.Id = 12;
            this.beiProgreessBar.Name = "beiProgreessBar";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBar1.Step = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "01977.ico");
            this.imageList1.Images.SetKeyName(1, "01075.ico");
            this.imageList1.Images.SetKeyName(2, "02946.ico");
            this.imageList1.Images.SetKeyName(3, "01816.ico");
            this.imageList1.Images.SetKeyName(4, "00731.ico");
            this.imageList1.Images.SetKeyName(5, "01952.ico");
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // CodeGenForDskGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CodeGenForDskGui";
            this.Size = new System.Drawing.Size(622, 445);
            this.Load += new System.EventHandler(this.CodeGenForDskGUI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarButtonItem btnDBConfig;
        private DevExpress.XtraBars.BarEditItem beiDbConfig;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarButtonItem btnReloadDB;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.TreeView tvDB;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem bsiStaus;
        private DevExpress.XtraBars.BarEditItem beiProgreessBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarSubItem bsiTools;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraBars.BarSubItem btnCodeGen;
        private DevExpress.XtraBars.BarButtonItem btnGenModel;
        private DevExpress.XtraBars.BarButtonItem btnDBWordGen;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnExportData;
        public MdiPanel mdiPanel1;
        private DevExpress.XtraBars.BarButtonItem btnFxCopResultAnalyze;
        private DevExpress.XtraBars.BarButtonItem btnMQGen;
    }
}
