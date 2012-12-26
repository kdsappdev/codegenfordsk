using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CodeGenForDsk.CodeGenForDsk
{
    public partial class MdiPanel : Panel
    {
        public MdiPanel()
        {
            InitializeComponent();
            base.Controls.Add(this.ctlClient);
        }
        private Form mdiForm;
        private MdiClient ctlClient = new MdiClient();


        public Form MdiForm
        {
            get
            {
                setMdiFormBySync();
                return this.mdiForm;
            }
        }
        delegate void Simple();
        private void setMdiFormBySync()
        {
            if (this.InvokeRequired)
            {
                Simple s = new Simple(setMdiFormBySync);
                this.Invoke(s,null);
            }
            else
            {
                if (this.mdiForm == null)
                {
                    this.mdiForm = new Form();
                    System.Reflection.FieldInfo field = typeof(Form).GetField("ctlClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    field.SetValue(this.mdiForm, this.ctlClient);
                }
            }

        }
    }

}
