namespace CsvReaderModule.Views
{
    partial class VCompany
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
            this.CompanyContainer = new System.Windows.Forms.SplitContainer();
            this.CompanyBox = new System.Windows.Forms.ListBox();
            this.CompanyFilter = new System.Windows.Forms.TextBox();
            this.FinDataGrid = new System.Windows.Forms.DataGridView();
            this.CompanyTitle = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyContainer)).BeginInit();
            this.CompanyContainer.Panel1.SuspendLayout();
            this.CompanyContainer.Panel2.SuspendLayout();
            this.CompanyContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FinDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // CompanyContainer
            // 
            this.CompanyContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CompanyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyContainer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CompanyContainer.Location = new System.Drawing.Point(0, 0);
            this.CompanyContainer.Name = "CompanyContainer";
            // 
            // CompanyContainer.Panel1
            // 
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyFilter);
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyBox);
            this.CompanyContainer.Panel1MinSize = 150;
            // 
            // CompanyContainer.Panel2
            // 
            this.CompanyContainer.Panel2.Controls.Add(this.CompanyTitle);
            this.CompanyContainer.Panel2.Controls.Add(this.FinDataGrid);
            this.CompanyContainer.Panel2MinSize = 350;
            this.CompanyContainer.Size = new System.Drawing.Size(508, 375);
            this.CompanyContainer.SplitterDistance = 150;
            this.CompanyContainer.TabIndex = 0;
            // 
            // CompanyBox
            // 
            this.CompanyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(3, 25);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(144, 342);
            this.CompanyBox.TabIndex = 0;
            // 
            // CompanyFilter
            // 
            this.CompanyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyFilter.Location = new System.Drawing.Point(4, 4);
            this.CompanyFilter.Name = "CompanyFilter";
            this.CompanyFilter.Size = new System.Drawing.Size(143, 20);
            this.CompanyFilter.TabIndex = 1;
            // 
            // FinDataGrid
            // 
            this.FinDataGrid.AllowUserToAddRows = false;
            this.FinDataGrid.AllowUserToDeleteRows = false;
            this.FinDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FinDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.FinDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FinDataGrid.Location = new System.Drawing.Point(8, 60);
            this.FinDataGrid.Name = "FinDataGrid";
            this.FinDataGrid.ReadOnly = true;
            this.FinDataGrid.Size = new System.Drawing.Size(343, 228);
            this.FinDataGrid.TabIndex = 0;
            // 
            // CompanyTitle
            // 
            this.CompanyTitle.AutoSize = true;
            this.CompanyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CompanyTitle.Location = new System.Drawing.Point(3, 4);
            this.CompanyTitle.Name = "CompanyTitle";
            this.CompanyTitle.Size = new System.Drawing.Size(49, 25);
            this.CompanyTitle.TabIndex = 1;
            this.CompanyTitle.Text = "Title";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // VCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CompanyContainer);
            this.Name = "VCompany";
            this.Size = new System.Drawing.Size(508, 375);
            this.CompanyContainer.Panel1.ResumeLayout(false);
            this.CompanyContainer.Panel1.PerformLayout();
            this.CompanyContainer.Panel2.ResumeLayout(false);
            this.CompanyContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyContainer)).EndInit();
            this.CompanyContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FinDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer CompanyContainer;
        private System.Windows.Forms.ListBox CompanyBox;
        private System.Windows.Forms.TextBox CompanyFilter;
        private System.Windows.Forms.Label CompanyTitle;
        private System.Windows.Forms.DataGridView FinDataGrid;
        private System.Diagnostics.EventLog eventLog1;
    }
}
