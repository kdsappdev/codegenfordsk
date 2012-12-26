using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CodeGenForDsk.CodeGenForDsk
{
    public partial class CodeGenForDskGui:Utils.BaseUserControl
    {
        #region 数据库配置信息
        DataSet dsTable = new DataSet();//所有数据库表信息
        DataSet dsTableColumn = new DataSet();//所有表对应的列信息
        DataSet dsTablePrimaryKey = new DataSet();//所有表对应的主键信息
        IList<Model.DbConfigInfo> dbConfigList = new List<Model.DbConfigInfo>();
        Dictionary<string, Model.DbConfigInfo> dbConfigDic = new Dictionary<string, Model.DbConfigInfo>();
       public readonly string tables = "_TABLES";
       public readonly string tablesColumns = "_TABLES_COLUMNS";
       public readonly string views = "_VIEWS";
       public readonly string tablesPrimaryKeys = "_TABLES_PK";
        static bool isLoad = false;
        static object isLoadLock = new object();
        #endregion

        public CodeGenForDskGui()
        {
            InitializeComponent();
            setBtnEnable(false);
        }

        private void btnDBConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DBConfigForm f = new DBConfigForm(this);
            f.ShowDialog();
        }

        #region 绑定数据库配置信息
        delegate void Simple();
        public void getDbConfigList()
        {
            dbConfigList.Clear();
            repositoryItemComboBox1.Properties.Items.Clear();
            beiDbConfig.Refresh();
            dbConfigList = Utils.INIConfigHelper.ReadDBInfo();
            bindDbConfig();

        }
        private void bindDbConfig()
        {
            if (this.InvokeRequired)
            {
                Simple s = new Simple(bindDbConfig);
                this.Invoke(s, null);
            }
            else
            {
                foreach (Model.DbConfigInfo dc in dbConfigList)
                {
                    if (!dbConfigDic.ContainsKey(dc.DbConfigName))
                    {
                        repositoryItemComboBox1.Items.Add(dc.DbConfigName);
                        dbConfigDic.Add(dc.DbConfigName, dc);
                    }

                }
                if (dbConfigList != null && dbConfigList.Count > 0)
                {
                    if (string.IsNullOrEmpty(beiDbConfig.EditValue as string))
                    {
                        beiDbConfig.EditValue = dbConfigList[0].DbConfigName;
                    }
                }
            }
        }
        #endregion

        #region 加载当前选中数据库信息
        private Model.DbConfigInfo getCurenctDbConfigInfo()
        {
            Model.DbConfigInfo dbConfigInfo = null;
            string dbConfigName = beiDbConfig.EditValue as string;
            if (!string.IsNullOrEmpty(dbConfigName) && dbConfigDic.ContainsKey(dbConfigName))
            {
                dbConfigInfo = dbConfigDic[dbConfigName];
            }
            return dbConfigInfo;
        }
        private void loadDbInfoBySync(bool reloadDb)
        {
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null)
            {
                try
                {

                    #region 加载所有表信息
                    setStatusBar(string.Format("正在获取{0}中所有表信息", dbConfigInfo.DbConfigName));
                    setProgress(0);

                    if (dsTable.Tables.Contains(dbConfigInfo.DbConfigName + tables))
                    {
                        dsTable.Tables.Remove(dbConfigInfo.DbConfigName + tables);
                    }

                    #region 从本地读取数据
                    bool status = Utils.FileHelper.isExist(dbConfigInfo.DbConfigName, tables);
                    if (!reloadDb)
                    {
                        if (status)
                        {
                            Utils.FileHelper.ReadXml(dsTable, dbConfigInfo.DbConfigName, tables);
                        }
                    }
                    #endregion

                    #region  从数据库中读取数据
                    if (!status || reloadDb)
                    {
                        DNCCFrameWork.DataAccess.IDbHelper db = new DNCCFrameWork.DataAccess.DbFactory(dbConfigInfo.ConnectionString.Trim(new char[] { '"' }), Utils.CodeGenHelper.GetDbProviderString(dbConfigInfo.DbType)).IDbHelper;
                        string sql = Utils.SqlDefHelper.GetTableNames(dbConfigInfo.DbType);
                        db.Fill(sql, dsTable, new string[] { dbConfigInfo.DbConfigName + tables });
                        Utils.FileHelper.WriteXml(dsTable);//缓存表数据到本地
                    }
                    #endregion

                    setStatusBar(string.Format("{0}所有表信息加载完毕", dbConfigInfo.DbConfigName));
                    setProgress(10);
                    #endregion

                    #region 加载所有表主键
                    setStatusBar(string.Format("正在获取{0}中所有表主键信息", dbConfigInfo.DbConfigName));

                    if (dsTablePrimaryKey.Tables.Contains(dbConfigInfo.DbConfigName + tablesPrimaryKeys))
                    {
                        dsTablePrimaryKey.Tables.Remove(dbConfigInfo.DbConfigName + tablesPrimaryKeys);
                    }

                    #region 从本地读取数据
                    status = Utils.FileHelper.isExist(dbConfigInfo.DbConfigName, tablesPrimaryKeys);
                    if (!reloadDb)
                    {
                        if (status)
                        {
                            Utils.FileHelper.ReadXml(dsTablePrimaryKey, dbConfigInfo.DbConfigName, tablesPrimaryKeys);
                        }
                    }
                    #endregion

                    #region  从数据库中读取数据
                    if (!status || reloadDb)
                    {
                        DNCCFrameWork.DataAccess.IDbHelper db = new DNCCFrameWork.DataAccess.DbFactory(dbConfigInfo.ConnectionString.Trim(new char[] { '"' }), Utils.CodeGenHelper.GetDbProviderString(dbConfigInfo.DbType)).IDbHelper;
                        string sql = Utils.SqlDefHelper.GetAllTablePrimaryKeys(dbConfigInfo.DbType);
                        db.Fill(sql, dsTablePrimaryKey, new string[] { dbConfigInfo.DbConfigName + tablesPrimaryKeys });
                        Utils.FileHelper.WriteXml(dsTablePrimaryKey);//缓存表数据到本地
                    }
                    #endregion

                    setStatusBar(string.Format("{0}所有表主键信息加载完毕", dbConfigInfo.DbConfigName));
                    setProgress(10);
                    #endregion

                    #region 构造树形结构
                    bindTreeBySync();
                    #endregion

                    #region 加载所有表字段信息

                    setStatusBar(string.Format("正在获取{0}中所有表字段信息", dbConfigInfo.DbConfigName));

                    if (dsTableColumn.Tables.Contains(dbConfigInfo.DbConfigName + tablesColumns))
                    {
                        dsTableColumn.Tables.Remove(dbConfigInfo.DbConfigName + tablesColumns);
                    }

                    #region 从本地读取表字段信息
                    status = Utils.FileHelper.isExist(dbConfigInfo.DbConfigName, tablesColumns);
                    if (!reloadDb)
                    {
                        if (status)
                        {
                            Utils.FileHelper.ReadXml(dsTableColumn, dbConfigInfo.DbConfigName, tablesColumns);
                            setProgress(80);
                        }
                    }
                    #endregion

                    #region 从数据库读取表字段信息
                    if (!status || reloadDb)
                    {
                        DNCCFrameWork.DataAccess.IDbHelper db = new DNCCFrameWork.DataAccess.DbFactory(dbConfigInfo.ConnectionString.Trim(new char[] { '"' }), Utils.CodeGenHelper.GetDbProviderString(dbConfigInfo.DbType)).IDbHelper;
                        int count = dsTable.Tables[dbConfigInfo.DbConfigName + tables].Rows.Count;
                        int temp1 = count / 7;
                        bool isDivisible = count % temp1 == 0 ? true : false;
                        string sql = Utils.SqlDefHelper.GetTableColumnNames(dbConfigInfo.DbType);
                        for (int i = 0; i < count; i++)
                        {
                            DataRow dr = dsTable.Tables[dbConfigInfo.DbConfigName + tables].Rows[i];
                            DataSet temp = new DataSet();
                            Dictionary<string, string> dicPar = new Dictionary<string, string>();
                            dicPar.Add("@tableName", dr["name"] as string);
                            setStatusBar(string.Format("正在获取{0}中{1}字段信息", dbConfigInfo.DbConfigName, dr["name"] as string));
                            db.Fill(sql, temp, new string[] { dbConfigInfo.DbConfigName + tablesColumns }, dicPar);
                            dsTableColumn.Merge(temp);
                            if (i % temp1 == 0)
                            {
                                setProgress(10);
                            }
                        }
                        Utils.FileHelper.WriteXml(dsTableColumn);//缓存表字段数据到本地，
                        if (!isDivisible)
                        {
                            setProgress(10);
                        }
                    }
                    #endregion
                    #endregion

                }
                catch (System.Data.Common.DbException ex)
                {
                    MessageBox.Show("加载数据失败[" + ex.Message + "]", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 构造树形结构
        private void bindTreeBySync()
        {
            ThreadPool.QueueUserWorkItem(delegate(object o)
            {
                addNodes(tvDB.Nodes);
                exandAllTreeNode();
            });
        }

        #region 增加节点
        private void exandAllTreeNode()
        {
            if (this.InvokeRequired)
            {
                Simple s = new Simple(exandAllTreeNode);
                this.Invoke(s, null);
            }
            else
            {
                tvDB.ExpandAll();
            }
        }
        private void addNodes(TreeNodeCollection collection)
        {
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null)
            {

                for (int i = 0; i < dsTable.Tables.Count; i++)
                {
                    if (dsTable.Tables[i].TableName.Equals(dbConfigInfo.DbConfigName + tables))
                    {
                        addNodes(collection[0].Nodes, dsTable.Tables[i]);
                    }
                    if (dsTable.Tables[i].TableName.Equals(dbConfigInfo.DbConfigName + views))
                    {
                        addNodes(collection[1].Nodes, dsTable.Tables[i]);
                    }
                }
            }
        }

        private void createRootNode(TreeNodeCollection collection)
        {
            TreeNode tablesNode = new TreeNode();
            tablesNode.Text = TagType.Tables.ToString();
            tablesNode.Tag = TagType.Tables;
            addTreeNode(collection, tablesNode);

            TreeNode viewsNode = new TreeNode();
            viewsNode.Text = TagType.Views.ToString();
            viewsNode.Tag = TagType.Views;
            addTreeNode(collection, viewsNode);

        }
        private void addNodes(TreeNodeCollection collection, DataTable treeDataTable)
        {
            DataRowCollection rows = treeDataTable.Rows;

            foreach (DataRow row in rows)
            {
                //新建一个结点 =                 
                TreeNode node = createTreeNode(row);

                treeNodeimageIndex(node, false);

                addTreeNode(collection, node);//加入到结点集合中              

            }
            return;
        }

        private static TreeNode createTreeNode(DataRow row)
        {
            TreeNode node = new TreeNode();

            node.Text = row["name"] as string;
            string strTag = row["type"].ToString();
            if (!string.IsNullOrEmpty(strTag))
            {
                TagType tag = (TagType)Enum.Parse(typeof(TagType), strTag, true);
                node.Tag = new NodeTag(tag, row);
            }
            return node;
        }
        private delegate void addTreeNodeDel(TreeNodeCollection collection, TreeNode node);
        private void addTreeNode(TreeNodeCollection collection, TreeNode node)
        {
            if (this.InvokeRequired)
            {
                addTreeNodeDel atnd = new addTreeNodeDel(addTreeNode);
                this.Invoke(atnd, new object[] { collection, node });
            }
            else
            {
                collection.Add(node);
            }
        }
        private static void treeNodeimageIndex(TreeNode node, bool selected)
        {
            NodeTag nodeTag = node.Tag as NodeTag;
            selected = false;
            if (nodeTag != null)
            {
                switch (nodeTag.Tag)
                {
                    case TagType.DB:
                        node.ImageIndex = 7;
                        node.SelectedImageIndex = node.ImageIndex;
                        break;
                    case TagType.Tables:
                        if (selected)
                        {
                            node.ImageIndex = 0;
                            node.SelectedImageIndex = node.ImageIndex;
                        }
                        else
                        {
                            node.ImageIndex = 1;
                            node.SelectedImageIndex = node.ImageIndex;
                        }

                        break;
                    case TagType.Views:
                        if (selected)
                        {
                            node.ImageIndex = 3;
                            node.SelectedImageIndex = node.ImageIndex;
                        }
                        else
                        {
                            node.ImageIndex = 4;
                            node.SelectedImageIndex = node.ImageIndex;
                        }
                        break;
                    case TagType.Procedures:
                        if (selected)
                        {
                            node.ImageIndex = 5;
                            node.SelectedImageIndex = node.ImageIndex;
                        }
                        else
                        {
                            node.ImageIndex = 6;
                            node.SelectedImageIndex = node.ImageIndex;
                        }
                        break;
                }

            }
        }
        #endregion

        #region 清除树形结构
        private void clearTree()
        {
            if (this.InvokeRequired)
            {
                Simple s = new Simple(clearTree);
                this.Invoke(s, null);
            }
            else
            {
                tvDB.Nodes.Clear();
            }
        }
        #endregion
        #endregion

        #region 设置按钮状态
        delegate void SimpleBool(bool flag);
        public void setBtnEnable(bool flag)
        {
            if (this.InvokeRequired)
            {
                SimpleBool s = new SimpleBool(setBtnEnable);
                this.Invoke(s, new object[] { flag });
            }
            else
            {
                beiDbConfig.Enabled = flag;
                btnReloadDB.Enabled = flag;
                bsiTools.Enabled = flag;
                btnRefresh.Enabled = flag;
                if (dbConfigList.Count > 0)//当前已有可用的数据库配置
                {
                    btnDBConfig.Enabled = flag;
                }
                else
                {
                    btnDBConfig.Enabled = true;//第一次加载，无配置，启动配置选项
                }
            }
        }
        #endregion

        #region 初始化
        private void init()
        {
            if (!isLoad)
            {
                lock (isLoadLock)
                {
                    if (!isLoad)
                    {
                        getDbConfigList();
                        isLoad = true;
                    }
                }
            }
        } 
        private void CodeGenForDskGUI_Load(object sender, EventArgs e)
        {
            init();
        }
        #endregion

        #region 重新加载数据库
        private void btnReloadDB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            run(true);
        }
        #endregion

        #region 后台进程
        public void setProgreesEditValue(int i)
        {
            if (this.InvokeRequired)
            {
                SimpleInt s = new SimpleInt(setProgreesEditValue);
                this.Invoke(s, new object[] { i });
            }
            else
            {
                beiProgreessBar.EditValue = i; ;
            }
        }
        delegate void SimpleInt(int i);
        delegate void SimpleStr(string str);
        public void setProgressMax(int i)
        {
            if (this.InvokeRequired)
            {
                SimpleInt s = new SimpleInt(setProgressMax);
                this.Invoke(s, new object[] { i });
            }
            else
            {
                repositoryItemProgressBar1.Maximum = i;
            }
        }
        public void setProgress(int i)
        {
            if (this.InvokeRequired)
            {
                SimpleInt s = new SimpleInt(setProgress);
                this.Invoke(s, new object[] { i });
            }
            else
            {
                beiProgreessBar.EditValue = i + (int)beiProgreessBar.EditValue;
            }
        }
        public void setStatusBar(string str)
        {
            if (this.InvokeRequired)
            {
                SimpleStr s = new SimpleStr(setStatusBar);
                this.Invoke(s, new object[] { str });
            }
            else
            {
                bsiStaus.Caption = str;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            setBtnEnable(false);
            clearTree();
            this.createRootNode(tvDB.Nodes);
            bool flag = (bool)e.Argument;
            setProgreesEditValue(0);
            setProgress(0);
            loadDbInfoBySync(flag);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            setProgress(e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null)
            {
                setStatusBar(string.Format("{0}数据加载完毕，共{1}表",dbConfigInfo.DbConfigName,0));
                foreach (DataTable dt in dsTable.Tables)
                {
                    if (dt.TableName.Equals(dbConfigInfo.DbConfigName + tables))
                    {
                        setStatusBar(string.Format("{0}数据加载完毕，共{1}表", dbConfigInfo.DbConfigName, dsTable.Tables[dbConfigInfo.DbConfigName + tables].Rows.Count));
                    }
                }
                    setBtnEnable(true);
            }
        }
        #endregion

        #region Check选中操作
        private void tvDB_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bool check = e.Node.Checked;
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Checked = check;
            }
        }
        #endregion  

        #region 获取选择项

        private DataRow[] getCheckTable()
        {
            IList<TreeNode> tnCheckList = new List<TreeNode>();
            getTnCheck(tvDB.Nodes, tnCheckList);
            DataRow[] drTable = new DataRow[0];
            if (tnCheckList.Count > 0)
            {
                drTable = new DataRow[tnCheckList.Count];
                for (int i = 0; i < drTable.Length; i++)
                {
                    drTable[i] = (tnCheckList[i].Tag as NodeTag).Dr;
                }
            }
            return drTable;
        }

        private void getTnCheck(TreeNodeCollection collection, IList<TreeNode> tnCheckList)
        {
            foreach (TreeNode tn in collection)
            {
                if (tn.Checked && tn.Tag is NodeTag)
                {
                    tnCheckList.Add(tn);
                }
                if (tn.Nodes.Count > 0)
                {
                    getTnCheck(tn.Nodes, tnCheckList);
                }
            }
        }

        #endregion

        #region 数据配置改变
        private void beiDbConfig_EditValueChanged(object sender, EventArgs e)
        {
            run(false);
        }

        private void run(bool flag)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync(flag);
            }
        }
        #endregion

        #region 刷新
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            run(false);
        }
        #endregion

        #region 实体类属性生成
        private void btnGenModel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow[] drTable = getCheckTable();
            if (drTable == null || drTable.Length <= 0)
            {
                MessageBox.Show("请选中表或视图结构", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            genModel(drTable);           
        }
        private void genModel(DataRow[] drTable)
        {            
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null && drTable != null && drTable.Length > 0)
            {
                Gen.GenOptionInfo goi = new Gen.GenOptionInfo(this, dbConfigInfo);
                Utils.CodeGenHelper.Gen(dbConfigInfo.DbType, Utils.CodeGenEnum.Model, drTable, dsTableColumn, dsTablePrimaryKey, goi);
            }        
        }
        #endregion

        #region 数据库文档生成
        public void setBtnDBWordGenEnable(bool flag)
        {
            if (this.InvokeRequired)
            {
                SimpleBool s = new SimpleBool(setBtnDBWordGenEnable);
                this.Invoke(s, new object[] { flag });
            }
            else
            {
                btnDBWordGen.Enabled = flag;
                setBtnEnable(flag);
            }
        }
        private void btnDBWordGen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow[] drTable = getCheckTable();
            if (drTable == null || drTable.Length <= 0)
            {
                MessageBox.Show("请选中表结构", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThreadPool.QueueUserWorkItem(delegate(object o)
            {
                genDBWord(drTable);
            });
               
        }
        private void genDBWord(DataRow[] drTable)
        {          
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null && drTable != null && drTable.Length > 0)
            {
                Gen.GenOptionInfo goi = new Gen.GenOptionInfo(this,dbConfigInfo);
                Utils.CodeGenHelper.Gen(dbConfigInfo.DbType, Utils.CodeGenEnum.DBWord, drTable, dsTableColumn,dsTablePrimaryKey, goi);
            }          
        }
        #endregion

        #region 导出数据
        private void btnExportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow[] drTable = getCheckTable();
            if (drTable == null || drTable.Length <= 0)
            {
                MessageBox.Show("请选中表结构", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ThreadPool.QueueUserWorkItem(delegate(object o)
            {
                genDBData(drTable);
            });
        }
        private void genDBData(DataRow[] drTable)
        {           
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null && drTable != null && drTable.Length > 0)
            {
                Gen.GenOptionInfo goi = new Gen.GenOptionInfo(this, dbConfigInfo);
                if (dbConfigInfo.DbType.Equals("Oracle"))
                {
                    goi.OriginalEncoding = Encoding.GetEncoding("ISO-8859-1");
                    goi.TargetEncoding = Encoding.GetEncoding("GBK");
                }
                Utils.CodeGenHelper.Gen(dbConfigInfo.DbType, Utils.CodeGenEnum.DBData, drTable, dsTableColumn, dsTablePrimaryKey, goi);
            }            
        }
        #endregion

        private void btnFxCopResultAnalyze_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FxCop.FxCopAnalyzeForm fc = new FxCop.FxCopAnalyzeForm();
            fc.ShowDialog();
        }

        #region MQ触发器
        private void btnMQGen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow[] drTable = getCheckTable();
            if (drTable == null || drTable.Length <= 0)
            {
                MessageBox.Show("请选中表或视图结构", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            genMQTG(drTable);
        }
        private void genMQTG(DataRow[] drTable)
        {
            Model.DbConfigInfo dbConfigInfo = getCurenctDbConfigInfo();
            if (dbConfigInfo != null && drTable != null && drTable.Length > 0)
            {
                Gen.GenOptionInfo goi = new Gen.GenOptionInfo(this, dbConfigInfo);
                Utils.CodeGenHelper.Gen(dbConfigInfo.DbType, Utils.CodeGenEnum.MQTG, drTable, dsTableColumn, dsTablePrimaryKey, goi);
            }
        }
        #endregion
    }
    #region
    internal class NodeTag
    {
        public NodeTag()
        { }
        public NodeTag(TagType tag, DataRow dr)
        {

            this.tag = tag;
            this.dr = dr;
        }


        TagType tag = TagType.None;

        public TagType Tag
        {
            get { return tag; }            
        }
        DataRow dr = null;

        public DataRow Dr
        {
            get { return dr; }        
        }
    }
    internal enum TagType
    {
        DB,
        Tables,
        Table,
        Views,
        View,
        Procedures,
        Procedure,
        None

    }
    #endregion
}
