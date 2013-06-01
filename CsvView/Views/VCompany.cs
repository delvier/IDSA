using System.Windows.Forms;
using IDSA.Presenters;
using System;
using IDSA.Models;
using System.Drawing;
using System.Collections.Generic;

namespace IDSA.Views
{
    public partial class VCompany : UserControl
    {
        VCompanyPresenter presenter;
        public VCompany()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new VCompanyPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<VCompanyPresenter>();

        }

        private void InitListBox()
        {
            CompanyBox.Sorted = true;
            CompanyBox.DataSource = presenter.GetDbCompanies();
            CompanyBox.DisplayMember = CsvEnums.company.Name.ToString();
        }

        private void InitGridOptions()
        {
            FinDataSortBy();
            DataGridViewRow row = this.FinDataGrid.RowTemplate;
            row.DefaultCellStyle.BackColor = Color.AliceBlue;
            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            row.Height = 15;
            row.MinimumHeight = 15;
            FinDataGrid.Height = 15 * 15; // 4*3 Quaters.
            HideFinDataColumns();
            SetFinDataDisplayStyle();
        }

        private void FinDataSortBy ()
        {
            FinDataSortBy("Year");
        }

        private void FinDataSortBy (string name)
        {
            this.FinDataGrid.Sort(FinDataGrid.Columns[name], System.ComponentModel.ListSortDirection.Descending);
        }

        private void SetFinDataDisplayStyle()
        {
            DataGridViewCellStyle bigNumberCellStyle = new DataGridViewCellStyle();
            bigNumberCellStyle.Format = "#,##0, k";
            bigNumberCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //long numbers into thousands.
            var propList = typeof(Report).GetProperties();
            foreach (var ePro in propList)
                if (ePro.PropertyType == typeof(Int64))
                    FinDataGrid.Columns[ePro.Name].DefaultCellStyle = bigNumberCellStyle;   

        }

        private void HideFinDataColumns()
        {
            // TO-OPT - i dont like this solution, pure data on view side.
            var hideList = new List<string>
            {
                "Id",
                "CompanyId",
                "Company"
            };
            foreach (DataGridViewColumn finColum in FinDataGrid.Columns)
            {
                if (hideList.Contains(finColum.Name))
                {
                    finColum.Visible = false;
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

        private void CompanyFilter_TextChanged(object sender, System.EventArgs e)
        {
            CompanyBox.BeginUpdate();
            CompanyBox.DataSource = presenter.GetFilterBox(CompanyFilter.Text);
            CompanyBox.EndUpdate();
        }

        public System.Windows.Forms.ListBox.ObjectCollection GetCmpBoxItems()
        {
            return CompanyBox.Items;
        }

        public void RefreshView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => RefreshView()));
            }
            else
            {
                this.InitListBox();
                this.InitDropBoxs();
                this.InitGridOptions();
            }
        }

        public void RefreshView_Panel2(Company cmp)
        {
            FinDataGrid.DataSource = cmp.Reports;
            FinDataSortBy();
            SharePriceLabel.Text = cmp.SharePrice.ToString();
            DateCmpLabel.Text = String.Format("{0}", ((System.DateTime)cmp.Date).ToShortDateString());
            // conversion should be done on presenter side
            CompanyTitle.Text = cmp.FullName.ToString();
        }

        private void CompanyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CompanyBox.SelectedItem != null)
            {
                presenter.SetCmpSelected((Company)CompanyBox.SelectedItem);
            }
        }

        public void BoxMsg (string s)
        {
            MessageBox.Show(s);
        }

        #region Chart usage methods

        private void ChartPopulatingData()
        {
            // TODO: populate data from DB
            double[] yval = { 5, 6, 4, 3, 7 };
            string[] xval = { "A", "B", "C", "D", "E" };

            //chart1.Series.Add("Sample data").AxisLabel.
        }

        #endregion

        
    }
}
