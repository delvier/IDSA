using System.Windows.Forms;
using IDSA.Presenters;
using System;
using IDSA.Models;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Linq;
using IDSA.Events;
using Microsoft.Practices.Prism.Events;

namespace IDSA.Views
{
    public interface IVCompany
    {
        void SelectedCmpReportsChanged(object sender, SelectedCmpReportsChangedEventArgs e);
    }

    public partial class VCompany : UserControl, IVCompany
    {
        VCompanyPresenter presenter;
        private readonly IEventAggregator _eventAggregator;

        public VCompany(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new VCompanyPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<VCompanyPresenter>();

            //ServiceLocator.Instance.Resolve<EventDbCreate>().DbCreateDone += RefreshView;
            _eventAggregator = eventAggregator;// ServiceLocator.Instance.Resolve<IEventAggregator>();
            _eventAggregator.GetEvent<DatabaseCreatedEvent>()
                .Subscribe(RefreshView);
        }

        #region Init & Display Options
        private void InitListBox()
        {
            CompanyBox.Sorted = true;
            CompanyBox.DataSource = presenter.GetDbCompanies();
            CompanyBox.DisplayMember = CsvEnums.company.Name.ToString();
        }

        private void InitGridOptions()
        {
            FinDataGrid.BackgroundColor = Color.White;
            FinDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DataGridViewRow row = this.FinDataGrid.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.White;
            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            row.Height = 18;
            row.MinimumHeight = 18;
            //FinDataGrid.Height = 15 * 15; // 4*3 Quaters.
            SetFinDataDisplayStyle();
        }

        private void SetFinDataDisplayStyle()
        {
            DataGridViewCellStyle bigNumberCellStyle = new DataGridViewCellStyle();
            bigNumberCellStyle.Format = "#,##0, k";
            bigNumberCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //long numbers into thousands.
            if (this.FinDataGrid.RowCount != 0)
            {
                foreach (DataGridViewColumn cols in FinDataGrid.Columns)
                {
                    if (cols.ValueType == typeof(long))
                        cols.DefaultCellStyle = bigNumberCellStyle;
                }
            }
        }

        private void InitDropBoxs()
        {
            CompanyTypes.DataSource = presenter.GetTestBindList();
            CompanyTypes.DisplayMember = CsvEnums.company.Name.ToString();

            MarketType.DataSource = presenter.GetTestBindList();
            MarketType.DisplayMember = CsvEnums.company.Name.ToString();
        }

        public System.Windows.Forms.ListBox.ObjectCollection GetCmpBoxItems()
        {
            return CompanyBox.Items;
        }
        #endregion

