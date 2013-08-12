namespace IDSA
{
    partial class Shell
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainStripMenu = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Location = new System.Drawing.Point(12, 27);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(631, 859);
            this.mainTabControl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.mainStripMenu.Location = new System.Drawing.Point(0, 0);
            this.mainStripMenu.Name = "mainStripMenu";
            this.mainStripMenu.Size = new System.Drawing.Size(646, 24);
            this.mainStripMenu.TabIndex = 1;
            this.mainStripMenu.Text = "mainStripMenu";
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 887);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainStripMenu);
            this.MainMenuStrip = this.mainStripMenu;
            this.Name = "Shell";
            this.Text = "Shell";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.MenuStrip mainStripMenu;
    }
}

