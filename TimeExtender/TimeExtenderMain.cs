using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeExtender.Entities;
using TimeExtender.Service;

using TimeExtender.Extensions;
using System.Security.Principal;

namespace TimeExtender
{
    public partial class TimeExtenderMain : Form
    {
        //private readonly DateTime OneDay = new DateTime(0, 0, 1);
        private bool _formChanged = false;
        private void FormChanged() 
        {
            _formChanged = true;

            FillAllTime();
        }

        private void FillAllTime()
        {
            timePickerAll.Time = TimeSpan.FromDays(0);
            foreach (var item in flowPanel.Controls)
            {
                timePickerAll.Time += ((ActivityTime)item).AllLoggedTime;
            }
        }

        public TimeExtenderMain()
        {
            InitializeComponent();

            //this.AutoScroll = true;
            //flowPanel.AutoSize = true;
            //flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowPanel.AutoScroll = true;
            flowPanel.VerticalScroll.Visible = true;
            flowPanel.VerticalScroll.Enabled = true;

            LoadLogTimeItems(dateTimePicker.Value.Date);
            LoadActivities();
            FillAllTime();
            
            var user = LogItemsService.GetOwner();
            if(string.IsNullOrEmpty(user))
            {
                user = WindowsIdentity.GetCurrent().Name;
                LogItemsService.SetOwner(user);
            }
            tbOwner.Text = user;
            _formChanged = false;
        }

        

        public void LoadActivities()
        {
            var items = LogItemsService.GetActivities();
            lvActivities.Items.Clear();

            foreach (var item in items)
            {
                lvActivities.Items.Add(new ListViewItem() { Text = item.Name, ToolTipText = item.Description  });
            }
        }

        public void LoadLogTimeItems(DateTime date)
        {
            var items = LogItemsService.GetItemsByDate(date);
            flowPanel.Controls.Clear();
            foreach (var item in items)
            {
                var control = new ActivityTime(item);
                control.RemoveButtonClicked += control_RemoveButtonClicked;
                control.AddButtonClicked += control_AddButtonClicked;
                flowPanel.Controls.Add(control);
            }
        }

        public void control_AddButtonClicked(object sender, EventArgs e)
        {
            FormChanged();
        }

        public void control_RemoveButtonClicked(object sender, EventArgs e)
        {
            flowPanel.Controls.Remove((Control)sender);
            LogItemsService.Remove(((ActivityTime)sender).LogItem);

            FormChanged();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(-1);
            LoadLogTimeItems(dateTimePicker.Value.Date);
            FillAllTime();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
            LoadLogTimeItems(dateTimePicker.Value.Date);
            FillAllTime();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LogItemsService.Save();
            _formChanged = false;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now.Date;
            LoadLogTimeItems(dateTimePicker.Value.Date);
            FillAllTime();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadLogTimeItems(dateTimePicker.Value.Date);
            FillAllTime();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_formChanged)
            {
                var result = MessageBox.Show("Do you want to save your changes", "Time Extender", MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    LogItemsService.Save();
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void lvActivities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lvActivities.SelectedItems.Count == 1)
            {
                var dialog = new AddActivityDialog();
                var selected = lvActivities.SelectedItems[0];
                dialog.Value = selected.Text;
                dialog.Descripton = selected.ToolTipText;

                var prevName = dialog.Value;

                dialog.Text = "Edit Activity";

                var result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    LogItemsService.RemoveActivityByName(prevName);

                    var activity = new Activity() { ID = dialog.Value, Name = dialog.Value, Description = dialog.Descripton };
                    LogItemsService.AddActivity(activity);

                    selected.Text = activity.Name;
                    selected.ToolTipText = activity.Description;

                    LoadLogTimeItems(dateTimePicker.Value.Date);
                    FillAllTime();

                    FormChanged();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new AddActivityDialog();
            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var activity = new Activity() { ID = dialog.Value, Name = dialog.Value, Description = dialog.Descripton };
                LogItemsService.AddActivity(activity);
                lvActivities.Items.Add(new ListViewItem() { Text = activity.Name, ToolTipText = activity.Description });
                FormChanged();
            }
        }

        private void lvActivities_KeyUp(object sender, KeyEventArgs e)
        {
            if (lvActivities.SelectedItems.Count == 1 && e.KeyCode == Keys.Delete)
            { 
                var item = lvActivities.SelectedItems[0];
                LogItemsService.RemoveActivityByName(item.Text);
                lvActivities.Items.Remove(item);

                FormChanged();
            }
        }

        private void btnAddLogItem_Click(object sender, EventArgs e)
        {
            if(lvActivities.SelectedItems.Count == 1)
            {
                var selected = lvActivities.SelectedItems[0];
                foreach (var item in flowPanel.Controls)
                {
                    if (((ActivityTime)item).Name == selected.Text)
                    {
                        return;
                    }
                }

                //flow panel doesn't contain such activity now
                //can add
                var logTime = new LogTimeItem();
                logTime.ActivityID = selected.Text;
                logTime.DayOfLogging = dateTimePicker.Value.Date;

                LogItemsService.AddLogItem(logTime);
                

                var control = new ActivityTime(logTime);
                control.RemoveButtonClicked += control_RemoveButtonClicked;
                control.AddButtonClicked += control_AddButtonClicked;
                flowPanel.Controls.Add(control);

                FormChanged();
            }
            
        }

        private void btnWeekReport_Click(object sender, EventArgs e)
        {
            if (saveReportDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExcelExporter.ExportReport(
                    LogItemsService.GetItemsByDateRange(dateTimePicker.Value.StartOfWeek(), 
                    dateTimePicker.Value.EndOfWeek()),
                    saveReportDialog.FileName, LogItemsService.GetOwner(), dateTimePicker.Value.StartOfWeek());
            }
        }

        private void tbOwner_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbOwner.Text))
            {
                LogItemsService.SetOwner(tbOwner.Text);
            }
            FormChanged();
        }
    }
}
