using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.ReportManagment;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Presenters.ReportManagment
{
    class AddReportPresenter
    {
        private IEventAggregator _eventAggregator;
        private AddReport _view;
        //private _internalTabProvider;
        //private IList<IControlReportsPresenter> _observationList;

        public AddReportPresenter(AddReport view)
        {
            this._view = view;
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //this._internalTabProvider = new ControlReportsInternalTab();
            //this._observationList = new List<IControlReportsPresenter>();
            
            /* Events Subscribe */
            //_eventAggregator.GetEvent<UserCompanySelectEvent>().Subscribe(NotifyObservers);
        }
    }
}
