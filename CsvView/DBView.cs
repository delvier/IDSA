using System;
using System.Windows.Forms;
using DBModule;

namespace WindowsFormsApplication1
{
    public partial class DBView : UserControl
    {
        DbService dbService;
        
        public DBView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dbService = new DbService();
            this.companyBindingSource.DataSource = dbService.GetAllCompanies();
        }

        private void companyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

            //dbService.AddReport();

            this.companyDataGridView.Refresh();
            this.reportsDataGridView.Refresh();
        }

        public void Dispose()       //TODO: Dispose() hides dispose() from ComponentModel.Component ???
        {
            base.Dispose();
            this.dbService.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbService.AddsNewCompany();
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
