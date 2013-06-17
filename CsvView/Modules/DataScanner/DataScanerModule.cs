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
            this._cmpList = Companies;
        }

        #endregion

        #region PublicMethods

        public void Scan()
        {
            foreach (IFilter filter in FilterList)
            {
                this.FilterApplay(filter);
            }
        }

        public void FilterApplay(IFilter filter)
        {
            _filterData = filter.FiltrAction(_cmpList);
        }

        public void FilterRemove(IFilter filter)
        {
            FilterList.Remove(filter);
        }

        public void FilterAdd(IFilter filter)
        {
            FilterList.Add(filter);
        }

        #endregion
        

    }
}
