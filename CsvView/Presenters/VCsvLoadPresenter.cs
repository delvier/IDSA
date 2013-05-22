using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBModule;
using LumenWorks.Framework.IO.Csv;

namespace IDSA.Presenters
{
    public class VCsvLoadPresenter
    {
        private readonly IVCsvLoad view;
        private IUnitOfWork model;
        //CachedCsvReader _csvModel; // controller model insight.

        // IDEAS: 
        // C : select collumns <listOfColumnsToSelect> -> remove or hide ?
        // C : giveOutData for View
        // C : HeaderBasedOnEnum ? V : ?
        // V : refresh view (data from _csvModel)

        public VCsvLoadPresenter(IVCsvLoad view)
        {
            this.view = view;
            //TODO: Use delegate/event here ;)
        }

        public void OnLoad()
        {
            Task.WaitAll();
            model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
        }

        public void AddCompany(List<string[]> companies)
        {
            // that should do model it's not csv view controller job...
            // i should provide data for model.
            model.Companies.Query().Load();
            foreach (var item in companies.Take(25))
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
                    ShareNumbers = Int64.Parse(item[(int)CsvEnums._company.ShareNumbers]),
                    //Trade = (TRADES)Enum.Parse(typeof(TRADES), item[(int)CsvEnums._company.Profile]),
                };
                model.Companies.Add(company);
            }
            model.Commit();
        }

        public void AddReport(List<string[]> reports)
        {
            model.Reports.Query().Load();
            long tempVal;
            foreach (var item in reports.Take(30))
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
            }
            model.Commit();
        }

        // Provide ListOf Enum Names.
        public List<string> getHeaders<T>(int cols)
        {
            List<string> hList = new List<string>();
            if (Enum.GetNames(typeof(T)).Length == cols) // dummy check size ? check types ?
            {
                var arr = Enum.GetNames(typeof(T)); //array
                hList = arr.ToList<string>();
            }
            return hList;
        }

        public CachedCsvReader LoadCsvFile(string fname)
        {
            if (fname == null)
                return null;
            try
            {
                return (new CachedCsvReader(new StreamReader(fname), false));
                //IBindingList test = _csvReader.AsEnumerable<IBindingList>();     
            }
            catch (IOException ex)
            {
                view.BoxMsg(ex.Message);
                return null;
            }
        }
    }
}