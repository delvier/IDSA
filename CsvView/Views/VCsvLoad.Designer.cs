namespace IDSA
{
    partial class VCsvLoad
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
            this.loadCsv = new System.Windows.Forms.Button();
            this.csvDataGrid = new System.Windows.Forms.DataGridView();
            this.saveDb = new System.Windows.Forms.Button();
            this.CsvDataTypeBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // loadCsv
            // 
            this.loadCsv.Location = new System.Drawing.Point(88, 4);
            this.loadCsv.Margin = new System.Windows.Forms.Padding(0);
            this.loadCsv.Name = "loadCsv";
            this.loadCsv.Size = new System.Drawing.Size(75, 23);
            this.loadCsv.TabIndex = 0;
            this.loadCsv.Text = "Csv Load";
            this.loadCsv.UseVisualStyleBackColor = true;
            this.loadCsv.Click += new System.EventHandler(this.loadCsv_Click);
            // 
            // csvDataGrid
            // 
            this.csvDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.csvDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvDataGrid.Location = new System.Drawing.Point(4, 33);
            this.csvDataGrid.Name = "csvDataGrid";
            this.csvDataGrid.Size = new System.Drawing.Size(413, 232);
            this.csvDataGrid.TabIndex = 1;
            // 
            // saveDb
            // 
            this.saveDb.Location = new System.Drawing.Point(163, 4);
            this.saveDb.Margin = new System.Windows.Forms.Padding(0);
            this.saveDb.Name = "saveDb";
            this.saveDb.Size = new System.Drawing.Size(75, 23);
            this.saveDb.TabIndex = 4;
            this.saveDb.Text = "Save DB";
            this.saveDb.UseVisualStyleBackColor = true;
            this.saveDb.Click += new System.EventHandler(this.saveDb_Click);
            // 
            // CsvDataTypeBox
            // 
            this.CsvDataTypeBox.FormattingEnabled = true;
            this.CsvDataTypeBox.Location = new System.Drawing.Point(4, 4);
            this.CsvDataTypeBox.Margin = new System.Windows.Forms.Padding(0);
            this.CsvDataTypeBox.Name = "CsvDataTypeBox";
            this.CsvDataTypeBox.Size = new System.Drawing.Size(84, 21);
            this.CsvDataTypeBox.TabIndex = 5;
            // 
            // VCsvLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CsvDataTypeBox);
            this.Controls.Add(this.saveDb);
            this.Controls.Add(this.csvDataGrid);
            this.Controls.Add(this.loadCsv);
            this.Name = "VCsvLoad";
            this.Size = new System.Drawing.Size(417, 268);
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadCsv;
        private System.Windows.Forms.DataGridView csvDataGrid;
        private System.Windows.Forms.Button saveDb;
        private System.Windows.Forms.ComboBox CsvDataTypeBox;
    }
}
