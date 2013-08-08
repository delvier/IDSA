namespace IDSA.Views.ReportManagment
{
    partial class EditReport
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
            this.reportEditBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportEditBtn
            // 
            this.reportEditBtn.Location = new System.Drawing.Point(4, 4);
            this.reportEditBtn.Name = "reportEditBtn";
            this.reportEditBtn.Size = new System.Drawing.Size(75, 23);
            this.reportEditBtn.TabIndex = 0;
            this.reportEditBtn.Text = "Edit";
            this.reportEditBtn.UseVisualStyleBackColor = true;
            // 
            // EditReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportEditBtn);
            this.Name = "EditReport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button reportEditBtn;
    }
}
