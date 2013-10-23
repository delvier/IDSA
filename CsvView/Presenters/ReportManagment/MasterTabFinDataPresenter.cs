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
    public class MasterTabFinDataPresenter
    {
        private ICacheService _cache;
        private IReportStoreService _reportStoreService;
        private IUserReportActionService _userReportActionService;
        private MasterTabFinData _view;

        public MasterTabFinDataPresenter(MasterTabFinData view)
        {
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            this._reportStoreService = ServiceLocator.Current.GetInstance<IReportStoreService>();
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
        private void disableDataEditControl(String name)
        {
            DataControlTabElementsContainer.Where(i => i.fieldNameText.Contains(name)).First().ValueEditDisabled();
        }

        public void disableAll()
        {
            foreach (var item in DataControlTabElementsContainer)
            {
                item.ValueEditDisabled();
            }
        }

        public void disableProperElements()
        {
            throw new NotImplementedException();
        }
    }
}