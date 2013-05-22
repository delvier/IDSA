using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DBModule;
using IDSA.Views;

namespace IDSA.Presenters
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

        #region Test Data Preapre.
        public IBindingList GetTestCompanies()
        {
            var rnd = new Random();
            var testCmps = new BindingList<Company>();
            for (int i = 0; i < rnd.Next(20, 50); i++)
            {
                testCmps.Add(
                    new Company
                        {
                            Name = string.Format("{0} {1}", "Test", i),
                            Description = string.Format("{0} {1}", "Desc", i),
                            Reports = null,
                            Shortcut = string.Format("{0} {1}", "TT", i),
                            Href = "No Url Need"
                        });

            }
            return testCmps;
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



    }
}
