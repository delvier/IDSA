using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;
using IDSA.Models.DataStruct;
using IDSA.OldServiceLocator;
using IDSA.Modules.CachedDataContainer;

namespace IDSA.Modules.DataScanner
{
    /*
     * Scanner Module provide scanning functionality through /Company/ (DataBase Object).
     * Target is to be able to scan through all Company object properties with useage of different properties filter,
     * 
     * Actual Scanner provide scanning through all Reports properties.
     */
    public class DataScanerModule : IDataScanerModule
    {
        #region Propetries.

        private IList<IFilter> FilterList { get; set; }
        private CompanyDataContainer _cacheCmpList { get; set; }
        private IList<Company> _filterData { get; set; }
        private IRawData  _selectedRawData { get; set; }

        #endregion

        #region Ctors

        public DataScanerModule(IList<Company> Companies, IRawData rawDataProvider)
        {
            FilterList = new List<IFilter>();
            this._cacheCmpList = new CompanyDataContainer(Companies);
            this._selectedRawData = rawDataProvider;
            //TODO: we need to wait for event before sort.
            //_cacheCmpList.SortReports();
        }

        #endregion

        #region PublicMethods

        /*
         * Main scanner activity
         * Scan through company list provided in ctor, with usage of filter list,
         * Each filter have applay metehod which is used by scaner to create result list.
         */
        public void Scan()
        {
            _selectedRawData.SelfClean();
            _cacheCmpList.SortReports();
            _filterData = _cacheCmpList;
            FilterList.ToList<IFilter>().ForEach(f => FilterApplay(f));
            SelectResultProperties();
        }

        /*
         * This full company result hall object, which is hard to display because it's contain to much data.
         */
        public IList<Company> GetResult()
        {
            return _filterData;
        }

        /*
         * Raw Result provide results with selected filtered properties only.
         * format of this data is provide by IRawData <Header,Values>
         */
        public IRawData GetRawResult()
        {
            return _selectedRawData;
        }

        public void SelectResultProperties()
        {
            IList<FilterAttribute> filterAttributes = GetFilterAttribiutes();
            
            foreach (Company company in _filterData)
            {
                var tempDictionary = new Dictionary<String, String>();
                tempDictionary.Add("Company", company.Name);

                foreach (var fa in filterAttributes)
                {
                    tempDictionary.Add(fa.ChildProperty.Name, company.Reports.OrderByDescending(r=>r.FinancialReportReleaseDate)
                                                                     .Take(1).Select(r => BasicPropertyFilter.RtrnNtestedClassPropertyValue(
                                                                         r, fa.ParentPropertyClass, fa.ChildProperty))
                                                                     .First());
                }
                /* fill RawData with Values */
                _selectedRawData.Values.Add(tempDictionary.Values.ToList());

                /* fill RawData Headers */
                if (_selectedRawData.Headers.Count == 0)
                {
                    _selectedRawData.Headers = tempDictionary.Keys.ToList();
                }
            }
        }

        /*
         * Filter attribiutes describe the filtered company property & parentPropertyClass
         */
        private IList<FilterAttribute> GetFilterAttribiutes()
        {
            return FilterList.Select(f => new FilterAttribute
            {
                ParentPropertyClass = f.GetTypeClassFilterProperty(),
                ChildProperty = f.GetFilterProperty()
            }).ToList<FilterAttribute>();
        }
        
        /*
         * Class used to local description of IFilter Type,PropertyInfo atributes.
         */
        private class FilterAttribute
        {
            public Type ParentPropertyClass { get; set; }
            public PropertyInfo ChildProperty { get; set; }
        }

        public void FilterApplay(IFilter filter)
        {
            _filterData = filter.FilterAction(_filterData);
        }

        public void FilterRemove(IFilter filter)
        {
            FilterList.Remove(filter);
        }

        public void FilterAdd(IFilter filter)
        {
            FilterList.Add(filter);
        }

        public void FilterClearAll()
        {
            FilterList.Clear();
        }

        #endregion

    }
}
