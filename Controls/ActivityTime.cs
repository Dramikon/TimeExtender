using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeExtender.Entities;

namespace TimeExtender
{
    public partial class ActivityTime : UserControl
    {
        public LogTimeItem LogItem { get; private set; }
        public event EventHandler RemoveButtonClicked;
        public event EventHandler AddButtonClicked;
        
        public TimeSpan AllLoggedTime
        {
            get { return timePickerAll.Time; }
            set { timePickerAll.Time = value; }
        }

        public string Description
        {
            get;
            set;
        }

        public string Name 
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        
        public ActivityTime(LogTimeItem item)
        {
            InitializeComponent();

            LogItem = item;
            timePickerAll.Time = LogItem.LoggedTime;
            Name = LogItem.ActivityID;
        }      

        private void btnLogTime_Click(object sender, EventArgs e)
        {
            timePickerAll.Time += timePicker.Time;
            LogItem.LoggedTime += timePicker.Time;

            if (AddButtonClicked != null)
            {
                AddButtonClicked(this, e);
            }
        }

        private void ActivityTime_Load(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (RemoveButtonClicked != null)
            {
                RemoveButtonClicked(this, e);
            }
        }

       
    }
}
