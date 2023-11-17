namespace AuthSystem.Component
{
    partial class DateTimeField
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FieldDate = new System.Windows.Forms.DateTimePicker();
            this.FieldTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // FieldDate
            // 
            this.FieldDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldDate.CustomFormat = "MMMMdd, yyyy";
            this.FieldDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FieldDate.Location = new System.Drawing.Point(10, 25);
            this.FieldDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.FieldDate.Name = "FieldDate";
            this.FieldDate.Size = new System.Drawing.Size(160, 20);
            this.FieldDate.TabIndex = 2;
            this.FieldDate.ValueChanged += new System.EventHandler(this.FieldDateTime_ValueChanged);
            // 
            // FieldTime
            // 
            this.FieldTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldTime.CustomFormat = "hh:mm tt";
            this.FieldTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.FieldTime.Location = new System.Drawing.Point(180, 25);
            this.FieldTime.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.FieldTime.Name = "FieldTime";
            this.FieldTime.ShowUpDown = true;
            this.FieldTime.Size = new System.Drawing.Size(90, 20);
            this.FieldTime.TabIndex = 3;
            this.FieldTime.ValueChanged += new System.EventHandler(this.FieldTime_ValueChanged);
            // 
            // DateTimeField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.FieldTime);
            this.Controls.Add(this.FieldDate);
            this.Name = "DateTimeField";
            this.Controls.SetChildIndex(this.FieldDate, 0);
            this.Controls.SetChildIndex(this.FieldTime, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker FieldDate;
        private System.Windows.Forms.DateTimePicker FieldTime;
    }
}
