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

namespace CsvReaderModule.Controllers
{
    public class VCsvLoadController
    {
        private readonly IVCsvLoad view;
        private IUnitOfWork context;
        //CachedCsvReader _csvModel; // controller model insight.
        
        // IDEAS: 
        // C : select collumns <listOfColumnsToSelect> -> remove or hide ?
        // C : giveOutData for View
        // C : HeaderBasedOnEnum ? V : ?
        // V : refresh view (data from _csvModel)

        public VCsvLoadController(IVCsvLoad view)
        {
            this.view = view;
            //TODO: Use delegate/event here ;)
        }

        public void AddCompany(List<string[]> companies)
        {
            // that should do model it's not csv view controller job...
            // i should provide data for model.
            context = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
            
            context.Companies.Query().Load();
            foreach (var item in companies)
            {
                var company = new Company()
                {
                    Symbol = item[(int)CsvEnums._company.Shortcut],
                    Name = item[(int)CsvEnums._company.Name],
                    Description = item[(int)CsvEnums._company.Description],
                    //Trade = (TRADES)Enum.Parse(typeof(TRADES), item[(int)CsvEnums._company.Profile]),
                    Url = item[(int)CsvEnums._company.Href]
                };
                context.Companies.Add(company);
            }
            context.Commit();
        }

        public void AddReport(List<string[]> reports)
        {
            context = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
            
            context.Reports.Query().Load();
            foreach (var item in reports)
            {
                var report = new Report()
                {
                    //TODO: Problem with Company SYMBOL VS ID ???? KEY !!!!
                    CompanySymbol = item[(int)CsvEnums._financialData.CmpId],
                    //TODO: Problem with conversion from string into ENUM !!!!!!!
                    //Period = item[(int)CsvEnums._financialData.Quater],
                    Year = Convert.ToInt32(item[(int)CsvEnums._financialData.Year]),
                    //NetProfit = item[(int)CsvEnums._financialData.ColumnC],
                    //SalesRevenues = item[(int)CsvEnums._financialData.ColumnF]
                };
                context.Reports.Add(report);
            }
            context.Commit();
        }

        public void selectColumns(List<string> colHeaders)
        {
            //
        }

        // Provide ListOf Enum Names.
        public List<string> getHeaders<T> (int cols)
        {
            List<string> hList = new List<string>();
            if (Enum.GetNames(typeof(T)).Length == cols) // dummy check size ? check types ?
            {
                var arr = Enum.GetNames(typeof(T)); //array
                hList =  arr.ToList<string>();
            }
            return hList;
        }

        public CachedCsvReader LoadCsvFile(string fname)
        {
            //string fileName = _view.OpenDialog();
            if (fname == null)
                return null;
            try
            {
                    return (new CachedCsvReader(new StreamReader(fname), false));
                    //IBindingList test = _csvReader.AsEnumerable<IBindingList>();     
            }
            catch (IOException ex)
            {
                //show error message.
                view.BoxMsg(ex.Message);
                return null;
            }
        }
    }
}

//foreach (DataGridViewColumn col in csvDataGrid.Columns)
//{
//    col.HeaderText = "test";
//    //csvDataGrid.Columns[0].HeaderText = "testName1";
//}

// select columns ? - > transfer to data base.
// zarzadzanie wyswietlaniem kolumn.
// filtracja po wybranych kolumnach


//if (Enum.GetNames(typeof(T)).Length == cols)
//{
//    foreach (T cmp in Enum.GetValues(typeof(T)))
//    {
//        hList.Add(cmp.ToString());
//    }           
//}

//return hList;         