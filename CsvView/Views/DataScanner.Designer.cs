namespace IDSA.Views
{
    partial class DataScanner
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
            this.AddFilterBtn = new System.Windows.Forms.Button();
            this.FilterSelectComboBox = new System.Windows.Forms.ComboBox();
            this.filterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lowValue = new System.Windows.Forms.TextBox();
            this.highValue = new System.Windows.Forms.TextBox();
            this.scanBtn = new System.Windows.Forms.Button();
            this.dgvPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.filterPanel.SuspendLayout();
            this.dgvPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddFilterBtn
            // 
            this.AddFilterBtn.Location = new System.Drawing.Point(205, 2);
            this.AddFilterBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AddFilterBtn.Name = "AddFilterBtn";
            this.AddFilterBtn.Size = new System.Drawing.Size(75, 23);
            this.AddFilterBtn.TabIndex = 0;
            this.AddFilterBtn.Text = "Add";
            this.AddFilterBtn.UseVisualStyleBackColor = true;
            this.AddFilterBtn.Click += new System.EventHandler(this.AddFilterBtn_Click);
            // 
            // FilterSelectComboBox
            // 
            this.FilterSelectComboBox.FormattingEnabled = true;
            this.FilterSelectComboBox.Location = new System.Drawing.Point(3, 2);
            this.FilterSelectComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.FilterSelectComboBox.Name = "FilterSelectComboBox";
            this.FilterSelectComboBox.Size = new System.Drawing.Size(121, 21);
            this.FilterSelectComboBox.TabIndex = 1;
            // 
            // filterPanel
            // 
            this.filterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Location = new System.Drawing.Point(6, 26);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(615, 94);
            this.filterPanel.TabIndex = 2;
            // 
            // lowValue
            // 
            this.lowValue.Location = new System.Drawing.Point(128, 2);
            this.lowValue.Name = "lowValue";
            this.lowValue.Size = new System.Drawing.Size(34, 20);
            this.lowValue.TabIndex = 3;
            // 
            // highValue
            // 
            this.highValue.Location = new System.Drawing.Point(168, 2);
            this.highValue.Name = "fieldValue";
            this.highValue.Size = new System.Drawing.Size(34, 20);
            this.highValue.TabIndex = 4;
            // 
            // scanBtn
            // 
            this.scanBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scanBtn.Location = new System.Drawing.Point(546, 2);
            this.scanBtn.Margin = new System.Windows.Forms.Padding(0);
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(75, 23);
            this.scanBtn.TabIndex = 5;
            this.scanBtn.Text = "Scan";
            this.scanBtn.UseVisualStyleBackColor = true;
            this.scanBtn.Click += new System.EventHandler(this.scanBtn_Click);
            // 
            // dgvPanel
            // 
            this.dgvPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvPanel.Location = new System.Drawing.Point(6, 126);
            this.dgvPanel.Name = "dgvPanel";
            this.dgvPanel.Size = new System.Drawing.Size(615, 250);
            this.dgvPanel.TabIndex = 4;
            // 
            // DataScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scanBtn);
            this.Controls.Add(this.dgvPanel);
            this.Controls.Add(this.highValue);
            this.Controls.Add(this.lowValue);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.FilterSelectComboBox);
            this.Controls.Add(this.AddFilterBtn);
            this.Name = "DataScanner";
            this.Size = new System.Drawing.Size(624, 381);
            this.filterPanel.ResumeLayout(false);
            this.dgvPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddFilterBtn;
        private System.Windows.Forms.ComboBox FilterSelectComboBox;
        private System.Windows.Forms.FlowLayoutPanel filterPanel;
        private System.Windows.Forms.TextBox lowValue;
        private System.Windows.Forms.TextBox highValue;
        private System.Windows.Forms.Button scanBtn;
        private System.Windows.Forms.FlowLayoutPanel dgvPanel;
    }
}
