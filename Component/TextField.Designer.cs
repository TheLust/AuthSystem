﻿namespace AuthSystem.Component
{
    partial class TextField
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
            this.FieldTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FieldTextBox
            // 
            this.FieldTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldTextBox.Location = new System.Drawing.Point(10, 25);
            this.FieldTextBox.Name = "FieldTextBox";
            this.FieldTextBox.Size = new System.Drawing.Size(260, 20);
            this.FieldTextBox.TabIndex = 2;
            this.FieldTextBox.TextChanged += new System.EventHandler(this.FieldTextBox_TextChanged);
            // 
            // TextField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.FieldTextBox);
            this.Name = "TextField";
            this.Controls.SetChildIndex(this.FieldTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FieldTextBox;
    }
}
