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

        public CsvViewController(ICsvView view)
        {
            _view = view;
            _view.SetControler(this);
        }

        public IBindingList LoadCsvFile()
        {
            //string fileName = _view.OpenDialog();
            try
            {
                var ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                { }
                using (var _csvReader = new CachedCsvReader(new StreamReader(ofd.FileName), false))
                {
                    //IBindingList test = _csvReader.AsEnumerable<IBindingList>();
                    return null;
                    //set enums on collumns view.
                    //if (enum.getnames(typeof(csvenums._company)).length < csvdatagrid.columns.count)
                    //{
                    //    _view.BoxMsg("mismatch enum.length != columns.count");
                    //}
                    //// rozkodowanie kolumn.csv - > enum (v)
                    //foreach (csvenums._company cmp in enum.getvalues(typeof(csvenums._company)))
                    //{
                    //    csvdatagrid.columns[(int)cmp].headertext = cmp.tostring();
                    //}

                }
            }
            catch (IOException ex)
            {
                //show error message.
                _view.BoxMsg(ex.Message);
                return null;
            }

            //implementation here.
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