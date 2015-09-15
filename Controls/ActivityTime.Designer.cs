namespace TimeExtender
{
    partial class ActivityTime
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityTime));
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnLogTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timePicker = new TimeExtender.TimeSpanPicker();
            this.timePickerAll = new TimeExtender.TimeSpanPicker();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(45, 7);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(208, 26);
            this.tbName.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnRemove.Image")));
            this.btnRemove.Location = new System.Drawing.Point(0, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(39, 41);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnLogTime
            // 
            this.btnLogTime.Image = ((System.Drawing.Image)(resources.GetObject("btnLogTime.Image")));
            this.btnLogTime.Location = new System.Drawing.Point(412, 1);
            this.btnLogTime.Name = "btnLogTime";
            this.btnLogTime.Size = new System.Drawing.Size(41, 41);
            this.btnLogTime.TabIndex = 3;
            this.btnLogTime.UseVisualStyleBackColor = true;
            this.btnLogTime.Click += new System.EventHandler(this.btnLogTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(464, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "All";
            // 
            // timePicker
            // 
            this.timePicker.AutoSize = true;
            this.timePicker.Location = new System.Drawing.Point(259, 3);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(160, 34);
            this.timePicker.TabIndex = 6;
            this.timePicker.Time = System.TimeSpan.Parse("00:30:00");
            // 
            // timePickerAll
            // 
            this.timePickerAll.AutoSize = true;
            this.timePickerAll.Enabled = false;
            this.timePickerAll.Location = new System.Drawing.Point(496, 3);
            this.timePickerAll.Name = "timePickerAll";
            this.timePickerAll.Size = new System.Drawing.Size(160, 34);
            this.timePickerAll.TabIndex = 7;
            this.timePickerAll.Time = System.TimeSpan.Parse("00:30:00");
            // 
            // ActivityTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timePickerAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogTime);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.timePicker);
            this.Name = "ActivityTime";
            this.Size = new System.Drawing.Size(649, 45);
            this.Load += new System.EventHandler(this.ActivityTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnLogTime;
        private System.Windows.Forms.Label label1;
        private TimeSpanPicker timePicker;
        private TimeSpanPicker timePickerAll;
    }
}
