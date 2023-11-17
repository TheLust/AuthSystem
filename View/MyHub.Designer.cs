namespace AuthSystem.View
{
    partial class MyHub
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
            this.Grid = new System.Windows.Forms.DataGridView();
            this.StartButton = new System.Windows.Forms.Button();
            this.CurrentDate = new System.Windows.Forms.DateTimePicker();
            this.StopButton = new System.Windows.Forms.Button();
            this.AssignmentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(12, 98);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(776, 340);
            this.Grid.TabIndex = 0;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(12, 38);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(174, 35);
            this.StartButton.TabIndex = 10;
            this.StartButton.Text = "Start Working";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CurrentDate
            // 
            this.CurrentDate.Location = new System.Drawing.Point(12, 12);
            this.CurrentDate.Name = "CurrentDate";
            this.CurrentDate.Size = new System.Drawing.Size(200, 20);
            this.CurrentDate.TabIndex = 11;
            this.CurrentDate.ValueChanged += new System.EventHandler(this.CurrentDate_ValueChanged);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StopButton.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Location = new System.Drawing.Point(12, 38);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(174, 35);
            this.StopButton.TabIndex = 12;
            this.StopButton.Text = "Stop Working";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // AssignmentPanel
            // 
            this.AssignmentPanel.Location = new System.Drawing.Point(236, 12);
            this.AssignmentPanel.Name = "AssignmentPanel";
            this.AssignmentPanel.Size = new System.Drawing.Size(552, 80);
            this.AssignmentPanel.TabIndex = 13;
            // 
            // MyHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AssignmentPanel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.CurrentDate);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Grid);
            this.Name = "MyHub";
            this.Text = "MyHub";
            this.Load += new System.EventHandler(this.MyHub_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.DateTimePicker CurrentDate;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Panel AssignmentPanel;
    }
}