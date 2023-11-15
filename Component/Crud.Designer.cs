namespace AuthSystem.Component
{
    partial class Crud<T>
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.Form = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddSaveButton = new System.Windows.Forms.Button();
            this.AddCancelButton = new System.Windows.Forms.Button();
            this.UpdateSaveButton = new System.Windows.Forms.Button();
            this.UpdateCancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(3, 3);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(694, 305);
            this.Grid.TabIndex = 0;
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            this.Grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            // 
            // Form
            // 
            this.Form.Location = new System.Drawing.Point(3, 314);
            this.Form.Name = "Form";
            this.Form.Size = new System.Drawing.Size(300, 383);
            this.Form.TabIndex = 1;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.UpdateCancelButton);
            this.ButtonPanel.Controls.Add(this.UpdateSaveButton);
            this.ButtonPanel.Controls.Add(this.AddCancelButton);
            this.ButtonPanel.Controls.Add(this.AddSaveButton);
            this.ButtonPanel.Controls.Add(this.DeleteButton);
            this.ButtonPanel.Controls.Add(this.UpdateButton);
            this.ButtonPanel.Controls.Add(this.AddButton);
            this.ButtonPanel.Controls.Add(this.ReloadButton);
            this.ButtonPanel.Location = new System.Drawing.Point(309, 314);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(110, 200);
            this.ButtonPanel.TabIndex = 2;
            // 
            // ReloadButton
            // 
            this.ReloadButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReloadButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReloadButton.Location = new System.Drawing.Point(5, 5);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(100, 35);
            this.ReloadButton.TabIndex = 9;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Location = new System.Drawing.Point(5, 46);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 35);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(5, 87);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(100, 35);
            this.UpdateButton.TabIndex = 11;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(5, 128);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 35);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddSaveButton
            // 
            this.AddSaveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddSaveButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSaveButton.Location = new System.Drawing.Point(5, 46);
            this.AddSaveButton.Name = "AddSaveButton";
            this.AddSaveButton.Size = new System.Drawing.Size(100, 35);
            this.AddSaveButton.TabIndex = 13;
            this.AddSaveButton.Text = "Save";
            this.AddSaveButton.UseVisualStyleBackColor = true;
            this.AddSaveButton.Visible = false;
            this.AddSaveButton.Click += new System.EventHandler(this.AddSaveButton_Click);
            // 
            // AddCancelButton
            // 
            this.AddCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddCancelButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCancelButton.Location = new System.Drawing.Point(5, 87);
            this.AddCancelButton.Name = "AddCancelButton";
            this.AddCancelButton.Size = new System.Drawing.Size(100, 35);
            this.AddCancelButton.TabIndex = 14;
            this.AddCancelButton.Text = "Cancel";
            this.AddCancelButton.UseVisualStyleBackColor = true;
            this.AddCancelButton.Visible = false;
            this.AddCancelButton.Click += new System.EventHandler(this.AddCancelButton_Click);
            // 
            // UpdateSaveButton
            // 
            this.UpdateSaveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UpdateSaveButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateSaveButton.Location = new System.Drawing.Point(5, 87);
            this.UpdateSaveButton.Name = "UpdateSaveButton";
            this.UpdateSaveButton.Size = new System.Drawing.Size(100, 35);
            this.UpdateSaveButton.TabIndex = 15;
            this.UpdateSaveButton.Text = "Save";
            this.UpdateSaveButton.UseVisualStyleBackColor = true;
            this.UpdateSaveButton.Visible = false;
            this.UpdateSaveButton.Click += new System.EventHandler(this.UpdateSaveButton_Click);
            // 
            // UpdateCancelButton
            // 
            this.UpdateCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UpdateCancelButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateCancelButton.Location = new System.Drawing.Point(5, 128);
            this.UpdateCancelButton.Name = "UpdateCancelButton";
            this.UpdateCancelButton.Size = new System.Drawing.Size(100, 35);
            this.UpdateCancelButton.TabIndex = 16;
            this.UpdateCancelButton.Text = "Cancel";
            this.UpdateCancelButton.UseVisualStyleBackColor = true;
            this.UpdateCancelButton.Visible = false;
            this.UpdateCancelButton.Click += new System.EventHandler(this.UpdateCancelButton_Click);
            // 
            // Crud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.Form);
            this.Controls.Add(this.Grid);
            this.Name = "Crud";
            this.Size = new System.Drawing.Size(700, 700);
            this.Load += new System.EventHandler(this.Crud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.FlowLayoutPanel Form;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button AddSaveButton;
        private System.Windows.Forms.Button AddCancelButton;
        private System.Windows.Forms.Button UpdateSaveButton;
        private System.Windows.Forms.Button UpdateCancelButton;
    }
}
