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
using IDSA.Models.DataStruct;

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
            string[] companySplitDate = item[(int)CsvEnums.company.Date].Split('-');
            return new Company()
            {
                Id = int.Parse(item[(int)CsvEnums.company.Id]),
                Name = item[(int)CsvEnums.company.Name],
                Shortcut = item[(int)CsvEnums.company.Shortcut],
                SharePrice = float.Parse(item[(int)CsvEnums.company.SharePrice], CultureInfo.InvariantCulture),
                Date = new DateTime(int.Parse(companySplitDate[0]), int.Parse(companySplitDate[1]), int.Parse(companySplitDate[2])),
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
                ReportId = int.Parse(item[(int)CsvEnums.financialData.Id]),
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

        private FinancialData ConvertToFinData(string[] item)
        {
            /* 
             * mapping should be done by function like:
             * getType(Object) ,  csvItemList[] , getCsvFor( -object-type )
             * foreach (Object.propetriesList) -> match (property <-> csvEnumType) -> setThisPropertyValue -> return ready Obj.
             */
            var finData = new FinancialData()
            {
                Id = int.Parse(item[(int)CsvEnums.financialData.Id]),
                CompanyId = int.Parse(item[(int)CsvEnums.financialData.CmpId]),
                Year = int.Parse(item[(int)CsvEnums.financialData.Year]),
                Quarter = int.Parse(item[(int)CsvEnums.financialData.Quater])
                //TODO = {"The conversion of a datetime2 data type to a datetime data type resulted in an out-of-range value.\r\nThe statement has been terminated."}
                //TODO : Investigate why this throw exception ? out of range int32 ?
                //Id = int.Parse(item[(int)BaseFinData.BaseFinDataKey.Id]),
                //CompanyId = int.Parse(item[(int)BaseFinData.BaseFinDataKey.CmpId]),
                //Year = int.Parse(item[(int)BaseFinData.BaseFinDataKey.Year]),
                //Quarter = int.Parse(item[(int)BaseFinData.BaseFinDataKey.Quater])
            };

            long tempVal;
            var incStatmentFinData = new IncomeStatmentData()
            {
                Sales = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.Sales], out tempVal) ? tempVal : 0,
                OwnSaleCosts = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.OwnSaleCosts], out tempVal) ? tempVal : 0,
                SalesCost1 = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.SalesCost1], out tempVal) ? tempVal : 0,
                SalesCost2 = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.SalesCost2], out tempVal) ? tempVal : 0,
                EarningOnSales = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.EarningOnSales], out tempVal) ? tempVal : 0,
                OtherOperationalActivity1 = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.OtherOperationalActivity1], out tempVal) ? tempVal : 0,
                OtherOperationalActivity2 = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.OtherOperationalActivity2], out tempVal) ? tempVal : 0,
                EBIT = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.EBIT], out tempVal) ? tempVal : 0,
                FinancialActivity1 = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.FinancialActivity1], out tempVal) ? tempVal : 0,
                FinancialActivity2 = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.FinancialAcvitity2], out tempVal) ? tempVal : 0,
                OtherCostOrSales = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.OtherCostOrSales], out tempVal) ? tempVal : 0,
                SalesOnEconomicActivity = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.SalesOnEconomicActivity], out tempVal) ? tempVal : 0,
                ExceptionalOccurence = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.ExceptionalOccurence], out tempVal) ? tempVal : 0,
                EarningBeforeTaxes = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.EarningBeforeTaxes], out tempVal) ? tempVal : 0,
                DiscontinuedOperations = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.DiscontinuedOperations], out tempVal) ? tempVal : 0,
                NetProfit = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.NetProfit], out tempVal) ? tempVal : 0,
                NetParentProfit = Int64.TryParse(item[(int)IncomeStatmentData.IncomeStatmentDataKey.NetParentProfit], out tempVal) ? tempVal : 0,
            };

            var balanceFinData = new BalanceData()
            {
                AssetsForSale     = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.AssetsForSale], out tempVal) ? tempVal : 0,
                AssetsPrimary     = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.AssetsPrimary], out tempVal) ? tempVal : 0,
                CapitalMasterFund = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.CapitalMasterFund], out tempVal) ? tempVal : 0,
                CapitalreserveFund = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.CapitalreserveFund], out tempVal) ? tempVal : 0,
                Cash = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.Cash], out tempVal) ? tempVal : 0,
                CurrentAssets = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.CurrentAssets], out tempVal) ? tempVal : 0,
                Equity = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.Equity], out tempVal) ? tempVal : 0,
                FixedAssets = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.FixedAssets], out tempVal) ? tempVal : 0,
                IntangibleAssets = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.IntangibleAssets], out tempVal) ? tempVal : 0,
                Inventory = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.Inventory], out tempVal) ? tempVal : 0,
                LiabilitiesPrimary = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LiabilitiesPrimary], out tempVal) ? tempVal : 0,
                LoansAndAdvancesST = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LoansAndAdvancesST], out tempVal) ? tempVal : 0,
                LoansAndAdvancesLT = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LoansAndAdvancesLT], out tempVal) ? tempVal : 0,
                LongTermInvestmentCurA = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LongTermInvestmentCurA], out tempVal) ? tempVal : 0,
                LongTermInvestmentFixA = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LongTermInvestmentFixA], out tempVal) ? tempVal : 0,
                LongTermLiabilities = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LongTermLiabilities], out tempVal) ? tempVal : 0,
                LongTermReceivablesCurA = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LongTermReceivablesCurA], out tempVal) ? tempVal : 0,
                LongTermReceivablesFixA = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.LongTermReceivablesFixA], out tempVal) ? tempVal : 0,
                NonControllingInterests = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.NonControllingInterests], out tempVal) ? tempVal : 0,
                OtherCurentAssets = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.OtherCurentAssets], out tempVal) ? tempVal : 0,
                OtherFinancialLT = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.OtherFinancialLT], out tempVal) ? tempVal : 0,
                OtherFinancialST = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.OtherFinancialST], out tempVal) ? tempVal : 0,
                OtherFixedAssets = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.OtherFixedAssets], out tempVal) ? tempVal : 0,
                OtherLT = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.OtherLT], out tempVal) ? tempVal : 0,
                OtherST = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.OtherST], out tempVal) ? tempVal : 0,
                ShareOfTreasuryStock = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.ShareOfTreasuryStock], out tempVal) ? tempVal : 0,
                ShortTermLiabilities = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.ShortTermLiabilities], out tempVal) ? tempVal : 0,
                SuppliesAndServicesLT = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.SuppliesAndServicesLT], out tempVal) ? tempVal : 0,
                SuppliesAndServicesST = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.SuppliesAndServicesST], out tempVal) ? tempVal : 0,
                TangibleFixedAssets = Int64.TryParse(item[(int)BalanceData.BalanceDataKey.TangibleFixedAssets], out tempVal) ? tempVal : 0,
            };

            var cashFlowFinData = new CashFlowData()
            {
                CapexIntangible = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.CapexIntangible], out tempVal) ? tempVal : 0,
                Depreciation = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.Depreciation], out tempVal) ? tempVal : 0,
                Dividend = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.Dividend], out tempVal) ? tempVal : 0,
                FinancialCF = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.FinancialCF], out tempVal) ? tempVal : 0,
                InvestmentCF = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.InvestmentCF], out tempVal) ? tempVal : 0,
                LiabilitiesChange = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.LiabilitiesChange], out tempVal) ? tempVal : 0,
                LoansAndAdvancesObtained = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.LoansAndAdvancesObtained], out tempVal) ? tempVal : 0,
                LoansAndAdvancesRepayed = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.LoansAndAdvancesRepayed], out tempVal) ? tempVal : 0,
                ObligationsStateChange = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.ObligationsStateChange], out tempVal) ? tempVal : 0,
                OperatingActivitiesCF = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.OperatingActivitiesCF], out tempVal) ? tempVal : 0,
                ReceivablesChange = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.ReceivablesChange], out tempVal) ? tempVal : 0,
                ReserveAndOtherChange = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.ReserveAndOtherChange], out tempVal) ? tempVal : 0,
                SharesIssue = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.SharesIssue], out tempVal) ? tempVal : 0,
                TotalCF = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.TotalCF], out tempVal) ? tempVal : 0,
                WorkingCapital = Int64.TryParse(item[(int)CashFlowData.CalshFlowDataKey.WorkingCapital], out tempVal) ? tempVal : 0,
            };

            // bind all to obj.
            finData.IncomeStatement = incStatmentFinData;
            finData.Balance = balanceFinData;
            finData.CashFlow = cashFlowFinData;

            return finData;
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
                context.FinData.Load();
                int num = 0;

                int repAmount = context.FinData.Count();
                if (repAmount + count > 16408)
                    count = 16408 - repAmount;
                foreach (var entity in csv.ToList().Skip(repAmount).Take(count))
                {
                    num++;
                    context.FinData.Add(ConvertToFinData(entity));
                    if (num % 100 == 0)
                    {
                        context.SaveChanges();
                        for (int i = 0; i < 100; ++i)
                        {
                            context.Entry(context.FinData.Local[0]).State = System.Data.EntityState.Detached;
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
