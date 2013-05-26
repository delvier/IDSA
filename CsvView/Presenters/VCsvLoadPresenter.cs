using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBModule;
using LumenWorks.Framework.IO.Csv;
using IDSA.Models;

namespace IDSA.Presenters
{
    public class VCsvLoadPresenter
    {
        private readonly IVCsvLoad view;
        private IUnitOfWork model;
        private CsvModel _csvModel;

        public CsvEnums.DataType dataType { get; set; }
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
            Task.WaitAll(Program.dbCreate);
            model = ServiceLocator.Instance.Resolve<IUnitOfWork>();
        }

        public void AddCompany(List<string[]> companies)
        {
            // that should do model it's not csv view controller job...
            // i should provide data for model.
            model.Companies.Query().Load();
            foreach (var item in companies.Take(25))
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
                    ShareNumbers = Int64.Parse(item[(int)CsvEnums.company.ShareNumbers]),
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
                model.Reports.Add(report);
            }
            model.Commit();
        }

        // Provide ListOf Enum Names.
        public List<string> getHeaders<T>()
        {
            List<string> hList = new List<string>();
            if (Enum.GetNames(typeof(T)).Length == _csvModel.RowSize) // dummy check size ? check types ?
            {
                var arr = Enum.GetNames(typeof(T)); //array
                hList = arr.ToList<string>();
            }
            else
            {
                view.BoxMsg("Size do not match");
            }
            return hList;
        }

        public bool LoadCsvFile(string fname, CsvEnums.DataType typeOf)
        {
            if (fname == null)
                return false;
            try
            {
                _csvModel = new CsvModel((new CachedCsvReader(new StreamReader(fname), false)), typeOf);
                return true;  
            }
            catch (IOException ex)
            {
                view.BoxMsg(ex.Message);
                return false;
            }
        }

        public CachedCsvReader GetCsvData ()
        {
            return _csvModel.GetSourceData();
        }

    }
}