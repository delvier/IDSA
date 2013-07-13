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

        public void Scan()
        {
            _filterData = _cmpList;
            FilterList.ToList<IFilter>().ForEach(f => FilterApplay(f));
        }

        /*
         * Filter attribiutes describe the filtered company property & parentPropertyClass
         */
        private IList GerFilterAttribiutes()
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
