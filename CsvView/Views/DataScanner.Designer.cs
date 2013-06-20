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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lowValue = new System.Windows.Forms.TextBox();
            this.highValue = new System.Windows.Forms.TextBox();
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(455, 252);
            this.flowLayoutPanel1.TabIndex = 2;
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
            this.highValue.Name = "highValue";
            this.highValue.Size = new System.Drawing.Size(34, 20);
            this.highValue.TabIndex = 4;
            // 
            // DataScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.highValue);
            this.Controls.Add(this.lowValue);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.FilterSelectComboBox);
            this.Controls.Add(this.AddFilterBtn);
            this.Name = "DataScanner";
            this.Size = new System.Drawing.Size(461, 281);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddFilterBtn;
        private System.Windows.Forms.ComboBox FilterSelectComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox lowValue;
        private System.Windows.Forms.TextBox highValue;
    }
}
