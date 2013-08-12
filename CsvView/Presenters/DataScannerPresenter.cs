using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views;
using IDSA.Models.Repository;
using IDSA.Modules.DataScanner;
using Microsoft.Practices.ServiceLocation;
using IDSA.Models;
using IDSA.Models.DataStruct;
using System.Data;
using IDSA.Modules.CachedDataContainer;
using IDSA.Modules.CachedListContainer;

namespace IDSA.Presenters
{
    public interface IDataScannerPresenter
    {
    }

    public class DataScannerPresenter : IDataScannerPresenter
    {
        private readonly DataScanner _view;
        private readonly DataScanerModule _dsmodule;
        private readonly ICacheService _cache;

        private const int kMultiply = 1000;
        //cached data , easy to handle created once treat as db
        public DataScannerPresenter(DataScanner view)
        {
            this._view = view;
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            this._dsmodule = new DataScanerModule(_cache.GetAll(), ServiceLocator.Current.GetInstance<IRawData>());
        }

        public IList<FilterDescriptor> GetFilters()
        {
            return new FilterListProvider().GetFilters();
        }

        public void LoadFiltersToDataScannerModule (IList<FilterViewComponents> fcmpsList)
        {
            //clear old filters.
            _dsmodule.FilterClearAll();

            foreach (var fcmp in fcmpsList)
            {
                if (!fcmp.filterCmbb.SelectedItem.Equals(null))
                {
                    var filterToAdd = ((FilterDescriptor)fcmp.filterCmbb.SelectedItem).Filter;
                    try
                    {
                        filterToAdd._highValue = (Int64.Parse(fcmp.highValue.Text)) * kMultiply;
                        filterToAdd._lowValue = (Int64.Parse(fcmp.lowValue.Text)) * kMultiply;
                        _dsmodule.FilterAdd(filterToAdd);
                    }
                    catch (FormatException f)
                    {
                        _view.MsgBox(string.Format("Invalid Input Values, {0}",f.Message));
                    }
                }
            }
        }

        public void Scan()
        {
            _dsmodule.Scan();
        }     
   
        public DataTable GetFilterResultDataTable()
        {
            var gridProvider = new GridRawDataTableProvider("Filter Result", _dsmodule.GetRawResult());
            return gridProvider.GetRawDataTable();
        }

        public void UpdateView()
        {
            _view.DataUpdate();
        }


    }
}
