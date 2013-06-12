using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using IDSA.Models;
using IDSA.Models.Repository;
using LumenWorks.Framework.IO.Csv;
using IDSA.Views;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Presenters
{
    public class DbViewPresenter
    {
        #region Fields and Props
        
        private IDbView view;
        private IUnitOfWork model;
        
        #endregion

        #region Ctors
        
        public DbViewPresenter(IDbView view)
        {
            this.view = view;
        }
        
        #endregion

        #region Event Handlers

        internal string dbCreateDone()
        {
            if (model == null)
            {
                model = ServiceLocator.Current.GetInstance<EFUnitOfWork>();
            }
            return dbUpdateDone();
        }

        internal string dbUpdateDone()
        {
            model.Load();
            return "DataBase sum up:\n  Companies  = " +
                    model.Companies.Query().Count() + "\n  Reports         = " +
                    model.Reports.Query().Count();
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

        internal void AddCompanies(int count)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //TODO: Change this PATH in release: ..\\..\\..\\DataCsvExampales\\company.csv !!!!!!!!!!!!!
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\company.csv"), false))
            {
                //csv.Count();
                int i = 0;
                int compAmount = model.Companies.Query().Count();
                if (compAmount + count > 886)
                    count = 886 - compAmount;
                foreach (var item in csv.ToList().Skip(compAmount).Take(count))
                {
                    string[] cos = item[(int)CsvEnums.company.Date].Split('-');
                    var company = new Company()
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
                    model.Companies.Add(company);
                    i++;
                    if (i == (int)(count/20))
                    {
                        view.UpdateProgressBar((int)(i * 100 / count));
                        //System.Threading.Thread.Sleep(500);
                        //model.Commit();
                    }
                }
                model.Commit();
            }
            sw.Stop();
            view.UpdateLabel("\nComp min: " + sw.Elapsed.Minutes.ToString() + " sec: " + sw.Elapsed.Minutes.ToString());
        }

        internal void AddReports(int count)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            //TODO: Change this PATH in release: ..\\..\\..\\DataCsvExampales\\company.csv !!!!!!!!!!!!!
            using (CachedCsvReader csv = new CachedCsvReader(new StreamReader("..\\..\\..\\DataCsvExampales\\findata2.csv"), false))
            {
                int i = 0;
                long tempVal;
                //int OverallCount = csv.ToList().Count;
                foreach (var item in csv.ToList().Skip(model.Reports.Query().Count()).Take(count))
                {
                    var report = new Report()
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
                    model.Reports.Add(report); //we need to check if cmp id exist in db otherwise ignore add.
                    i++;
                    if (i % 100 == 0)
                    {
                        model.Commit();
                        view.UpdateProgressBar((int)(i * 100 / count ));
                    }
                }
                model.Commit();
            }
            sw.Stop();
            view.UpdateLabel("\nRep min: " + sw.Elapsed.Minutes.ToString() + " sec: " + sw.Elapsed.Minutes.ToString());
        }

        internal void SaveDatabase()
        {
            model.Commit();
        }

        internal void CreateDatabase()
        {
            AddCompanies(886);
            AddReports(16000);
        }

        internal void CleanDatabase()
        {
            // faster way of cleaning database ;) NOT WORKING YET (other views lost connection to model, but it is faster)
            //ServiceLocator.Instance.Resolve<IUnitOfWork>().Dispose();
            //ServiceLocator.Instance.Register<IUnitOfWork>(new EFUnitOfWork(new Context(new DropCreateDatabaseAlways<Context>())));
            //ServiceLocator.Instance.Resolve<DbCreate>().Create();
            model.Companies.RemoveAll();
            model.Reports.RemoveAll();
            model.Commit();
        }

        #endregion

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
            //delete relationship
            //db.Entry(report).Reference(r => r.CompanySymbol).CurrentValue = null;
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

        #endregion
    }
}
