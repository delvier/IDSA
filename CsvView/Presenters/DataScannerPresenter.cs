using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views;
using IDSA.Models.Repository;
using IDSA.Modules.DataScanner;
using Microsoft.Practices.ServiceLocation;
using IDSA.Models;

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

        private const int kMultiply = 1000;
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
                    try
                    {
                        filterToAdd._highValue = (Int64.Parse(fcmp.highValue.Text)) * kMultiply;
                        filterToAdd._lowValue = (Int64.Parse(fcmp.lowValue.Text)) * kMultiply;
                        dsmodule.FilterAdd(filterToAdd);
                    }
                    catch (FormatException f)
                    {
                        view.MsgBox(string.Format("Invalid Input Values, {0}",f.Message));
                    }
                }
            }
        }

        public void Scan()
        {
            dsmodule.Scan();
        }

        public IList<Object> GetFilterData()
        {
            return dsmodule.GetSelectedResult().ToList();
        }

        public void UpdateView()
        {
            view.DataUpdate();
        }


    }
}
