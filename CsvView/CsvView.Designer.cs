namespace WindowsFormsApplication1
{
    partial class CsvView
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
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // loadCsv
            // 
            this.loadCsv.Location = new System.Drawing.Point(3, 3);
            this.loadCsv.Name = "loadCsv";
            this.loadCsv.Size = new System.Drawing.Size(75, 23);
            this.loadCsv.TabIndex = 0;
            this.loadCsv.Text = "loadCsv";
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
            this.csvDataGrid.Size = new System.Drawing.Size(272, 116);
            this.csvDataGrid.TabIndex = 1;
            // 
            // CsvView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.csvDataGrid);
            this.Controls.Add(this.loadCsv);
            this.Name = "CsvView";
            this.Size = new System.Drawing.Size(276, 152);
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadCsv;
        private System.Windows.Forms.DataGridView csvDataGrid;
    }
}
