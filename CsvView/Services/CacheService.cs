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
        private CompanyDataContainer _dataContainer;
        private IEventAggregator _eventAggregator;

        public CacheService(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _dbModel = ServiceLocator.Current.GetInstance<IUnitOfWork>();            
            _dataContainer = new CompanyDataContainer(_dbModel.Companies.GetAll());
            /*initial sort*/
            SortReports();
        }

        public void SortReports()
        {
            _dataContainer.SortReports();
        }

        public IList<Company> GetAll()
        {
            return _dataContainer;
        }

        public Models.Company GetCompany(String name)
        {
            return _dataContainer.GetCompany(name);
        }

        public void RefreshData()
        {
            _dataContainer._cacheLst = _dbModel.Companies.GetAll();
        }

        public IBindingList GetAllInBindingList()
        {
            return new BindingList<Company>(GetAll());
        }
    }
}
