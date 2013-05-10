using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace DBModule
{
    public partial class DBView : UserControl
    {
        //TODO: Is DBOperations class needed???
        DBOperations dbOperations = new DBOperations();
        EFUnitOfWork uow;

        public DBView()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            uow = new EFUnitOfWork(new Context());
            if (!uow.Companies.Query().Any())
                dbOperations.AddRecords(uow);

            this.companyBindingSource.DataSource = uow.Companies.GetAll();
        }

        private void companyBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();

            //dbOperations.AddReport(uow);

            //foreach (var item in uow.Reports.Query().ToList())
            //{
            //    if (item.Year != 2012)
            //    {
            //        uow.Reports.Remove(item);
            //    }
            //}
            //uow.Commit();
            this.companyDataGridView.Refresh();
            this.reportsDataGridView.Refresh();
        }

        public void Dispose()
        {
            this.uow.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbOperations.AddsNewCompany(uow);

            //delete relationship
            //db.Entry(report).Reference(r => r.CompanySymbol).CurrentValue = null;
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
