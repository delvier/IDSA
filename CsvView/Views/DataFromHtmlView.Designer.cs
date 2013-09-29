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
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.addReportsToDb = new System.Windows.Forms.Button();
            this.errors = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company ID:";
            // 
            // compIDTextBox
            // 
            this.compIDTextBox.Location = new System.Drawing.Point(11, 32);
            this.compIDTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.compIDTextBox.Name = "compIDTextBox";
            this.compIDTextBox.Size = new System.Drawing.Size(96, 20);
            this.compIDTextBox.TabIndex = 1;
            // 
            // searchExchangeBtn
            // 
            this.searchExchangeBtn.Location = new System.Drawing.Point(12, 54);
            this.searchExchangeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchExchangeBtn.Name = "searchExchangeBtn";
            this.searchExchangeBtn.Size = new System.Drawing.Size(94, 22);
            this.searchExchangeBtn.TabIndex = 2;
            this.searchExchangeBtn.Text = "search exchange";
            this.searchExchangeBtn.UseVisualStyleBackColor = true;
            this.searchExchangeBtn.Click += new System.EventHandler(this.searchExchangeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Actual Exchange:";
            // 
            // exchangeLabel
            // 
            this.exchangeLabel.AutoSize = true;
            this.exchangeLabel.ForeColor = System.Drawing.Color.Blue;
            this.exchangeLabel.Location = new System.Drawing.Point(20, 112);
            this.exchangeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exchangeLabel.Name = "exchangeLabel";
            this.exchangeLabel.Size = new System.Drawing.Size(0, 13);
            this.exchangeLabel.TabIndex = 5;
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(138, 32);
            this.startDatePicker.MinDate = new System.DateTime(2004, 5, 27, 0, 0, 0, 0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(100, 20);
            this.startDatePicker.TabIndex = 6;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(253, 32);
            this.endDatePicker.MinDate = new System.DateTime(2004, 5, 27, 0, 0, 0, 0);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(91, 20);
            this.endDatePicker.TabIndex = 7;
            // 
            // addReportsToDb
            // 
            this.addReportsToDb.Location = new System.Drawing.Point(13, 140);
            this.addReportsToDb.Name = "addReportsToDb";
            this.addReportsToDb.Size = new System.Drawing.Size(106, 23);
            this.addReportsToDb.TabIndex = 8;
            this.addReportsToDb.Text = "add reports to Db";
            this.addReportsToDb.UseVisualStyleBackColor = true;
            // 
            // errors
            // 
            this.errors.AutoSize = true;
            this.errors.Location = new System.Drawing.Point(10, 178);
            this.errors.Name = "errors";
            this.errors.Size = new System.Drawing.Size(0, 13);
            this.errors.TabIndex = 9;
            // 
            // DataFromHtmlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errors);
            this.Controls.Add(this.addReportsToDb);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.exchangeLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchExchangeBtn);
            this.Controls.Add(this.compIDTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DataFromHtmlView";
            this.Size = new System.Drawing.Size(606, 432);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox compIDTextBox;
        private System.Windows.Forms.Button searchExchangeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label exchangeLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button addReportsToDb;
        private System.Windows.Forms.Label errors;
    }
}
