namespace AuthSystem.Component
{
    partial class NumericField
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
            this.FieldNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.FieldNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldNumeric
            // 
            this.FieldNumeric.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldNumeric.Location = new System.Drawing.Point(10, 25);
            this.FieldNumeric.Name = "FieldNumeric";
            this.FieldNumeric.Size = new System.Drawing.Size(260, 20);
            this.FieldNumeric.TabIndex = 2;
            this.FieldNumeric.ValueChanged += new System.EventHandler(this.FieldNumeric_ValueChanged);
            // 
            // NumericField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.FieldNumeric);
            this.Name = "NumericField";
            this.Controls.SetChildIndex(this.FieldNumeric, 0);
            ((System.ComponentModel.ISupportInitialize)(this.FieldNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown FieldNumeric;
    }
}
