using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models.Repository;
using Microsoft.Practices.ServiceLocation;
using IDSA.Modules.CachedDataContainer;
using Microsoft.Practices.Prism.Events;
using IDSA.Models;
using System.ComponentModel;

namespace IDSA.Modules.CachedListContainer
{
    /*
     * Layer below database, this service provide easy access to cache data from db.
     */
    public class CacheService : ICacheService
    {
        private IUnitOfWork _dbModel;
        private CompanyDataContainer _companyContainer;
        private ReportsCacheDataContainner _reportsContainer;
        private IEventAggregator _eventAggregator;

        public CacheService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _dbModel = ServiceLocator.Current.GetInstance<IUnitOfWork>();            
            _companyContainer = new CompanyDataContainer(_dbModel.Companies.GetAll());
            _reportsContainer = new ReportsCacheDataContainner(_dbModel.Reports.GetAll());
            /*initial sort*/
            SortReports();
        }

        public void SortReports()
        {
            _companyContainer.SortReports();
        }

        public IList<Company> GetAllCompanies()
        {
            return _companyContainer;
        }

        public Models.Company GetCompany(String name)
        {
            return _companyContainer.GetCompany(name);
        }

        public void RefreshData()
        {
            _companyContainer._cacheLst = _dbModel.Companies.GetAll();
        }

        public IBindingList GetAllInBindingList()
        {
            return new BindingList<Company>(GetAllCompanies());
        }


        public IList<Models.DataStruct.FinancialData> GetAllReports()
        {
            return _reportsContainer._cacheLst;
        }
    }
}
