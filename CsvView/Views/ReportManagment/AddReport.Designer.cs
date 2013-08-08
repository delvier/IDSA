namespace IDSA.Views.ReportManagment
{
    partial class AddReport
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
            this.reportAddBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportAddBtn
            // 
            this.reportAddBtn.Location = new System.Drawing.Point(3, 3);
            this.reportAddBtn.Name = "reportAddBtn";
            this.reportAddBtn.Size = new System.Drawing.Size(75, 23);
            this.reportAddBtn.TabIndex = 0;
            this.reportAddBtn.Text = "add";
            this.reportAddBtn.UseVisualStyleBackColor = true;
            // 
            // AddReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportAddBtn);
            this.Name = "AddReport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reportAddBtn;
    }
}
