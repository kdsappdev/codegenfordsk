using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CodeGenForDsk
{
    public partial class CodeGenForm : Form
    {
        public CodeGenForm()
        {
            InitializeComponent();
             
            this.notifyIcon1.Text = this.Text;
            this.Icon = this.Icon;
        }

        #region notifyIcon
        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;            
        }
        private void CodeGenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }
        #endregion

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
