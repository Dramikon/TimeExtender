using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeExtender
{
    public partial class AddActivityDialog : Form
    {
        public string Value
        {
            get { return tbValue.Text; }
            set { tbValue.Text = value; }
        }

        public string Descripton
        {
            get { return tbDesc.Text; }
            set { tbDesc.Text = value; }
        }

        public AddActivityDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
