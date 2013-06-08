namespace IDSA
{
    partial class DBView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBView));
            this.button1 = new System.Windows.Forms.Button();
            this.Clean = new System.Windows.Forms.Button();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesRevenuesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.netProfitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companySymbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.companyBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.companyDataGridView = new System.Windows.Forms.DataGridView();
            this.reportsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quarter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EBIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EarningOnSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addReportsCheckBox = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.CreateDatabase = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shortcut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingNavigator)).BeginInit();
            this.companyBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Companies";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Clean
            // 
            this.Clean.Location = new System.Drawing.Point(190, 91);
            this.Clean.Margin = new System.Windows.Forms.Padding(2);
            this.Clean.Name = "Clean";
            this.Clean.Size = new System.Drawing.Size(69, 26);
            this.Clean.TabIndex = 4;
            this.Clean.Text = "Clean DB";
            this.Clean.UseVisualStyleBackColor = true;
            this.Clean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // keyIdDataGridViewTextBoxColumn
            // 
            this.keyIdDataGridViewTextBoxColumn.DataPropertyName = "KeyId";
            this.keyIdDataGridViewTextBoxColumn.HeaderText = "KeyId";
            this.keyIdDataGridViewTextBoxColumn.Name = "keyIdDataGridViewTextBoxColumn";
            // 
            // salesRevenuesDataGridViewTextBoxColumn
            // 
            this.salesRevenuesDataGridViewTextBoxColumn.DataPropertyName = "SalesRevenues";
            this.salesRevenuesDataGridViewTextBoxColumn.HeaderText = "SalesRevenues";
            this.salesRevenuesDataGridViewTextBoxColumn.Name = "salesRevenuesDataGridViewTextBoxColumn";
            // 
            // netProfitDataGridViewTextBoxColumn
            // 
            this.netProfitDataGridViewTextBoxColumn.DataPropertyName = "NetProfit";
            this.netProfitDataGridViewTextBoxColumn.HeaderText = "NetProfit";
            this.netProfitDataGridViewTextBoxColumn.Name = "netProfitDataGridViewTextBoxColumn";
            // 
            // companySymbolDataGridViewTextBoxColumn
            // 
            this.companySymbolDataGridViewTextBoxColumn.DataPropertyName = "CompanySymbol";
            this.companySymbolDataGridViewTextBoxColumn.HeaderText = "CompanySymbol";
            this.companySymbolDataGridViewTextBoxColumn.Name = "companySymbolDataGridViewTextBoxColumn";
            // 
            // companyDataGridViewTextBoxColumn
            // 
            this.companyDataGridViewTextBoxColumn.DataPropertyName = "Company";
            this.companyDataGridViewTextBoxColumn.HeaderText = "Company";
            this.companyDataGridViewTextBoxColumn.Name = "companyDataGridViewTextBoxColumn";
            // 
            // companyBindingNavigator
            // 
            this.companyBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.companyBindingNavigator.BindingSource = this.companyBindingSource;
            this.companyBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.companyBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.companyBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.companyBindingNavigatorSaveItem});
            this.companyBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.companyBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.companyBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.companyBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.companyBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.companyBindingNavigator.Name = "companyBindingNavigator";
            this.companyBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.companyBindingNavigator.Size = new System.Drawing.Size(986, 25);
            this.companyBindingNavigator.TabIndex = 5;
            this.companyBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(38, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // companyBindingNavigatorSaveItem
            // 
            this.companyBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.companyBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("companyBindingNavigatorSaveItem.Image")));
            this.companyBindingNavigatorSaveItem.Name = "companyBindingNavigatorSaveItem";
            this.companyBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.companyBindingNavigatorSaveItem.Text = "Save Data";
            this.companyBindingNavigatorSaveItem.Click += new System.EventHandler(this.companyBindingNavigatorSaveItem_Click);
            // 
            // companyDataGridView
            // 
            this.companyDataGridView.AutoGenerateColumns = false;
            this.companyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.companyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.dataGridViewTextBoxColumn2,
            this.Shortcut,
            this.Date});
            this.companyDataGridView.DataSource = this.companyBindingSource;
            this.companyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyDataGridView.Location = new System.Drawing.Point(0, 0);
            this.companyDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.companyDataGridView.Name = "companyDataGridView";
            this.companyDataGridView.RowTemplate.Height = 24;
            this.companyDataGridView.Size = new System.Drawing.Size(350, 485);
            this.companyDataGridView.TabIndex = 5;
            // 
            // reportsBindingSource
            // 
            this.reportsBindingSource.DataMember = "Reports";
            this.reportsBindingSource.DataSource = this.companyBindingSource;
            // 
            // reportsDataGridView
            // 
            this.reportsDataGridView.AutoGenerateColumns = false;
            this.reportsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.CompanyId,
            this.dataGridViewTextBoxColumn10,
            this.Quarter,
            this.EBIT,
            this.Sales,
            this.EarningOnSales,
            this.dataGridViewTextBoxColumn13});
            this.reportsDataGridView.DataSource = this.reportsBindingSource;
            this.reportsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.reportsDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.reportsDataGridView.Name = "reportsDataGridView";
            this.reportsDataGridView.RowTemplate.Height = 24;
            this.reportsDataGridView.Size = new System.Drawing.Size(633, 350);
            this.reportsDataGridView.TabIndex = 5;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Id";
            this.Column2.HeaderText = "Id";
            this.Column2.Name = "Column2";
            // 
            // CompanyId
            // 
            this.CompanyId.DataPropertyName = "CompanyId";
            this.CompanyId.HeaderText = "CompanyId";
            this.CompanyId.Name = "CompanyId";
            // 
            // Quarter
            // 
            this.Quarter.DataPropertyName = "Quarter";
            this.Quarter.HeaderText = "Quarter";
            this.Quarter.Name = "Quarter";
            // 
            // EBIT
            // 
            this.EBIT.DataPropertyName = "EBIT";
            this.EBIT.HeaderText = "EBIT";
            this.EBIT.Name = "EBIT";
            // 
            // Sales
            // 
            this.Sales.DataPropertyName = "Sales";
            this.Sales.HeaderText = "Sales";
            this.Sales.Name = "Sales";
            // 
            // EarningOnSales
            // 
            this.EarningOnSales.DataPropertyName = "EarningOnSales";
            this.EarningOnSales.HeaderText = "EarningOnSales";
            this.EarningOnSales.Name = "EarningOnSales";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.companyDataGridView);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(986, 485);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBox1);
            this.splitContainer2.Panel1.Controls.Add(this.addReportsCheckBox);
            this.splitContainer2.Panel1.Controls.Add(this.trackBar1);
            this.splitContainer2.Panel1.Controls.Add(this.progressBar);
            this.splitContainer2.Panel1.Controls.Add(this.CreateDatabase);
            this.splitContainer2.Panel1.Controls.Add(this.Info);
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.Clean);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.reportsDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(633, 485);
            this.splitContainer2.SplitterDistance = 132;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "400";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // addReportsCheckBox
            // 
            this.addReportsCheckBox.AutoSize = true;
            this.addReportsCheckBox.Location = new System.Drawing.Point(290, 97);
            this.addReportsCheckBox.Name = "addReportsCheckBox";
            this.addReportsCheckBox.Size = new System.Drawing.Size(80, 17);
            this.addReportsCheckBox.TabIndex = 10;
            this.addReportsCheckBox.Text = "Add reports";
            this.addReportsCheckBox.UseVisualStyleBackColor = true;
            this.addReportsCheckBox.CheckedChanged += new System.EventHandler(this.addReportsCheckBox1_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(174, 47);
            this.trackBar1.Maximum = 958;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.Value = 400;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(172, 28);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(205, 19);
            this.progressBar.TabIndex = 8;
            this.progressBar.Visible = false;
            // 
            // CreateDatabase
            // 
            this.CreateDatabase.Location = new System.Drawing.Point(172, -1);
            this.CreateDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.CreateDatabase.Name = "CreateDatabase";
            this.CreateDatabase.Size = new System.Drawing.Size(205, 24);
            this.CreateDatabase.TabIndex = 7;
            this.CreateDatabase.Text = "Add ALL data(take about 15min!!!)";
            this.CreateDatabase.UseVisualStyleBackColor = true;
            this.CreateDatabase.Click += new System.EventHandler(this.CreateDatabase_Click);
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Info.Location = new System.Drawing.Point(2, 0);
            this.Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(132, 40);
            this.Info.TabIndex = 5;
            this.Info.Text = "DB is still loading.\r\n... please wait ...\r\n";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 50;
            // 
            // Shortcut
            // 
            this.Shortcut.DataPropertyName = "Shortcut";
            this.Shortcut.HeaderText = "Shortcut";
            this.Shortcut.Name = "Shortcut";
            this.Shortcut.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Shortcut.Width = 60;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataSource = typeof(IDSA.Models.Company);
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Year";
            this.dataGridViewTextBoxColumn10.HeaderText = "Year";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "NetProfit";
            this.dataGridViewTextBoxColumn13.HeaderText = "NetProfit";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // DBView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.companyBindingNavigator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DBView";
            this.Size = new System.Drawing.Size(986, 510);
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingNavigator)).EndInit();
            this.companyBindingNavigator.ResumeLayout(false);
            this.companyBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportsDataGridView)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button Clean;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesRevenuesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn netProfitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companySymbolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private System.Windows.Forms.BindingNavigator companyBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton companyBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView companyDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource reportsBindingSource;
        private System.Windows.Forms.DataGridView reportsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quarter;
        private System.Windows.Forms.DataGridViewTextBoxColumn EBIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn EarningOnSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label Info;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button CreateDatabase;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox addReportsCheckBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shortcut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}

