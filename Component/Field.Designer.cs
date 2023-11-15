namespace AuthSystem.Component
{
    partial class Field
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
            this.Panel = new System.Windows.Forms.Panel();
            this.FieldError = new System.Windows.Forms.Label();
            this.FieldLabel = new System.Windows.Forms.Label();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.AutoSize = true;
            this.Panel.Controls.Add(this.FieldError);
            this.Panel.Controls.Add(this.FieldLabel);
            this.Panel.Location = new System.Drawing.Point(5, 5);
            this.Panel.MaximumSize = new System.Drawing.Size(270, 80);
            this.Panel.MinimumSize = new System.Drawing.Size(270, 60);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(270, 60);
            this.Panel.TabIndex = 1;
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
            // Field
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Panel);
            this.MaximumSize = new System.Drawing.Size(280, 90);
            this.MinimumSize = new System.Drawing.Size(280, 70);
            this.Name = "Field";
            this.Size = new System.Drawing.Size(280, 70);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label FieldError;
        private System.Windows.Forms.Label FieldLabel;
    }
}
