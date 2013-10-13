namespace IDSA.Views.BasicViews
{
    partial class BasicDataControl
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
            this.actionBtn = new System.Windows.Forms.Button();
            this.companyBox = new System.Windows.Forms.ComboBox();
            this.reportsBox = new System.Windows.Forms.ComboBox();
            this.mainTabPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // actionBtn
            // 
            this.actionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionBtn.Location = new System.Drawing.Point(375, 3);
            this.actionBtn.Name = "actionBtn";
            this.actionBtn.Size = new System.Drawing.Size(75, 23);
            this.actionBtn.TabIndex = 3;
            this.actionBtn.Text = "Action";
            this.actionBtn.UseVisualStyleBackColor = true;
            // 
            // companyBox
            // 
            this.companyBox.FormattingEnabled = true;
            this.companyBox.Location = new System.Drawing.Point(3, 5);
            this.companyBox.Name = "companyBox";
            this.companyBox.Size = new System.Drawing.Size(120, 21);
            this.companyBox.TabIndex = 4;
            this.companyBox.SelectedIndexChanged += new System.EventHandler(this.companyBox_SelectedIndexChanged);
            // 
            // reportsBox
            // 
            this.reportsBox.FormattingEnabled = true;
            this.reportsBox.Location = new System.Drawing.Point(3, 32);
            this.reportsBox.Name = "reportsBox";
            this.reportsBox.Size = new System.Drawing.Size(120, 21);
            this.reportsBox.TabIndex = 5;
            this.reportsBox.SelectedIndexChanged += new System.EventHandler(this.reportsBox_SelectedIndexChanged);
            // 
            // mainTabPanel
            // 
            this.mainTabPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabPanel.Location = new System.Drawing.Point(3, 59);
            this.mainTabPanel.Name = "mainTabPanel";
            this.mainTabPanel.Size = new System.Drawing.Size(447, 219);
            this.mainTabPanel.TabIndex = 6;
            // 
            // BasicDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.mainTabPanel);
            this.Controls.Add(this.reportsBox);
            this.Controls.Add(this.companyBox);
            this.Controls.Add(this.actionBtn);
            this.Name = "BasicDataControl";
            this.Size = new System.Drawing.Size(453, 281);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button actionBtn;
        protected System.Windows.Forms.ComboBox companyBox;
        protected System.Windows.Forms.ComboBox reportsBox;
        private System.Windows.Forms.Panel mainTabPanel;
    }
}
