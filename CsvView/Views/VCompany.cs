using System.Windows.Forms;
using IDSA.Presenters;
using System;

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
        private void InitListBox ()
        {
            CompanyBox.DataSource = presenter.GetDbCompanies();
            CompanyBox.DisplayMember = CsvEnums.company.Name.ToString();
        }
        private void InitDropBoxs ()
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
            }
        }
        #region Chart usage methods

        private void ChartPopulatingData()
        {
            // TODO: populate data from DB
            double[] yval = { 5, 6, 4, 3, 7 };
            string[] xval = { "A", "B", "C", "D", "E"};

            //chart1.Series.Add("Sample data").AxisLabel.
        }

        #endregion
    }
}
