using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeGenForDsk.CodeGenForDsk
{
    public partial class SqlForm : Form
    {
        string modelContent = "";
        Model.DbConfigInfo dbConfigInfo;
        public SqlForm(Form mdiParentForm, string str, string title, Model.DbConfigInfo dbConfigInfo)
        {
            InitializeComponent();
            setMdiParent(mdiParentForm);
            modelContent = str;
            setTitle(title);
            setModelContent(modelContent);
            this.dbConfigInfo = dbConfigInfo;
        }
        delegate void Simple<T>(T t);
        delegate void Simple();
        private void setMdiParent(Form mdiParentForm)
        {
            if (this.InvokeRequired)
            {
                Simple<Form> s = new Simple<Form>(setMdiParent);
                this.Invoke(s, new object[] { mdiParentForm });
            }
            else
            {

                this.MdiParent = mdiParentForm;

            }
        }
        private void setTitle(string title)
        {
            if (this.InvokeRequired)
            {
                Simple<string> s = new Simple<string>(setTitle);
                this.Invoke(s, new object[] { title });
            }
            else
            {
                this.Text = title;
            }
        }
        private void setModelContent(string modelContent)
        {
            if (this.InvokeRequired)
            {
                Simple<string> s = new Simple<string>(setModelContent);
                this.Invoke(s, new object[] { modelContent });
            }
            else
            {
                this.memoEdit1.Text = modelContent;
            }
        }
        new public void Show()
        {
            if (this.InvokeRequired)
            {
                Simple s = new Simple(Show);
                this.Invoke(s, null);
            }
            else
            {
                base.Show();
            }
        }

        private void btnExecuteSql_Click(object sender, EventArgs e)
        {
            try
            {
                DNCCFrameWork.DataAccess.IDbHelper db = new DNCCFrameWork.DataAccess.DbFactory(dbConfigInfo.ConnectionString.Trim(new char[] { '"' }), Utils.CodeGenHelper.GetDbProviderString(dbConfigInfo.DbType)).IDbHelper;
                string[] sqls = this.memoEdit1.Text.Trim().Replace("\r", "").Split(new string[] { "--MQ TG" },StringSplitOptions.RemoveEmptyEntries);
                foreach (string sql in sqls)
                {
                    db.ExecuteNonQuery(sql);
                }
                MessageBox.Show("执行成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
