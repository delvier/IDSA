using IDSA.Events;
using IDSA.Models;
using IDSA.Models.Repository;
using IDSA.Views;
using LumenWorks.Framework.IO.Csv;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;

namespace IDSA.Presenters
{
    public class DBPresenter
    {
        #region Fields and Props

        private IDbView view;
        private IUnitOfWork model;
        private IEventAggregator _eventAggregator;
        #endregion

        #region Ctors

        public DBPresenter(IDbView view, IEventAggregator eventAggregator)
        {
            this.view = view;
            this.model = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _eventAggregator = eventAggregator;
        }

        #endregion

        #region Event Handlers

        internal string dbUpdateDone()
        {
            model.Load();
            return "DataBase sum up:\n  Companies  = " +
                    model.Companies.Query().Count() + "\n  Reports         = " +
                    model.Reports.Query().Count();
        }

        #endregion

        #region Private Methods

        private Company ConvertToCompany(string[] item)
        {
            string[] cos = item[(int)CsvEnums.company.Date].Split('-');
            return new Company()
            {
                Id = int.Parse(item[(int)CsvEnums.company.Id]),
                Name = item[(int)CsvEnums.company.Name],
                Shortcut = item[(int)CsvEnums.company.Shortcut],
                SharePrice = float.Parse(item[(int)CsvEnums.company.SharePrice], CultureInfo.InvariantCulture),
                Date = new DateTime(int.Parse(cos[0]), int.Parse(cos[1]), int.Parse(cos[2])),
                Description = item[(int)CsvEnums.company.Description],
                Href = item[(int)CsvEnums.company.Href],
                PhoneNumber = item[(int)CsvEnums.company.PhoneNumber],
                Email = item[(int)CsvEnums.company.Email],
                FullName = item[(int)CsvEnums.company.FullName],
                HeadAccount = item[(int)CsvEnums.company.HeadAccount],
                Profile = item[(int)CsvEnums.company.Profile],
                Address = item[(int)CsvEnums.company.Address],
                HrefStatus = item[(int)CsvEnums.company.HrefStatus],
                ShareNumbers = Int64.Parse(item[(int)CsvEnums.company.ShareNumbers])
            };
        }

        private Report ConvertToReport(string[] item)
        {
            long tempVal;

            return new Report()
            {
                Id = int.Parse(item[(int)CsvEnums.financialData.Id]),
                CompanyId = int.Parse(item[(int)CsvEnums.financialData.CmpId]),
                Year = int.Parse(item[(int)CsvEnums.financialData.Year]),
                Quarter = int.Parse(item[(int)CsvEnums.financialData.Quater]),
                Sales = Int64.TryParse(item[(int)CsvEnums.financialData.Sales], out tempVal) ? tempVal : 0,
                OwnSaleCosts = Int64.TryParse(item[(int)CsvEnums.financialData.OwnSaleCosts], out tempVal) ? tempVal : 0,
                SalesCost1 = Int64.TryParse(item[(int)CsvEnums.financialData.SalesCost1], out tempVal) ? tempVal : 0,
                SalesCost2 = Int64.TryParse(item[(int)CsvEnums.financialData.SalesCost2], out tempVal) ? tempVal : 0,
                EarningOnSales = Int64.TryParse(item[(int)CsvEnums.financialData.EarningOnSales], out tempVal) ? tempVal : 0,
                OtherOperationalActivity1 = Int64.TryParse(item[(int)CsvEnums.financialData.OtherOperationalActivity1], out tempVal) ? tempVal : 0,
                OtherOperationalActivity2 = Int64.TryParse(item[(int)CsvEnums.financialData.OtherOperationalActivity2], out tempVal) ? tempVal : 0,
                EBIT = Int64.TryParse(item[(int)CsvEnums.financialData.EBIT], out tempVal) ? tempVal : 0,
                FinancialActivity1 = Int64.TryParse(item[(int)CsvEnums.financialData.FinancialActivity1], out tempVal) ? tempVal : 0,
                FinancialActivity2 = Int64.TryParse(item[(int)CsvEnums.financialData.FinancialAcvitity2], out tempVal) ? tempVal : 0,
                OtherCostOrSales = Int64.TryParse(item[(int)CsvEnums.financialData.OtherCostOrSales], out tempVal) ? tempVal : 0,
                SalesOnEconomicActivity = Int64.TryParse(item[(int)CsvEnums.financialData.SalesOnEconomicActivity], out tempVal) ? tempVal : 0,
                ExceptionalOccurence = Int64.TryParse(item[(int)CsvEnums.financialData.ExceptionalOccurence], out tempVal) ? tempVal : 0,
                EarningBeforeTaxes = Int64.TryParse(item[(int)CsvEnums.financialData.EarningBeforeTaxes], out tempVal) ? tempVal : 0,
                DiscontinuedOperations = Int64.TryParse(item[(int)CsvEnums.financialData.DiscontinuedOperations], out tempVal) ? tempVal : 0,
                NetProfit = Int64.TryParse(item[(int)CsvEnums.financialData.NetProfit], out tempVal) ? tempVal : 0,
                NetParentProfit = Int64.TryParse(item[(int)CsvEnums.financialData.NetParentProfit], out tempVal) ? tempVal : 0,
            };
        }

