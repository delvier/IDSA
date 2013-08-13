using System.Collections.Generic;
using IDSA.Views;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Events;
using IDSA.Models;
using IDSA.Events.MainEvents;
using IDSA.Views.CompaniesInternal;
using IDSA.Views.PropertyView;
using IDSA.Presenters.PropertyPresenters;

namespace IDSA.Presenters
{
    public class FinancialMasterTabPresenter
    {
        private readonly InternalTabTest _view;
        private readonly IEventAggregator _eventAggregator;
        private readonly FinancialInternalTabbedProvider _internalTabProvider;
        private readonly IList<IBasicGridPresenter> _observationList;

        public FinancialMasterTabPresenter(InternalTabTest view)
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
                var tabView = new BasicGridView(tabItem.TabPresenterType);
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
    }
}
