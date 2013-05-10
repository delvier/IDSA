using System.Data.Entity;
using System.Linq;

namespace DBModule
{
    public class ContextDatabaseInitializer : IDatabaseInitializer<Context>
    {
        public void InitializeDatabase(Context context)
        {
            if (context.Database.Exists())
            {
                //if (!context.Database.CompatibleWithModel(true))
                //{
                    context.Database.Delete();
                    context.Database.Create();
                //}
            }
            else
                context.Database.Create();
            //Seed(context);
        }

        protected void Seed(Context context)
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

            context.Companies.Add(company);
            context.Companies.Add(company2);
            context.SaveChanges();

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
                CompanySymbol = context.Companies.SingleOrDefault(x => x.Symbol == "WWL").Symbol,
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

            context.Reports.Add(report);
            context.Reports.Add(report2);
            context.Reports.Add(report3);
            context.SaveChanges();
        }
    }
}
