using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBModule;
using LumenWorks.Framework.IO.Csv;

namespace IDSA.Presenters
{
    public class DbViewPresenter
    {
        private IDbView view;
        private IUnitOfWork model;

        public DbViewPresenter(IDbView view)
        {
            this.view = view;
        }

        internal string dbInfo()
        {
            //Task.WaitAll(Program.dbCreate);
            model = ServiceLocator.Instance.Resolve<IUnitOfWork>();
            model.Companies.Query().Load();
            model.Reports.Query().Load();
            return dbChanged();
        }

        internal string dbChanged()
        {
            //model.Companies.Query().Load();
            //model.Reports.Query().Load();
            return "DataBase sum up:\n  Companies  = " +
                    model.Companies.Query().Count() + "\n  Reports       = " +
                    model.Reports.Query().Count();
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

        internal void CreateDatabase()
        {
            // TODO: Recreate Database in this place
            //model = new EFUnitOfWork(new Context(new DropCreateDatabaseAlways<Context>()));
            // progressBar actualize on Tasks

            //TODO: Change this PATH in release: ..\\..\\..\\DataCsvExampales\\company.csv !!!!!!!!!!!!!
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\company.csv"), false))
            {
                foreach (var item in csv.ToList().Take(100))
                {
                    string[] cos = item[(int)CsvEnums._company.Date].Split('-');
                    var company = new Company()
                    {
                        Id = int.Parse(item[(int)CsvEnums._company.Id]),
                        Name = item[(int)CsvEnums._company.Name],
                        Shortcut = item[(int)CsvEnums._company.Shortcut],
                        SharePrice = float.Parse(item[(int)CsvEnums._company.SharePrice], CultureInfo.InvariantCulture),
                        Date = new DateTime(int.Parse(cos[0]), int.Parse(cos[1]), int.Parse(cos[2])),
                        Description = item[(int)CsvEnums._company.Description],
                        Href = item[(int)CsvEnums._company.Href],
                        PhoneNumber = item[(int)CsvEnums._company.PhoneNumber],
                        Email = item[(int)CsvEnums._company.Email],
                        FullName = item[(int)CsvEnums._company.FullName],
                        HeadAccount = item[(int)CsvEnums._company.HeadAccount],
                        Profile = item[(int)CsvEnums._company.Profile],
                        Address = item[(int)CsvEnums._company.Address],
                        HrefStatus = item[(int)CsvEnums._company.HrefStatus],
                        ShareNumbers = Int64.Parse(item[(int)CsvEnums._company.ShareNumbers])
                    };
                    model.Companies.Add(company);
                    // TODO: commit after Xth adding company occurence
                }
                model.Commit();
            }
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\findata2.csv"), false))
            {
                long tempVal;
                foreach (var item in csv.ToList().Take(100))
                {
                    var report = new Report()
                    {
                        Id = int.Parse(item[(int)CsvEnums._financialData.Id]),
                        CompanyId = int.Parse(item[(int)CsvEnums._financialData.CmpId]),
                        Year = int.Parse(item[(int)CsvEnums._financialData.Year]),
                        Quarter = int.Parse(item[(int)CsvEnums._financialData.Quater]),
                        Sales = Int64.TryParse(item[(int)CsvEnums._financialData.Sales], out tempVal) ? tempVal : 0,
                        OwnSaleCosts = Int64.TryParse(item[(int)CsvEnums._financialData.OwnSaleCosts], out tempVal) ? tempVal : 0,
                        SalesCost1 = Int64.TryParse(item[(int)CsvEnums._financialData.SalesCost1], out tempVal) ? tempVal : 0,
                        SalesCost2 = Int64.TryParse(item[(int)CsvEnums._financialData.SalesCost2], out tempVal) ? tempVal : 0,
                        EarningOnSales = Int64.TryParse(item[(int)CsvEnums._financialData.EarningOnSales], out tempVal) ? tempVal : 0,
                        OtherOperationalActivity1 = Int64.TryParse(item[(int)CsvEnums._financialData.OtherOperationalActivity1], out tempVal) ? tempVal : 0,
                        OtherOperationalActivity2 = Int64.TryParse(item[(int)CsvEnums._financialData.OtherOperationalActivity2], out tempVal) ? tempVal : 0,
                        EBIT = Int64.TryParse(item[(int)CsvEnums._financialData.EBIT], out tempVal) ? tempVal : 0,
                        FinancialActivity1 = Int64.TryParse(item[(int)CsvEnums._financialData.FinancialActivity1], out tempVal) ? tempVal : 0,
                        FinancialActivity2 = Int64.TryParse(item[(int)CsvEnums._financialData.FinancialAcvitity2], out tempVal) ? tempVal : 0,
                        OtherCostOrSales = Int64.TryParse(item[(int)CsvEnums._financialData.OtherCostOrSales], out tempVal) ? tempVal : 0,
                        SalesOnEconomicActivity = Int64.TryParse(item[(int)CsvEnums._financialData.SalesOnEconomicActivity], out tempVal) ? tempVal : 0,
                        ExceptionalOccurence = Int64.TryParse(item[(int)CsvEnums._financialData.ExceptionalOccurence], out tempVal) ? tempVal : 0,
                        EarningBeforeTaxes = Int64.TryParse(item[(int)CsvEnums._financialData.EarningBeforeTaxes], out tempVal) ? tempVal : 0,
                        DiscontinuedOperations = Int64.TryParse(item[(int)CsvEnums._financialData.DiscontinuedOperations], out tempVal) ? tempVal : 0,
                        NetProfit = Int64.TryParse(item[(int)CsvEnums._financialData.NetProfit], out tempVal) ? tempVal : 0,
                        NetParentProfit = Int64.TryParse(item[(int)CsvEnums._financialData.NetParentProfit], out tempVal) ? tempVal : 0,
                    };
                    model.Reports.Add(report);
                    // TODO: commit after Xth adding company occurence
                }
                model.Commit();
            }
            //ServiceLocator.Instance.Register<EFUnitOfWork>(model);
        }
        
        #region Testing methods(TODO: delete on the end)

        public void AddRecords()
        {
            var company = new Company
            {
                Id = 9934,
                Name = "Wawel",
                Shortcut = "WWL",
                Href = "http://www.wawel.com.pl/",
                Description = "",
                Date = new DateTime(2007, 12, 21),
                Reports = new ObservableListSource<Report>() 
                {
                    new Report
                    {
                        Id = 9934,
                        Year = 2011,
                        NetProfit = 1000
                    },
                    new Report
                    {
                        Id = 9935,
                        Year = 2012,
                        NetProfit = 3010
                    }
                }
            };

            model.Companies.Add(company);
            model.Commit();
        }

        public void AddsNewCompany()
        {
            //model.Companies.Query().Load();
            var company = new Company
            {
                Id = 1234,
                Shortcut = "WMO",
                Name = "Wind Mobile",
                Description = "Halogranie i Reklamowka",
                Href = "http://www.windmobile.pl",
                Date = new DateTime(2007, 12, 21)
            };
            model.Companies.Add(company);
            model.Commit();

            var report = new Report
            {
                CompanyId = 1234,
                Year = 2011,
                NetProfit = 1000,
                Quarter = 3
            };
            model.Reports.Add(report);
            model.Commit();
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
