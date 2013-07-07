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
            FilterList.ToList<IFilter>().ForEach(f => FilterApplay(f));
            /** DebugMode **/
            SelectProperProperties();
        }

        public void SelectProperProperties()
        {
            /* get all data from filter list */
            var filteredInfo = FilterList.Select(f => new
                                                {
                                                    classInfo = f.GetTypeClassFilterProperty(),
                                                    propertyInfo = f.GetFilterProperty()
                                                }).ToList();

            // TODO: Implement dynamic selection by propertyInfo / ClassType to dig into... !
            var test = _filterData.Select(c => new
                               {
                                    name = c.Name,
                                    shareNumbers = c.ShareNumbers,
                                    sharePrice = c.SharePrice,
                                    netProfit = c.Reports.First().IncomeStatement.NetProfit,
                                    fixedAssets = c.Reports.First().Balance.FixedAssets

                                }).ToList();
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
