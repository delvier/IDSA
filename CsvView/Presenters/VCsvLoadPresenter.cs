using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;
using DBModule;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;

namespace CsvReaderModule.Controllers
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
            //Task.WaitAll();
            //model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
        }

        public void AddCompany(List<string[]> companies)
        {
            // that should do model it's not csv view controller job...
            // i should provide data for model.
            model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
            model.Companies.Query().Load();
            foreach (var item in companies.Take(25))
            {
                string[] cos = item[(int)CsvEnums._company.Date].Split('-');
                var company = new Company()
                {
                    Id = Convert.ToInt32(item[(int)CsvEnums._company.Id]),
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
                    ShareNumbers = Convert.ToInt64(item[(int)CsvEnums._company.ShareNumbers]),
                    //Trade = (TRADES)Enum.Parse(typeof(TRADES), item[(int)CsvEnums._company.Profile]),
                };
                model.Companies.Add(company);
            }
            model.Commit();
        }

        public void AddReport(List<string[]> reports)
        {
            model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
            model.Reports.Query().Load();
            foreach (var item in reports.Take(10))
            {
                var report = new Report()
                {
                    Id = int.Parse(item[(int)CsvEnums._financialData.Id]),
                    CompanyId = int.Parse(item[(int)CsvEnums._financialData.CmpId]),
                    Year = int.Parse(item[(int)CsvEnums._financialData.Year]),
                    Quarter = int.Parse(item[(int)CsvEnums._financialData.Quater]),
                    //Sales = Int64.Parse(item[(int)CsvEnums._financialData.Sales]),
                    //OwnSaleCosts = Int64.Parse(item[(int)CsvEnums._financialData.OwnSaleCosts]),
                    //SalesCost1 = Int64.Parse(item[(int)CsvEnums._financialData.SalesCost1]),
                    //SalesCost2 = Int64.Parse(item[(int)CsvEnums._financialData.SalesCost2]),
                    //EarningOnSales = Int64.Parse(item[(int)CsvEnums._financialData.EarningOnSales]),
                    //OtherOperationalActivity1 = Int64.Parse(item[(int)CsvEnums._financialData.OtherOperationalActivity1]),
                    //OtherOperationalActivity2 = Int64.Parse(item[(int)CsvEnums._financialData.OtherOperationalActivity2]),
                    //EBIT = Int64.Parse(item[(int)CsvEnums._financialData.EBIT]),
                    //FinancialActivity1 = Int64.Parse(item[(int)CsvEnums._financialData.FinancialActivity1]),
                    //FinancialActivity2 = Int64.Parse(item[(int)CsvEnums._financialData.FinancialAcvitity2]),
                    //OtherCostOrSales = Int64.Parse(item[(int)CsvEnums._financialData.OtherCostOrSales]),
                    //SalesOnEconomicActivity = Int64.Parse(item[(int)CsvEnums._financialData.SalesOnEconomicActivity]),
                    //ExceptionalOccurence = Convert.ToInt64(item[(int)CsvEnums._financialData.ExceptionalOccurence]),
                    //EarningBeforeTaxes = Int64.Parse(item[(int)CsvEnums._financialData.EarningBeforeTaxes]),
                    //DiscontinuedOperations = Int64.Parse(item[(int)CsvEnums._financialData.DiscontinuedOperations]),
                    //NetProfit = Int64.Parse(item[(int)CsvEnums._financialData.NetProfit]),
                    //NetParentProfit = Int64.Parse(item[(int)CsvEnums._financialData.NetParentProfit]),
                };
                // TODO: Change and add in this way??
                long ExceptionalOccurence;
                Int64.TryParse(item[(int)CsvEnums._financialData.ExceptionalOccurence], out ExceptionalOccurence);
                report.ExceptionalOccurence = ExceptionalOccurence;
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