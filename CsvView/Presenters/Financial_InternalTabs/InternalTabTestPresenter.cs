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
using IDSA.Presenters.PropertyPresenters;

namespace IDSA.Presenters
{
    public class InternalTabTestPresenter
    {
        private InternalTabTest _view;
        private IEventAggregator _eventAggregator;
        private FinancialInternalTabbedProvider _internalTabProvider;
        private IList<IBasicGridPresenter> _observationList;

        public InternalTabTestPresenter(InternalTabTest view)
        {
            this._view = view;
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this._internalTabProvider = new FinancialInternalTabbedProvider();
            this._observationList = new List<IBasicGridPresenter>();
            /* Events Subscribe */
            _eventAggregator.GetEvent<CompanyChangeEvent>().Subscribe(NotifyObservers);
            
        }

        public void InitInternalTabs()
        {
            foreach (var tabItem in _internalTabProvider.GetViews())
            {
                var tabView = new BasicGridView(tabItem.TabPresenter);
                _view.AddInternalTab(tabView, tabItem.Header);
                _observationList.Add(tabView.GetPresenterHandler());
            }
        }

        public void NotifyObservers(Company company)
        {
            foreach (IBasicGridPresenter internalTabPresenter in _observationList)
            {
                internalTabPresenter.DataUpdate(company);
            }
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
