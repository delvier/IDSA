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
            CompanyBox.BeginUpdate();
            CompanyBox.DataSource = presenter.GetFilterBox(CompanyFilter.Text);
            CompanyBox.EndUpdate();
        }
    }
}
