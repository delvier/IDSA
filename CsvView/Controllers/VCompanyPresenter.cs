using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvReaderModule.Views;
using WindowsFormsApplication1;
using DBModule;

namespace CsvReaderModule.Controllers
{
    class VCompanyPresenter
    {
        VCompany view;
        private IUnitOfWork dbModel;
        public VCompanyPresenter(VCompany view)
        {
            this.view = view;
        }

        public List<string> GetCompanies()
        {
            dbModel = ServiceLocator.Instance.Resolve<EFUnitOfWork>();
            List<string> cmpList = new List<string>();
            foreach (var el in dbModel.Companies.GetAll().ToList())
            {
                cmpList.Add(el.Name);
            }
            return cmpList;
        }
    }
}
