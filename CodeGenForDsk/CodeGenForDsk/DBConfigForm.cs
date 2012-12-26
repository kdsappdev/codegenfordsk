using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeGenForDsk.CodeGenForDsk
{

    public partial class DBConfigForm:Utils.BaseForm
    {
        #region 字段
        Model.DbConfigInfo dbConfigInfo = new Model.DbConfigInfo();
        CodeGenForDskGui codeGenForDskGui = null;
        #endregion

        public DBConfigForm(CodeGenForDskGui cgfdg)
        {
            InitializeComponent();
            this.codeGenForDskGui = cgfdg;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                string message = "";
                getDbConfigInfo();
                bool status = Utils.INIConfigHelper.WriteDBInfo(dbConfigInfo, ref message);
                if (!status)
                {
                    MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    codeGenForDskGui.getDbConfigList();
                    MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkData())
                {
                    getDbConfigInfo();
                    string conString = dbConfigInfo.ConnectionString.Trim(new char[]{'"'});
                    string dbProvider =Utils.CodeGenHelper.GetDbProviderString(dbConfigInfo.DbType);
                    DNCCFrameWork.DataAccess.IDbHelper db = new DNCCFrameWork.DataAccess.DbFactory(conString, dbProvider).IDbHelper;
                    bool success = db.TestConnection();
                    string tip = "数据库连接失败";
                    if (success)
                    {
                        tip = "数据库连接成功";
                    }
                    MessageBox.Show(tip, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (System.Data.Common.DbException ex)
            {
                MessageBox.Show(ex.Message, "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
        #region

      
        private void getDbConfigInfo()
        {
            dbConfigInfo.DbServerName = teServerName.Text.Trim();
            dbConfigInfo.DbUserName = teUserName.Text.Trim();
            dbConfigInfo.DbUserPwd = teUserPwd.Text.Trim();
            dbConfigInfo.DbType = cbeConfigType.Text.Trim();
            dbConfigInfo.DbConfigName = teConfigName.Text.Trim();
        }
        private string emptyMsg = "不能为空";
        private bool checkData()
        {
            bool status = true;
            dxErrorProvider1.ClearErrors();
            if (string.IsNullOrEmpty(teServerName.Text))
            {
                dxErrorProvider1.SetError(teServerName, emptyMsg);
                status = false;
            }
            if (string.IsNullOrEmpty(teUserName.Text))
            {
                dxErrorProvider1.SetError(teUserName, emptyMsg);
                status = false;
            }
            if (string.IsNullOrEmpty(teUserPwd.Text))
            {
                dxErrorProvider1.SetError(teUserPwd, emptyMsg);
                status = false;
            }
            if (string.IsNullOrEmpty(cbeConfigType.Text))
            {
                dxErrorProvider1.SetError(cbeConfigType, emptyMsg);
                status = false;
            }
            if (string.IsNullOrEmpty(teConfigName.Text))
            {
                dxErrorProvider1.SetError(teConfigName, emptyMsg);
                status = false;
            }
            return status;
        }
        #endregion
    }
}
