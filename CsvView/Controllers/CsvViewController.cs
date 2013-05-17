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

namespace CsvReaderModule.Controllers
{
    public class CsvViewController
    {
        ICsvView _view;
        CachedCsvReader _csvModel; // controller model insight.

        // IDEAS: 
        // C : select collumns <listOfColumnsToSelect> -> remove or hide ?
        // C : giveOutData for View
        // C : HeaderBasedOnEnum ? V : ?
        // V : refresh view (data from _csvModel)

        public CsvViewController(ICsvView view)
        {
            _view = view;
            _view.SetControler(this);
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
                _view.BoxMsg(ex.Message);
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


//TODO: Maybe DbService should inherit after UnitOfWork??????

//using (var uow = new EFUnitOfWork())
//{
//    foreach (var item in _csvReader.ToList())
//    {
//        var company = new Company()
//        {
//            Symbol = item[(int)CsvEnums._company.Shortcut],
//            Name = item[(int)CsvEnums._company.Name],
//            Description = item[(int)CsvEnums._company.Description],
//            //Trade = item[(int)CsvEnums._company.Profile],
//            Url = item[(int)CsvEnums._company.Href]
//        };

//        uow.Companies.Add(company);
//    }
//    uow.SaveChanges();
//}

//using (var dbService = new DbService())
//{
//    foreach (var item in _csvReader.ToList())
//    {
//        var company = new Company()
//        {
//            Symbol = item[(int)CsvEnums._company.Shortcut],
//            Name = item[(int)CsvEnums._company.Name],
//            Description = item[(int)CsvEnums._company.Description],
//            //Trade = item[(int)CsvEnums._company.Profile],
//            Url = item[(int)CsvEnums._company.Href]
//        };

//        dbService.AddsNewCompany();
//    }
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