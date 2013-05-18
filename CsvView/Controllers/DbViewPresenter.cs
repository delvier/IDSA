using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModule;
using WindowsFormsApplication1;
using System.Data.Entity;
using System.ComponentModel;
using System.Diagnostics;

namespace CsvReaderModule.Controllers
{
    public class DbViewPresenter
    {
        private IDbView view;
        private IUnitOfWork model;

        public DbViewPresenter(IDbView view)
        {
            this.view = view;
            // TODO: przeniesc register EFUnitOfWork do CsvView????
            Task.Factory.StartNew(() => ServiceLocator.Instance.Register(
                new EFUnitOfWork(
                new Context(new CreateDatabaseIfNotExists<Context>())
                )));
        }

        public void OnLoad()
        {
            Task.WaitAll();
            model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();

            //TODO: Change in the future in this place !!!!!!!!!!!!
            if (!model.Companies.Query().Any())
                AddRecords();
        }

        public BindingList<Company> GetAllCompanies()
        {
            return model.Companies.GetAll();
        }

        public void AddCompany(Company company)
        {
            model.Companies.Add(company);
            model.Commit();
        }

        public void AddCompany(List<Company> companies)
        {
            foreach (var company in companies)
            {
                model.Companies.Add(company);
            }
            model.Commit();
        }

        public void Dispose()
        {
            model.Dispose();
        }

        #region Testing methods(TODO: delete on the end)

        public void AddRecords()
        {
            var company = new Company
            {
                Name = "Wawel",
                Symbol = "WWL",
                Url = "http://www.wawel.com.pl/",
                Description = "",
                Trade = TRADES.CUKIERNICTWO
            };
            var company2 = new Company
            {
                Name = "Asseco Poland",
                Symbol = "ACP",
                Url = "http://www.asseco.com/pl/",
                Description = "Najwieksza spolka IT w Polsce",
                Trade = TRADES.INFORMATYKA
            };

            model.Companies.Add(company);
            model.Companies.Add(company2);
            model.Commit();

            var report = new Report
            {
                CompanySymbol = "WWL",
                Year = 2011,
                Period = PERIOD.Q1,
                NetProfit = 1000,
                SalesRevenues = 3809
            };
            var report2 = new Report
            {
                CompanySymbol = model.Companies.Query().SingleOrDefault(x => x.Symbol == "WWL").Symbol,
                Year = 2012,
                Period = PERIOD.Q1,
                NetProfit = 3010,
                SalesRevenues = 30000
            };
            var report3 = new Report
            {
                CompanySymbol = "WWL",
                Year = 2012,
                Period = PERIOD.Q2,
                NetProfit = 3010,
                SalesRevenues = 30000
            };
            var report4 = new Report
            {
                CompanySymbol = "ACP",
                Year = 2012,
                Period = PERIOD.Q3,
                NetProfit = 3210,
                SalesRevenues = 23001
            };

            model.Reports.Add(report);
            model.Reports.Add(report2);
            model.Reports.Add(report3);
            model.Reports.Add(report4);

            model.Commit();
        }

        public void AddsNewCompany()
        {
            var company = new Company
            {
                Symbol = "WMO",
                Name = "Wind Mobile",
                Trade = TRADES.BUDOWNICTWO,
                Description = "Halogranie i Reklamowka",
                Url = "http://www.windmobile.pl"
            };
            model.Companies.Add(company);
            model.Commit();
            var actual = model.Companies.Query().FirstOrDefault(e => e.Name == "Wind Mobile");
            //TODO: Assert wywala wyjatek, a nie powinien !!!
            //Debug.Assert(actual == null, "Baza nie zwrocila ostatnio zapisanego rekordu");

            var report = new Report
            {
                Period = PERIOD.Q4,
                NetProfit = 4333,
                SalesRevenues = 455697,
                Year = 2004,
                CompanySymbol = "WMO"
            };
            model.Reports.Add(report);
            model.Commit();
        }

        public void Repository_Testing()
        {
            var company = new Company { Symbol = "ZKA", Name = "Zetkama", Trade = TRADES.HANDEL };
            model.Companies.Add(company);
            model.Commit();
            model.Companies.Remove(company);
            model.Commit();
            Debug.Assert(0 == model.Companies.Query().Count());
        }

        public void AddReport()
        {
            //foreach (var item in uow.Reports.Query().ToList())
            //{
            //    if (item.Year != 2012)
            //    {
            //        uow.Reports.Remove(item);
            //    }
            //}
            //uow.Commit();

            //delete relationship
            //db.Entry(report).Reference(r => r.CompanySymbol).CurrentValue = null;
        }

        #endregion
    }
}
