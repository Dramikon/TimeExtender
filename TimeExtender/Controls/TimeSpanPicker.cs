using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeExtender
{
    public partial class TimeSpanPicker : UserControl
    {
        public TimeSpanPicker()
        {
            InitializeComponent();
        }

        public TimeSpan Time
        {
            get { return new TimeSpan((int)numHH.Value, (int)numMM.Value, 0); }
            set 
            {
                numHH.Value = value.Hours;
                numMM.Value = value.Minutes;
            }
        }

        private void numHH_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numMM_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
