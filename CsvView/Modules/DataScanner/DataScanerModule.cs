using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

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
            foreach (IFilter filter in FilterList)
            {
                this.FilterApplay(filter);
            }
        }

        public void SelectProperProperties()
        {
            // TODO: StartHere. !
            _filterData.Select(c => new
            {
                
            }).ToList();
            // get all properties filters and class.
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
