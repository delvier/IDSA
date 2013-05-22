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
            this.baseView = new System.Windows.Forms.Button();
            this.loadFinData = new System.Windows.Forms.Button();
            this.saveDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // loadCsv
            // 
            this.loadCsv.Location = new System.Drawing.Point(4, 4);
            this.loadCsv.Name = "loadCsv";
            this.loadCsv.Size = new System.Drawing.Size(75, 23);
            this.loadCsv.TabIndex = 0;
            this.loadCsv.Text = "loadCmp";
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
            this.csvDataGrid.Size = new System.Drawing.Size(373, 207);
            this.csvDataGrid.TabIndex = 1;
            // 
            // baseView
            // 
            this.baseView.Location = new System.Drawing.Point(165, 4);
            this.baseView.Name = "baseView";
            this.baseView.Size = new System.Drawing.Size(75, 23);
            this.baseView.TabIndex = 2;
            this.baseView.Text = "base";
            this.baseView.UseVisualStyleBackColor = true;
            this.baseView.Click += new System.EventHandler(this.baseView_Click);
            // 
            // loadFinData
            // 
            this.loadFinData.Location = new System.Drawing.Point(84, 4);
            this.loadFinData.Name = "loadFinData";
            this.loadFinData.Size = new System.Drawing.Size(75, 23);
            this.loadFinData.TabIndex = 3;
            this.loadFinData.Text = "loadFinData";
            this.loadFinData.UseVisualStyleBackColor = true;
            this.loadFinData.Click += new System.EventHandler(this.loadFinData_Click);
            // 
            // saveDb
            // 
            this.saveDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveDb.Location = new System.Drawing.Point(299, 4);
            this.saveDb.Name = "saveDb";
            this.saveDb.Size = new System.Drawing.Size(75, 23);
            this.saveDb.TabIndex = 4;
            this.saveDb.Text = "saveDb";
            this.saveDb.UseVisualStyleBackColor = true;
            this.saveDb.Click += new System.EventHandler(this.saveDb_Click);
            // 
            // VCsvLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveDb);
            this.Controls.Add(this.loadFinData);
            this.Controls.Add(this.baseView);
            this.Controls.Add(this.csvDataGrid);
            this.Controls.Add(this.loadCsv);
            this.Name = "VCsvLoad";
            this.Size = new System.Drawing.Size(377, 243);
            ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadCsv;
        private System.Windows.Forms.DataGridView csvDataGrid;
        private System.Windows.Forms.Button baseView;
        private System.Windows.Forms.Button loadFinData;
        private System.Windows.Forms.Button saveDb;
    }
}
