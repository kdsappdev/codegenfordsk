using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeGenForDsk.CodeGenForDsk
{
    public partial class ModelForm : Form
    {
        string modelContent = "";
        public ModelForm(Form mdiParentForm, string str, string title)
        {
            InitializeComponent();
            setMdiParent(mdiParentForm);
            modelContent = str;
            setTitle(title);
            setModelContent(modelContent);
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
    }
}
