namespace TimeExtender
{
    partial class TimeSpanPicker
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
            this.numHH = new System.Windows.Forms.NumericUpDown();
            this.numMM = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMM)).BeginInit();
            this.SuspendLayout();
            // 
            // numHH
            // 
            this.numHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numHH.Location = new System.Drawing.Point(4, 4);
            this.numHH.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHH.Name = "numHH";
            this.numHH.Size = new System.Drawing.Size(42, 26);
            this.numHH.TabIndex = 0;
            this.numHH.ValueChanged += new System.EventHandler(this.numHH_ValueChanged);
            // 
            // numMM
            // 
            this.numMM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numMM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMM.Location = new System.Drawing.Point(81, 4);
            this.numMM.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMM.Name = "numMM";
            this.numMM.Size = new System.Drawing.Size(42, 26);
            this.numMM.TabIndex = 1;
            this.numMM.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numMM.ValueChanged += new System.EventHandler(this.numMM_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "HH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MM";
            // 
            // TimeSpanPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numMM);
            this.Controls.Add(this.numHH);
            this.Name = "TimeSpanPicker";
            this.Size = new System.Drawing.Size(160, 34);
            ((System.ComponentModel.ISupportInitialize)(this.numHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numHH;
        private System.Windows.Forms.NumericUpDown numMM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}
