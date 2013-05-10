using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace DBModule
{
    //TODO: 
    //Pin to compare Reports, 
    //Move to another file
    public class ReportComparer : IEqualityComparer<Report>
    {
        public bool Equals(Report x, Report y)
        {
            return (x.CompanySymbol == y.CompanySymbol && x.Year == y.Year && x.Period == y.Period);
        }

        public int GetHashCode(Report obj)
        {
            return obj.ID.GetHashCode();
        }
    }

    public class DbService
    {
        private IUnitOfWork uow;

        public DbService()
        {
            uow = new EFUnitOfWork(new Context());
            //TODO: Change in the future in this place !!!!!!!!!!!!
            if (!uow.Companies.Query().Any())
                AddRecords();
        }

        public BindingList<Company> GetAllCompanies()
        {
            return uow.Companies.GetAll();
        }

        public void AddAllCompanies(IUnitOfWork uow)
        {
            //TODO: add all companies functionality

        }

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

            uow.Companies.Add(company);
            uow.Companies.Add(company2);
            uow.Commit();

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
                CompanySymbol = uow.Companies.Query().SingleOrDefault(x => x.Symbol == "WWL").Symbol,
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

            uow.Reports.Add(report);
            uow.Reports.Add(report2);
            uow.Reports.Add(report3);
            uow.Reports.Add(report4);

            uow.Commit();
        }

        public void AddsNewCompany()
        {
            var company = new Company { Symbol = "WMO", Name = "Wind Mobile", Trade = TRADES.BUDOWNICTWO,
                                        Description = "Halogranie i Reklamowka", Url = "http://www.windmobile.pl"
            };
            uow.Companies.Add(company);
            uow.Commit();
            var actual = uow.Companies.Query().FirstOrDefault(e => e.Name == "Wind Mobile");
            //TODO: Assert wywala wyjatek, a nie powinien !!!
            //Debug.Assert(actual == null, "Baza nie zwrocila ostatnio zapisanego rekordu");

            var report = new Report { Period = PERIOD.Q4, NetProfit = 4333, SalesRevenues = 455697, 
                Year = 2004, CompanySymbol = "WMO" };
            uow.Reports.Add(report);
            uow.Commit();
        }

        public void Repository_Testing()
        {
            var company = new Company { Symbol = "ZKA", Name = "Zetkama", Trade = TRADES.HANDEL };
            uow.Companies.Add(company);
            uow.Commit();
            uow.Companies.Remove(company);
            uow.Commit();
            Debug.Assert(0 == uow.Companies.Query().Count());
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

        public void Dispose()
        {
            uow.Dispose();
        }
    }
}
