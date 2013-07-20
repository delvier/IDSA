using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections;

namespace IDSA.Modules.DataScanner
{
    public class DataScanerModule : IDataScanerModule
    {
        #region Propetries.

        private IList<IFilter> FilterList { get; set; }
        private IList<Company> _cmpList { get; set; }
        private IList<Company> _filterData { get; set; }
        private IList<Object>  _slectedPropertiesResult { get; set; }

        #endregion

        #region Ctors

        public DataScanerModule(IList<Company> Companies)
        {
            this.FilterList = new List<IFilter>();
            this._cmpList = Companies;
        }

        #endregion

        #region PublicMethods

        public IList<Company> GetResult()
        {
            return _filterData;
        }

        public IList<Object> GetSelectedResult()
        {
            return _slectedPropertiesResult;
        }

        public void Scan()
        {
            _filterData = _cmpList;
            FilterList.ToList<IFilter>().ForEach(f => FilterApplay(f));

            SelectResultProperties();
        }

        public void SelectResultProperties()
        {
            IList<FilterAttribute> filterAttributes = GetFilterAttribiutes();
            IList<Object> result = new List<Object>();
            
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
                result.Add(tempDictionary.Values.ToList());
                // add list attributes.
            }
            // TODO: Prepare well formated ILIST - from Dictionary ?
            _slectedPropertiesResult = result;
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
