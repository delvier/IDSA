namespace IDSA.Views
{
    partial class VCompany
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CompanyContainer = new System.Windows.Forms.SplitContainer();
            this.CompanyTypes = new System.Windows.Forms.ComboBox();
            this.MarketType = new System.Windows.Forms.ComboBox();
            this.CompanyFilter = new System.Windows.Forms.TextBox();
            this.CompanyBox = new System.Windows.Forms.ListBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SharePriceLabel = new System.Windows.Forms.Label();
            this.CompanyTitle = new System.Windows.Forms.Label();
            this.FinDataGrid = new System.Windows.Forms.DataGridView();
            this.eventLog1 = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyContainer)).BeginInit();
            this.CompanyContainer.Panel1.SuspendLayout();
            this.CompanyContainer.Panel2.SuspendLayout();
            this.CompanyContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // CompanyContainer
            // 
            this.CompanyContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CompanyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyContainer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CompanyContainer.Location = new System.Drawing.Point(0, 0);
            this.CompanyContainer.Name = "CompanyContainer";
            // 
            // CompanyContainer.Panel1
            // 
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyTypes);
            this.CompanyContainer.Panel1.Controls.Add(this.MarketType);
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyFilter);
            this.CompanyContainer.Panel1.Controls.Add(this.CompanyBox);
            this.CompanyContainer.Panel1MinSize = 150;
            // 
            // CompanyContainer.Panel2
            // 
            this.CompanyContainer.Panel2.Controls.Add(this.chart1);
            this.CompanyContainer.Panel2.Controls.Add(this.SharePriceLabel);
            this.CompanyContainer.Panel2.Controls.Add(this.CompanyTitle);
            this.CompanyContainer.Panel2.Controls.Add(this.FinDataGrid);
            this.CompanyContainer.Panel2MinSize = 350;
            this.CompanyContainer.Size = new System.Drawing.Size(508, 375);
            this.CompanyContainer.SplitterDistance = 150;
            this.CompanyContainer.TabIndex = 0;
            // 
            // CompanyTypes
            // 
            this.CompanyTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyTypes.FormattingEnabled = true;
            this.CompanyTypes.Location = new System.Drawing.Point(4, 25);
            this.CompanyTypes.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyTypes.Name = "CompanyTypes";
            this.CompanyTypes.Size = new System.Drawing.Size(143, 21);
            this.CompanyTypes.TabIndex = 3;
            // 
            // MarketType
            // 
            this.MarketType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MarketType.FormattingEnabled = true;
            this.MarketType.Location = new System.Drawing.Point(4, 4);
            this.MarketType.Margin = new System.Windows.Forms.Padding(0);
            this.MarketType.Name = "MarketType";
            this.MarketType.Size = new System.Drawing.Size(143, 21);
            this.MarketType.TabIndex = 2;
            // 
            // CompanyFilter
            // 
            this.CompanyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyFilter.Location = new System.Drawing.Point(4, 46);
            this.CompanyFilter.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyFilter.Name = "CompanyFilter";
            this.CompanyFilter.Size = new System.Drawing.Size(143, 20);
            this.CompanyFilter.TabIndex = 1;
            this.CompanyFilter.TextChanged += new System.EventHandler(this.CompanyFilter_TextChanged);
            // 
            // CompanyBox
            // 
            this.CompanyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyBox.FormattingEnabled = true;
            this.CompanyBox.Location = new System.Drawing.Point(4, 66);
            this.CompanyBox.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(143, 303);
            this.CompanyBox.TabIndex = 0;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 226);
            this.chart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(344, 143);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // SharePriceLabel
            // 
            this.SharePriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SharePriceLabel.AutoSize = true;
            this.SharePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SharePriceLabel.Location = new System.Drawing.Point(236, 4);
            this.SharePriceLabel.Name = "SharePriceLabel";
            this.SharePriceLabel.Size = new System.Drawing.Size(109, 25);
            this.SharePriceLabel.TabIndex = 2;
            this.SharePriceLabel.Text = "SharePrice";
            // 
            // CompanyTitle
            // 
            this.CompanyTitle.AutoSize = true;
            this.CompanyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CompanyTitle.Location = new System.Drawing.Point(3, 4);
            this.CompanyTitle.Name = "CompanyTitle";
            this.CompanyTitle.Size = new System.Drawing.Size(49, 25);
            this.CompanyTitle.TabIndex = 1;
            this.CompanyTitle.Text = "Title";
            // 
            // FinDataGrid
            // 
            this.FinDataGrid.AllowUserToAddRows = false;
            this.FinDataGrid.AllowUserToDeleteRows = false;
            this.FinDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FinDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FinDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FinDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FinDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.FinDataGrid.Location = new System.Drawing.Point(3, 66);
            this.FinDataGrid.Name = "FinDataGrid";
            this.FinDataGrid.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FinDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.FinDataGrid.Size = new System.Drawing.Size(342, 155);
            this.FinDataGrid.TabIndex = 0;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // VCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CompanyContainer);
            this.Name = "VCompany";
            this.Size = new System.Drawing.Size(508, 375);
            this.CompanyContainer.Panel1.ResumeLayout(false);
            this.CompanyContainer.Panel1.PerformLayout();
            this.CompanyContainer.Panel2.ResumeLayout(false);
            this.CompanyContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyContainer)).EndInit();
            this.CompanyContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FinDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer CompanyContainer;
        private System.Windows.Forms.ListBox CompanyBox;
        private System.Windows.Forms.TextBox CompanyFilter;
        private System.Windows.Forms.Label CompanyTitle;
        private System.Windows.Forms.DataGridView FinDataGrid;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.ComboBox CompanyTypes;
        private System.Windows.Forms.ComboBox MarketType;
        private System.Windows.Forms.Label SharePriceLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