        #endregion

        #region Internal Methods

        internal BindingList<Company> GetAllCompanies()
        {
            return model.Companies.GetAll();
        }

        internal void AddCompany(Company company)
        {
            model.Companies.Add(company);
            model.Commit();
        }

        internal void AddCompanies()
        {
            AddCompaniesFasta(886);
        }

        internal void AddCompaniesFasta(int count)
        {
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\company.csv"), false))
            {
                Context context = new Context();
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;
                context.Companies.Load();
                context.Reports.Load();
                int num = 0;

                int compAmount = context.Companies.Count();
                if (compAmount + count > 886)
                    count = 886 - compAmount;
                foreach (var item in csv.ToList().Skip(compAmount).Take(count))
                {
                    num++;
                    context.Companies.Add(ConvertToCompany(item));
                    if (num % 100 == 0)
                    {
                        context.SaveChanges();
                        for (int i = 0; i < 100; i++)
                        {
                            context.Entry(context.Companies.Local[0]).State = System.Data.EntityState.Detached;
                        }
                        view.UpdateProgressBar((int)(num * 100 / count));
                    }
                }
                context.SaveChanges();
                context.Dispose();
                _eventAggregator.GetEvent<DatabaseUpdatedEvent>().Publish(true);
            }
        }

        internal void AddReportsFasta2(int count)
        {
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\findata2.csv"), false))
            {
                Context context = new Context();
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Configuration.ValidateOnSaveEnabled = false;
                context.Companies.Load();
                context.Reports.Load();
                int num = 0;

                int repAmount = context.Reports.Count();
                if (repAmount + count > 16408)
                    count = 16408 - repAmount;
                foreach (var entity in csv.ToList().Skip(repAmount).Take(count))
                {
                    num++;
                    context.Reports.Add(ConvertToReport(entity));
                    if (num % 100 == 0)
                    {
                        context.SaveChanges();
                        for (int i = 0; i < 100; ++i)
                        {
                            context.Entry(context.Reports.Local[0]).State = System.Data.EntityState.Detached;
                        }
                        if (num % 1000 == 0)
                        {
                            view.UpdateProgressBar((int)(num * 100 / count));
                        }
                    }
                }
                context.SaveChanges();
                context.Dispose();
                _eventAggregator.GetEvent<DatabaseUpdatedEvent>().Publish(true);
            }
        }

        private Context MyContext(Context context, Report entity, int count, int commitCount, bool recreateContext)
        {
            context.Set<Report>().Add(entity);

            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new Context();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }

            return context;
        }

        internal void AddReportsFasta(int count1)
        {
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\findata2.csv"), false))
            {
                Context context = null;
                Report report = null;
                try
                {
                    context = new Context();

                    context.Configuration.AutoDetectChangesEnabled = false;
                    context.Configuration.ValidateOnSaveEnabled = false;

                    int count = 0;

                    foreach (var entity in csv.ToList())
                    {
                        count++;
                        report = ConvertToReport(entity);
                        context = MyContext(context, report, count, 100, true);
                    }
                    context.SaveChanges();
                }
                finally
                {
                    if (context != null)
                        context.Dispose();
                }
            }
        }

        internal void AddReports()
        {
            AddReportsFasta2(16408);
        }

        internal void SaveDatabase()
        {
            model.Commit();
        }

        internal void CreateDatabase()
        {
            model.Clean();
            AddCompanies();
            AddReports();
        }

        internal void CleanDatabase()
        {
            model.Clean();
            model.DetachAll();
            _eventAggregator.GetEvent<DatabaseUpdatedEvent>().Publish(true);
        }

        #endregion

        //delete relationship
        //db.Entry(report).Reference(r => r.CompanySymbol).CurrentValue = null;
    }
}
