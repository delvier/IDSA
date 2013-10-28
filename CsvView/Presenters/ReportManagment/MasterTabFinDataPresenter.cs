using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Models.DataStruct;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using IDSA.Services;
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel;
using IDSA.Presenters.ReportManagment;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public class MasterTabFinDataPresenter : IDisposable
    {
        private ICacheService _cache;
        private IReportStoreService _reportStoreService;
        private IUserReportActionService _userReportActionService;
        private MasterTabFinData _view;

        public MasterTabFinDataPresenter(MasterTabFinData view)
        {
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            this._reportStoreService = ServiceLocator.Current.GetInstance<IReportStoreService>();
            this._userReportActionService = ServiceLocator.Current.GetInstance<IUserReportActionService>();
            this._view = view;

            this.DataControlTabElementsContainer = new List<DataControlTabElement>();

            ((NotificationObject)_reportStoreService).PropertyChanged += new PropertyChangedEventHandler(report_PropertyChanged);
        }

        public void report_PropertyChanged(object s, PropertyChangedEventArgs e)
        {
            _view.Refresh();
        }

        public FinancialData GetFinData()
        {
            return _reportStoreService.financialData;
        }
        
        /* 
         * 
         DataControlTabElements - ManagmentService
         * 
         */
        public IList<DataControlTabElement> DataControlTabElementsContainer { get; set; }
        
        /*
         * Disabl data edit on control given name
         */
        private void DisableDataEditControls(IList<String> elements)
        {
            foreach (var disableItem in elements)
            {
                DisableDataEditControl(disableItem);
            }
        }

        private void DisableDataEditControl(String name)
        {
            DataControlTabElementsContainer.Where(i => i.fieldNameText.Contains(name)).First().ValueEditDisabled();
        }

        public void DisableAll()
        {
            foreach (var item in DataControlTabElementsContainer)
            {
                item.ValueEditDisabled();
            }
        }

        /*
         * Prevents some key fields from edit possibility
         */
        public void DisableProperElements()
        {
            var disableElementsList = new ReportDisableElementsProvider().
                                          GetDisableElementsList(_userReportActionService.userReportAction);
            if (disableElementsList == null)
            {
                DisableAll();
            }
            else
	        {
                DisableDataEditControls(disableElementsList);
	        }
        }

        /* clear all the mess */
        public void Dispose()
        {
            ((NotificationObject)_reportStoreService).PropertyChanged -= new PropertyChangedEventHandler(report_PropertyChanged);
        }
    }
}