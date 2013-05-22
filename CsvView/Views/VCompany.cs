using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsvReaderModule.Controllers;
using WindowsFormsApplication1;
using DBModule;

namespace CsvReaderModule.Views
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
    }
}
