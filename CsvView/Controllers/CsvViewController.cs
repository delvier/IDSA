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
    public class CsvViewController
    {
        private readonly ICsvView view;
        private IUnitOfWork model;
        //CachedCsvReader _csvModel; // controller model insight.

        // IDEAS: 
        // C : select collumns <listOfColumnsToSelect> -> remove or hide ?
        // C : giveOutData for View
        // C : HeaderBasedOnEnum ? V : ?
        // V : refresh view (data from _csvModel)

        public CsvViewController(ICsvView view)
        {
            this.view = view;
            Task.Factory.StartNew(() => ServiceLocator.Instance.Register(
                new EFUnitOfWork(
                new Context(new CreateDatabaseIfNotExists<Context>())
                )));
            //TODO: Use delegate/event here ;)
            //view.SetControler(this);
        }

        public void AddCompany(List<string[]> companies)
        {
            // TODO: Use new Context object of EFUnit Of Work to this presenter.
            // using( var context = ServiceLocator.Instance.Resolve<EFUnitOfWork>()) { ... }
            Task.WaitAll();
            model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
            model.Companies.Query().Load();
            
            foreach (var item in companies)
            {
                var company = new Company()
                {
                    Symbol = item[(int)CsvEnums._company.Shortcut],
                    Name = item[(int)CsvEnums._company.Name],
                    Description = item[(int)CsvEnums._company.Description],
                    //Trade = item[(int)CsvEnums._company.Profile],
                    Url = item[(int)CsvEnums._company.Href]
                };
                model.Companies.Add(company);
            }
            // TODO: Commit in other Task??? Not necessary
            model.Commit();
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
        
        public void Dispose()
        {
            model.Dispose();
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