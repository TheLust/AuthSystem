namespace AuthSystem.Component
{
    partial class ComboField<T>
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
            this.FieldComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FieldComboBox
            // 
            this.FieldComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldComboBox.FormattingEnabled = true;
            this.FieldComboBox.Location = new System.Drawing.Point(10, 25);
            this.FieldComboBox.Name = "FieldComboBox";
            this.FieldComboBox.Size = new System.Drawing.Size(260, 21);
            this.FieldComboBox.TabIndex = 5;
            this.FieldComboBox.SelectedIndexChanged += new System.EventHandler(this.FieldComboBox_SelectedIndexChanged);
            // 
            // ComboField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.FieldComboBox);
            this.Name = "ComboField";
            this.Load += new System.EventHandler(this.ComboField_Load);
            this.Controls.SetChildIndex(this.FieldComboBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FieldComboBox;
    }
}
