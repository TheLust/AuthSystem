namespace AuthSystem.Component
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernamePanel = new System.Windows.Forms.Panel();
            this.FieldError = new System.Windows.Forms.Label();
            this.FieldTextBox = new System.Windows.Forms.TextBox();
            this.FieldLabel = new System.Windows.Forms.Label();
            this.UsernamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernamePanel
            // 
            this.UsernamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernamePanel.AutoSize = true;
            this.UsernamePanel.Controls.Add(this.FieldError);
            this.UsernamePanel.Controls.Add(this.FieldTextBox);
            this.UsernamePanel.Controls.Add(this.FieldLabel);
            this.UsernamePanel.Location = new System.Drawing.Point(5, 5);
            this.UsernamePanel.MaximumSize = new System.Drawing.Size(270, 80);
            this.UsernamePanel.MinimumSize = new System.Drawing.Size(270, 60);
            this.UsernamePanel.Name = "UsernamePanel";
            this.UsernamePanel.Size = new System.Drawing.Size(270, 60);
            this.UsernamePanel.TabIndex = 1;
            // 
            // FieldError
            // 
            this.FieldError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldError.AutoEllipsis = true;
            this.FieldError.AutoSize = true;
            this.FieldError.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldError.ForeColor = System.Drawing.Color.Red;
            this.FieldError.Location = new System.Drawing.Point(5, 40);
            this.FieldError.MaximumSize = new System.Drawing.Size(260, 40);
            this.FieldError.MinimumSize = new System.Drawing.Size(260, 20);
            this.FieldError.Name = "FieldError";
            this.FieldError.Size = new System.Drawing.Size(260, 20);
            this.FieldError.TabIndex = 2;
            // 
            // FieldTextBox
            // 
            this.FieldTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldTextBox.Location = new System.Drawing.Point(5, 20);
            this.FieldTextBox.Name = "FieldTextBox";
            this.FieldTextBox.Size = new System.Drawing.Size(260, 20);
            this.FieldTextBox.TabIndex = 1;
            this.FieldTextBox.TextChanged += new System.EventHandler(this.FieldTextBox_TextChanged);
            // 
            // FieldLabel
            // 
            this.FieldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FieldLabel.Location = new System.Drawing.Point(5, 0);
            this.FieldLabel.Name = "FieldLabel";
            this.FieldLabel.Size = new System.Drawing.Size(260, 20);
            this.FieldLabel.TabIndex = 0;
            this.FieldLabel.Text = "Label";
            this.FieldLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.UsernamePanel);
            this.MaximumSize = new System.Drawing.Size(280, 90);
            this.MinimumSize = new System.Drawing.Size(280, 70);
            this.Name = "TextField";
            this.Size = new System.Drawing.Size(280, 70);
            this.UsernamePanel.ResumeLayout(false);
            this.UsernamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel UsernamePanel;
        private System.Windows.Forms.Label FieldError;
        private System.Windows.Forms.TextBox FieldTextBox;
        private System.Windows.Forms.Label FieldLabel;
    }
}
