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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CompanyContainer = new System.Windows.Forms.SplitContainer();
            this.CompanyTypes = new System.Windows.Forms.ComboBox();
            this.MarketType = new System.Windows.Forms.ComboBox();
            this.CompanyFilter = new System.Windows.Forms.TextBox();
            this.CompanyBox = new System.Windows.Forms.ListBox();
            this.modeFinDataCheckBox = new System.Windows.Forms.CheckBox();
            this.calculationFinDataBtn = new System.Windows.Forms.Button();
            this.fullFinDataBtn = new System.Windows.Forms.Button();
            this.filterFinDataBtn = new System.Windows.Forms.Button();
            this.DateCmpLabel = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SharePriceLabel = new System.Windows.Forms.Label();
            this.CompanyTitle = new System.Windows.Forms.Label();
            this.FinDataGrid = new System.Windows.Forms.DataGridView();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.tvLabel = new System.Windows.Forms.Label();
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
            this.CompanyContainer.Panel2.Controls.Add(this.tvLabel);
            this.CompanyContainer.Panel2.Controls.Add(this.modeFinDataCheckBox);
            this.CompanyContainer.Panel2.Controls.Add(this.calculationFinDataBtn);
            this.CompanyContainer.Panel2.Controls.Add(this.fullFinDataBtn);
            this.CompanyContainer.Panel2.Controls.Add(this.filterFinDataBtn);
            this.CompanyContainer.Panel2.Controls.Add(this.DateCmpLabel);
            this.CompanyContainer.Panel2.Controls.Add(this.chart1);
            this.CompanyContainer.Panel2.Controls.Add(this.SharePriceLabel);
            this.CompanyContainer.Panel2.Controls.Add(this.CompanyTitle);
            this.CompanyContainer.Panel2.Controls.Add(this.FinDataGrid);
            this.CompanyContainer.Panel2MinSize = 350;
            this.CompanyContainer.Size = new System.Drawing.Size(634, 701);
            this.CompanyContainer.SplitterDistance = 187;
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
            this.CompanyTypes.Size = new System.Drawing.Size(180, 21);
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
            this.MarketType.Size = new System.Drawing.Size(180, 21);
            this.MarketType.TabIndex = 2;
            // 
            // CompanyFilter
            // 
            this.CompanyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyFilter.Location = new System.Drawing.Point(4, 46);
            this.CompanyFilter.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyFilter.Name = "CompanyFilter";
            this.CompanyFilter.Size = new System.Drawing.Size(180, 20);
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
            this.CompanyBox.Size = new System.Drawing.Size(180, 628);
            this.CompanyBox.TabIndex = 0;
            this.CompanyBox.SelectedIndexChanged += new System.EventHandler(this.CompanyBox_SelectedIndexChanged);
            // 
            // modeFinDataCheckBox
            // 
            this.modeFinDataCheckBox.AutoSize = true;
            this.modeFinDataCheckBox.Location = new System.Drawing.Point(247, 71);
            this.modeFinDataCheckBox.Name = "modeFinDataCheckBox";
            this.modeFinDataCheckBox.Size = new System.Drawing.Size(77, 17);
            this.modeFinDataCheckBox.TabIndex = 8;
            this.modeFinDataCheckBox.Text = "cumulative";
            this.modeFinDataCheckBox.UseVisualStyleBackColor = true;
            this.modeFinDataCheckBox.CheckedChanged += new System.EventHandler(this.modeFinDataCheckBox_CheckedChanged);
            // 
            // calculationFinDataBtn
            // 
            this.calculationFinDataBtn.Location = new System.Drawing.Point(165, 66);
            this.calculationFinDataBtn.Name = "calculationFinDataBtn";
            this.calculationFinDataBtn.Size = new System.Drawing.Size(75, 23);
            this.calculationFinDataBtn.TabIndex = 7;
            this.calculationFinDataBtn.Text = "Calculate!";
            this.calculationFinDataBtn.UseVisualStyleBackColor = true;
            this.calculationFinDataBtn.Click += new System.EventHandler(this.calculationFinDataBtn_Click);
            // 
            // fullFinDataBtn
            // 
            this.fullFinDataBtn.Location = new System.Drawing.Point(3, 66);
            this.fullFinDataBtn.Name = "fullFinDataBtn";
            this.fullFinDataBtn.Size = new System.Drawing.Size(75, 23);
            this.fullFinDataBtn.TabIndex = 6;
            this.fullFinDataBtn.Text = "Normal";
            this.fullFinDataBtn.UseVisualStyleBackColor = true;
            this.fullFinDataBtn.Click += new System.EventHandler(this.fullFinDataBtn_Click);
            // 
            // filterFinDataBtn
            // 
            this.filterFinDataBtn.Location = new System.Drawing.Point(84, 66);
            this.filterFinDataBtn.Name = "filterFinDataBtn";
            this.filterFinDataBtn.Size = new System.Drawing.Size(75, 23);
            this.filterFinDataBtn.TabIndex = 5;
            this.filterFinDataBtn.Text = "Last 4Q";
            this.filterFinDataBtn.UseVisualStyleBackColor = true;
            this.filterFinDataBtn.Click += new System.EventHandler(this.filterFinDataBtn_Click);
            // 
            // DateCmpLabel
            // 
            this.DateCmpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateCmpLabel.AutoSize = true;
            this.DateCmpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateCmpLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DateCmpLabel.Location = new System.Drawing.Point(361, 31);
            this.DateCmpLabel.Name = "DateCmpLabel";
            this.DateCmpLabel.Size = new System.Drawing.Size(33, 15);
            this.DateCmpLabel.TabIndex = 4;
            this.DateCmpLabel.Text = "Date";
            this.DateCmpLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(8, 381);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Series2";
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(776, 244);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // SharePriceLabel
            // 
            this.SharePriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SharePriceLabel.AutoSize = true;
            this.SharePriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SharePriceLabel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.SharePriceLabel.Location = new System.Drawing.Point(377, 4);
            this.SharePriceLabel.Name = "SharePriceLabel";
            this.SharePriceLabel.Size = new System.Drawing.Size(39, 25);
            this.SharePriceLabel.TabIndex = 2;
            this.SharePriceLabel.Text = "SP";
            this.SharePriceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FinDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.FinDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FinDataGrid.DefaultCellStyle = dataGridViewCellStyle23;
            this.FinDataGrid.Location = new System.Drawing.Point(3, 92);
            this.FinDataGrid.Name = "FinDataGrid";
            this.FinDataGrid.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FinDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.FinDataGrid.Size = new System.Drawing.Size(438, 284);
            this.FinDataGrid.TabIndex = 0;
            this.FinDataGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.FinDataGrid_CellEnter);
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // tvLabel
            // 
            this.tvLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLabel.AutoSize = true;
            this.tvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tvLabel.Location = new System.Drawing.Point(201, 4);
            this.tvLabel.Margin = new System.Windows.Forms.Padding(3, 0, 100, 0);
            this.tvLabel.Name = "tvLabel";
            this.tvLabel.Size = new System.Drawing.Size(39, 25);
            this.tvLabel.TabIndex = 9;
            this.tvLabel.Text = "TV";
            // 
            // VCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CompanyContainer);
            this.Name = "VCompany";
            this.Size = new System.Drawing.Size(634, 701);
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
        private System.Windows.Forms.Label DateCmpLabel;
        private System.Windows.Forms.Button filterFinDataBtn;
        private System.Windows.Forms.Button fullFinDataBtn;
        private System.Windows.Forms.Button calculationFinDataBtn;
        private System.Windows.Forms.CheckBox modeFinDataCheckBox;
        private System.Windows.Forms.Label tvLabel;
    }
}
