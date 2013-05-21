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
            ((System.ComponentModel.ISupportInitialize)(this.CompanyContainer)).BeginInit();
            this.CompanyContainer.Panel1.SuspendLayout();
            this.CompanyContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // CompanyContainer
            // 
            this.CompanyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyContainer.Location = new System.Drawing.Point(0, 0);
            this.CompanyContainer.Name = "CompanyContainer";
            // 
            // CompanyContainer.Panel1
            // 
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyFilter);
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyBox);
            this.CompanyContainer.Size = new System.Drawing.Size(508, 375);
            this.CompanyContainer.SplitterDistance = 169;
            this.CompanyContainer.TabIndex = 0;
            // 
            // CompanyBox
            // 
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(3, 25);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(163, 342);
            this.CompanyBox.TabIndex = 0;
            // 
            // CompanyFilter
            // 
            this.CompanyFilter.Location = new System.Drawing.Point(4, 4);
            this.CompanyFilter.Name = "CompanyFilter";
            this.CompanyFilter.Size = new System.Drawing.Size(162, 20);
            this.CompanyFilter.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)(this.CompanyContainer)).EndInit();
            this.CompanyContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer CompanyContainer;
        private System.Windows.Forms.ListBox CompanyBox;
        private System.Windows.Forms.TextBox CompanyFilter;
    }
}
