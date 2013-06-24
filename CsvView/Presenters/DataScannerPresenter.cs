using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views;
using IDSA.Models.Repository;
using IDSA.Modules.DataScanner;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Presenters
{
    public interface IDataScannerPresenter
    {
        
    }
    public class DataScannerPresenter : IDataScannerPresenter
    {
        DataScanner view;
        private readonly IUnitOfWork uow;
        private readonly FilterListProvider fprovider;
        private readonly DataScanerModule dsmodule;
        //cached data , easy to handle created once treat as db
        public DataScannerPresenter(DataScanner view)
        {
            this.view = view;
            this.uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            this.fprovider = new FilterListProvider();
            this.dsmodule = new DataScanerModule(uow.Companies.GetAll());
        }

        public IList<FilterDescriptor> GetFilters()
        {
            return fprovider.GetFilters();
        }

        public void LoadFiltersToDataScannerModule (IList<FilterViewComponents> fcmpsList)
        {
            //clear old filters.
            dsmodule.FilterClearAll();

            foreach (var fcmp in fcmpsList)
            {
                if (!fcmp.filterCmbb.SelectedItem.Equals(null))
                {
                    var filterToAdd = ((FilterDescriptor)fcmp.filterCmbb.SelectedItem).Filter;
                    filterToAdd._highValue = int.Parse(fcmp.highValue.Text);
                    filterToAdd._lowValue = int.Parse(fcmp.lowValue.Text);
                    dsmodule.FilterAdd(filterToAdd);
                }
            }
        }

        public void Scan()
        {
            dsmodule.Scan();
        }
    }
}
