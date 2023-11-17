namespace AuthSystem.View
{
    partial class MySalary
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
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.BonusGrid = new System.Windows.Forms.DataGridView();
            this.SalaryGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(12, 12);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(776, 209);
            this.Grid.TabIndex = 0;
            // 
            // BonusGrid
            // 
            this.BonusGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BonusGrid.Location = new System.Drawing.Point(12, 227);
            this.BonusGrid.Name = "BonusGrid";
            this.BonusGrid.Size = new System.Drawing.Size(776, 209);
            this.BonusGrid.TabIndex = 1;
            // 
            // SalaryGrid
            // 
            this.SalaryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SalaryGrid.Location = new System.Drawing.Point(12, 442);
            this.SalaryGrid.Name = "SalaryGrid";
            this.SalaryGrid.Size = new System.Drawing.Size(776, 209);
            this.SalaryGrid.TabIndex = 2;
            // 
            // MySalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 674);
            this.Controls.Add(this.SalaryGrid);
            this.Controls.Add(this.BonusGrid);
            this.Controls.Add(this.Grid);
            this.Name = "MySalary";
            this.Text = "MySalary";
            this.Load += new System.EventHandler(this.MySalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalaryGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.DataGridView BonusGrid;
        private System.Windows.Forms.DataGridView SalaryGrid;
    }
}