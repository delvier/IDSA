using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public abstract class DataScanerModule : IDataScanerModule
    {
        public IList<IFilter> FilterList {get; private set;}
        public IList<ICompany> DataList {get; set;}
        private IList<ICompany> _filterData { get; set; }

        public void Scan()
        {
            foreach (IFilter filter in FilterList)
            {
                this.FilterApplay(filter);
            }
        }

        public void FilterApplay(IFilter filter)
        {
            _filterData = filter.FiltrAction(DataList);
        }

        public void FilterRemove(IFilter filter)
        {
            FilterList.Remove(filter);
        }

        public void FilterAdd(IFilter filter)
        {
            FilterList.Add(filter);
        }

    }
}
