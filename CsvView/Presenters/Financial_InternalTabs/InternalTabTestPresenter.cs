using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Events;
using IDSA.Models;
using IDSA.Events.MainEvents;
using IDSA.Views.CompaniesInternal;
using System.Windows.Forms;
using IDSA.Views.PropertyView;

namespace IDSA.Presenters
{
    public class InternalTabTestPresenter
    {
        private InternalTabTest _view;
        private IEventAggregator _eventAggregator;
        private FinancialInternalTabbedProvider _internalTabProvider;

        public InternalTabTestPresenter(InternalTabTest view)
        {
            this._view = view;
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this._internalTabProvider = new FinancialInternalTabbedProvider();
            /* Events Subscribe */
            _eventAggregator.GetEvent<CompanyChangeEvent>().Subscribe(UpdateInternalTabs);
            
        }

        public void InitInternalTabs()
        {
            foreach (var tabItem in _internalTabProvider.GetViews())
            {
                var tabView = (Control)ServiceLocator.Current.GetInstance(tabItem.View);
                _view.AddInternalTab(tabView, tabItem.Header);
            }
        }

        public void UpdateInternalTabs(Company company)
        {
            //_view.Message(company.FullName);
           
            /*
             * GetListOfInternalTabs.
             * ReadCompanyDataTypeNeeded
             * GiveOutNeededData
             */ 
        }

        /* Lista WIODKOW, 
         * 
         * Widok-1, <- Event(DataUpdate) <- Delegata(CompanyChanged) 
         * Widok-2, <- Event <- Delegate
         * Widok-3, <- Event <- Delegate
         * 
         * CompaniesPresenter -> Noitfy(Presenter)
         * Presenter -> Observing(CompaniesPresenter-CompanyChangeEvent)
         * Presenter -> Notifying(<Observer>List)
         * 
         */
    }
}
