using System;
using System.Windows.Forms;
using IDSA.Presenters;

namespace IDSA
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

            //EventHandlerClass eventHanderClass = new EventHandlerClass();
            //Initialization initialization = ServiceLocator.Instance.Resolve<Initialization>();
            //initialization.InitializationDone += eventHanderClass.DbInitializationComplete;
            //initialization.InitializationDone += dbInitialization;
            //initialization.Initialize(false);

            //DbUpdate dbUpdate = ServiceLocator.Instance.Resolve<DbUpdate>();
            //dbUpdate.DbUpdateDone += new DbUpdateDelegate(UpdateLabel);

            ServiceLocator.Instance.Resolve<DbCreate>().DbCreateDone += DBView_DbCreateDone;
            ServiceLocator.Instance.Resolve<DbUpdate>().DbUpdateDone += DBView_DbUpdateDone;
        }

        private void DBView_DbCreateDone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DBView_DbCreateDone()));
            }
            else
            {
                this.Info.Text = presenter.dbInfo();
                this.companyBindingSource.DataSource = presenter.GetAllCompanies();
                this.button1.Visible = true;
                this.button1.Refresh();
            }
        }

        void DBView_DbUpdateDone()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DBView_DbUpdateDone()));
            }
            else
            {
                this.Info.Text = presenter.dbInfo();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //    this.Info.Text = "DB is still loading, please wait...";
            //presenter.OnLoad();
            //this.Info.Text = presenter.dbInfo();
            //this.companyBindingSource.DataSource = presenter.GetAllCompanies();
            //this.reportsBindingSource.DataSource = presenter.GetRecords();
        }

        private void dbInitialization(object sender, EventArgs e)
        {
            //DbInitialization dbInitialization = e as DbInitialization;
            //presenter.OnLoad();
            //Label.CheckForIllegalCrossThreadCalls = false;
            this.Info.Text = presenter.dbInfo();
            this.companyBindingSource.DataSource = presenter.GetAllCompanies();
            this.button1.Visible = true;
            this.button1.Refresh();
        }

        private void dbChanged(object sender, EventArgs e)
        {
            this.Info.Text = presenter.dbChanged();
            this.companyBindingSource.DataSource = presenter.GetAllCompanies();
        }

        private void companyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // refresh
            this.Validate();
            this.companyDataGridView.Refresh();
            this.reportsDataGridView.Refresh();
        }

        private void CreateDatabase_Click(object sender, EventArgs e)
        {
            this.progressBar.Visible = true;
            this.progressBar.Refresh();
            presenter.CleanDatabase();
            //presenter.CreateDatabase();
            //this.Info.Text = presenter.dbInfo();
            ServiceLocator.Instance.Resolve<DbUpdate>().Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.AddsNewCompany();
            // TODO: Change place, where fire event ;)
            ServiceLocator.Instance.Resolve<DbUpdate>().Update();
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
