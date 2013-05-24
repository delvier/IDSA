namespace IDSA.Views
{
    partial class DataFromHtmlView
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
            this.label1 = new System.Windows.Forms.Label();
            this.compIDTextBox = new System.Windows.Forms.TextBox();
            this.searchExchangeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.exchangeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company ID:";
            // 
            // compIDTextBox
            // 
            this.compIDTextBox.Location = new System.Drawing.Point(15, 39);
            this.compIDTextBox.Name = "compIDTextBox";
            this.compIDTextBox.Size = new System.Drawing.Size(127, 22);
            this.compIDTextBox.TabIndex = 1;
            // 
            // searchExchangeBtn
            // 
            this.searchExchangeBtn.Location = new System.Drawing.Point(16, 66);
            this.searchExchangeBtn.Name = "searchExchangeBtn";
            this.searchExchangeBtn.Size = new System.Drawing.Size(126, 27);
            this.searchExchangeBtn.TabIndex = 2;
            this.searchExchangeBtn.Text = "search exchange";
            this.searchExchangeBtn.UseVisualStyleBackColor = true;
            this.searchExchangeBtn.Click += new System.EventHandler(this.searchExchangeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Actual Exchange:";
            // 
            // exchangeLabel
            // 
            this.exchangeLabel.AutoSize = true;
            this.exchangeLabel.ForeColor = System.Drawing.Color.Red;
            this.exchangeLabel.Location = new System.Drawing.Point(26, 138);
            this.exchangeLabel.Name = "exchangeLabel";
            this.exchangeLabel.Size = new System.Drawing.Size(104, 17);
            this.exchangeLabel.TabIndex = 5;
            this.exchangeLabel.Text = "";
            // 
            // DataFromHtmlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exchangeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchExchangeBtn);
            this.Controls.Add(this.compIDTextBox);
            this.Controls.Add(this.label1);
            this.Name = "DataFromHtmlView";
            this.Size = new System.Drawing.Size(808, 532);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox compIDTextBox;
        private System.Windows.Forms.Button searchExchangeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label exchangeLabel;
    }
}
