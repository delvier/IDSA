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

namespace IDSA.Presenters
{
    class InternalTabTestPresenter
    {
        private InternalTabTest _view;
        private IEventAggregator _eventAggregator;
        private FinancialDataInternalTabbedProvider _internalTabProvider;

        public InternalTabTestPresenter(InternalTabTest view)
        {
            this._view = view;
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this._internalTabProvider = new FinancialDataInternalTabbedProvider();
            /* Events Subscribe */
            _eventAggregator.GetEvent<CompanyChangeEvent>().Subscribe(UpdateInternalTabs);
            
        }

        public void UpdateInternalTabs(Company company)
        {
            _view.Message(company.FullName);
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
