using System.Windows.Forms;
using IDSA.Presenters;
using System.ComponentModel;
using DBModule;

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
            //init Company Box
            //CompanyBox.BindingContext = presenter.GetCompanies();
            //TestOnly
            this.InitListBox();
            this.InitDropBoxs();
        }
        private void InitListBox ()
        {
            CompanyBox.DataSource = presenter.GetTestCompanies();
            CompanyBox.DisplayMember = CsvEnums._company.Name.ToString();
        }
        private void InitDropBoxs ()
        {
            CompanyTypes.DataSource = presenter.GetTestBindList();
            CompanyTypes.DisplayMember = CsvEnums._company.Name.ToString();

            MarketType.DataSource = presenter.GetTestBindList();
            MarketType.DisplayMember = CsvEnums._company.Name.ToString();
        }

        private void CompanyFilter_TextChanged(object sender, System.EventArgs e)
        {
            var companyList = presenter.GetTestCompanies(); //return original data from Store
            var showList = new BindingList<Company>();
            CompanyBox.BeginUpdate();

            if (!string.IsNullOrEmpty(CompanyFilter.Text))
            {
                foreach (Company ele in companyList)
                {
                    if (ele.Name.Contains(CompanyFilter.Text))
                    {
                        showList.Add(ele);
                    }
                }
                CompanyBox.DataSource = showList;
            }
            else
                CompanyBox.DataSource = companyList; //there is no any filter string, so add all data we have in Store

            CompanyBox.EndUpdate();
        }
    }
}
