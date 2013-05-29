using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IDSA.Models;
using IDSA.Models.Repository;
using IDSA.Services;
using IDSA.Views;

namespace IDSA.Presenters
{
    class VCompanyPresenter
    {
        VCompany view;
        private IUnitOfWork dbModel;

        private readonly IDataService<Company> _companyDataService;
        private IEnumerable<Company> _cmpData;

        public VCompanyPresenter(VCompany view)
        {
            this._companyDataService = (IDataService<Company>)(new CompanyDataService());
            this.view = view;
            //delegates
            ServiceLocator.Instance.Resolve<DbCreate>().DbCreateDone += view.RefreshView;
        }

        public IBindingList GetDbCompanies()
        {
            var cmpBindList = new BindingList<Company>();
            if (dbModel == null)
                dbModel = ServiceLocator.Instance.Resolve<IUnitOfWork>();
            cmpBindList = dbModel.Companies.GetAll();
            return cmpBindList;
        }

        #region Test Data Generation
        public IEnumerable GetTestCompanies()
        {
            _cmpData = _companyDataService.GetData().Take(100).ToList();
            return _cmpData;
        }

        public IBindingList GetTestBindList()
        {
            var rnd = new Random();
            var testData = new BindingList<Company>();
            for (int i = 0; i < rnd.Next(5, 15); i++)
            {
                testData.Add(
                    new Company
                    {
                        Name = "Types" + i
                    });
            }
            return testData;
        }

        #endregion

        public IBindingList GetFilterBox(string lookForCompany)
        {
            var cmpBindList = dbModel.Companies.GetAll(); //return original data from Store
            var showList = new BindingList<Company>();

            if (!string.IsNullOrEmpty(lookForCompany))
            {
                foreach (Company ele in cmpBindList)
                {
                    if (ele.Name.Contains(lookForCompany) || ele.Shortcut.Contains(lookForCompany))
                    {
                        showList.Add(ele);
                    }
                }
                return showList;
            }
            else
                return cmpBindList;
        }
    }
}
