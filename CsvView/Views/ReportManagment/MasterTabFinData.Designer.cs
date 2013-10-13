namespace IDSA.Presenters.ReportManagment
{
    partial class MasterTabFinData
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
            this.components = new System.ComponentModel.Container();
            this.financialDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterTabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.financialDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // masterFinancialDataTab
            // 
            this.masterTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.masterTabControl.Location = new System.Drawing.Point(0, 0);
            this.masterTabControl.Name = "masterFinancialDataTab";
            this.masterTabControl.SelectedIndex = 0;
            this.masterTabControl.Size = new System.Drawing.Size(595, 382);
            this.masterTabControl.TabIndex = 0;
            // 
            // MasterTabFinData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.masterTabControl);
            this.Name = "MasterTabFinData";
            this.Size = new System.Drawing.Size(595, 382);
            ((System.ComponentModel.ISupportInitialize)(this.financialDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource financialDataBindingSource;
        private System.Windows.Forms.TabControl masterTabControl;
    }
}