        #region View Refresh Update / Init
        private void RefreshView(bool isCreated)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => RefreshView(isCreated)));
            }
            else
            {
                this.InitListBox();
                this.InitDropBoxs();
                this.InitGridOptions();
                //this.ChartPopulatingData();
            }
        }

        public void RefreshView_Panel2(ICompany cmp)
        {
            FinDataGrid.DataSource = presenter._cmpSelectedReportsList;
            //to avoid ArgumentOutOfRangeException, when company does not have reports
            if (FinDataGrid.RowCount > 0)
            {
                //this.TransposeFinDataGrid();
            }
            tvLabel.Text = presenter.GetTerminalValue();
            SharePriceLabel.Text = cmp.SharePrice.ToString();
            DateCmpLabel.Text = String.Format("{0}", ((System.DateTime)cmp.Date).ToShortDateString());
            CompanyTitle.Text = cmp.FullName.ToString();
        }
        #endregion

        #region  Block of Utils

        public void TransposeFinDataGrid()
        {
            DataTable oldTable = VCompanyPresenter.DataGridView2DataTable(FinDataGrid, "oldTable");
            DataTable newTable = new DataTable();

            newTable.Columns.Add("Header");
            for (int i = 0; i < oldTable.Rows.Count; i++)
            {
                newTable.Columns.Add();
                //here get year quater [i] from old table. and put into caption columns.
                //newTable.Columns[i].Caption = 
            }


            for (int i = 0; i < oldTable.Columns.Count; i++)
            {
                DataRow newRow = newTable.NewRow();

                newRow[0] = oldTable.Columns[i].Caption;

                for (int j = 0; j < FinDataGrid.Rows.Count; j++)
                    newRow[j + 1] = oldTable.Rows[j][i];
                newTable.Rows.Add(newRow);
            }

            // this should be seperate code... function... extension ?
            var lst = new List<string>(); //getHeaders from column 0
            for (int i = 0; i < newTable.Rows.Count; i++)
            {
                lst.Add(newTable.Rows[i][0].ToString());
            }

            newTable.Columns.Remove(newTable.Columns[0]); //removeTrashHeaderColumn

            FinDataGrid.DataSource = newTable;
            // row header by lst.
            foreach (var header in lst)
            {
                FinDataGrid.Rows[lst.IndexOf(header)].HeaderCell.Value = header;
            }
            //FinDataGrid.Columns[0].Visible = false; // ?
        }

        public void BoxMsg(string s)
        {
            MessageBox.Show(s);
        }
        #endregion

        #region Events Handlers Block.
        public void SelectedCmpReportsChanged(object sender, EventArgs e)
        {
            presenter.UpdatePanel2();
        }
        public void SelectedCmpReportsChanged(object sender, SelectedCmpReportsChangedEventArgs e)
        {
            presenter.UpdatePanel2();
        }

        private void filterFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.RaiseSelectedCmpChange(this, new SelectedCmpReportsChangedEventArgs(4));
            //presenter.SetLast4QReports(); ;
        }

        private void fullFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.RaiseSelectedCmpChange(this, new SelectedCmpReportsChangedEventArgs());
            //presenter.SetFullReports();
        }

        private void calculationFinDataBtn_Click(object sender, EventArgs e)
        {
            presenter.RaiseDataRecalculation(this, e);
        }

        private void modeFinDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ViewModeType _viewModeType;
            if (modeFinDataCheckBox.Checked)
                _viewModeType = ViewModeType.Cumulative;
            else
                _viewModeType = ViewModeType.Seperate;
            presenter.RaiseViewModeChange(this, new RaiseViewModeChangeEventArgs(_viewModeType));
                
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: After application start, before user interaction, there are many events raised (SelectedIndexChanged)
            //TODO: We should ignore them
            if (CompanyBox.SelectedItem != null)
            {
                presenter.SetCmpSelected((Company)CompanyBox.SelectedItem);
                presenter.RaiseSelectedCmpChange(this, new SelectedCmpReportsChangedEventArgs());
            }
        }

        private void CompanyFilter_TextChanged(object sender, System.EventArgs e)
        {
            CompanyBox.BeginUpdate();
            CompanyBox.DataSource = presenter.GetFilterBox(CompanyFilter.Text);
            CompanyBox.EndUpdate();
        }
        #endregion

        #region Chart usage methods

        private int selectedColumnIndex = 0;
        private List<String> xValues = new List<String>();

        private void FinDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //Column Year or Quarter = no changes on chart
            if (e.ColumnIndex < 2 || e.ColumnIndex == selectedColumnIndex)
            {
                //TODO: (empty chart only with xValues)
                return;
            }
            selectedColumnIndex = e.ColumnIndex;
            var headerName = this.FinDataGrid.Columns[selectedColumnIndex].HeaderText;

            presenter.ChartChangeNow(headerName);

            // Get y values in view
            //var headerIdx = this.FinDataGrid.CurrentCell.ColumnIndex;
            //yValues.Add(Int64.Parse(this.FinDataGrid.Rows[i].Cells[headerIdx].Value.ToString()));
        }

        internal void ChartRedraw(IList<String> xVals, IList<Int64> yVals)
        {
            var header = this.FinDataGrid.Columns[selectedColumnIndex].HeaderText;
            chart1.Series.Clear();
            chart1.Series.Add(header);
            chart1.Series[header].Points.DataBindXY(xVals, yVals);
        }

        #endregion
    }
}
