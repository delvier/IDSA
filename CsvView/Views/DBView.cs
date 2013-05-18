using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using DBModule;
using CsvReaderModule.Controllers;

namespace WindowsFormsApplication1
{
    public interface IDbView
    {
        //void Refresh();
        //void AddCompany(Company company);
        //void AddCompany(List<Company> companies)
    }

    public partial class DBView : UserControl, IDbView
    {
        private DbViewPresenter presenter;
        
        public DBView()
        {
            InitializeComponent();
            ServiceLocator.Instance.Register(new DbViewPresenter(this));
            presenter = ServiceLocator.Instance.Resolve<DbViewPresenter>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            presenter.OnLoad();
            this.companyBindingSource.DataSource = presenter.GetAllCompanies();
        }

        private void companyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // refresh
            this.Validate();
            this.companyDataGridView.Refresh();
            this.reportsDataGridView.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.AddsNewCompany();
        }

        //[TestMethod()]        //UNIT Tests
        private void Select_Click(object sender, EventArgs e)
        {
            //var id = "WWL";
            //var query = db.Companies
            //            .Where(c => c.Symbol == id)
            //            .SelectMany(r => r.Reports,
            //                (spolka, raport) => new
            //                {
            //                    spolka.Name,
            //                    raport.KeyId.Year,
            //                    raport.NetProfit
            //                });

            //var companies = query.ToList();
            //foreach (var item in companies)
            //{
            //    //TODO:
            //}

            //var query = db.Companies.Include("Reports").Where(c => c.Symbol == id);
        }
    }
}
