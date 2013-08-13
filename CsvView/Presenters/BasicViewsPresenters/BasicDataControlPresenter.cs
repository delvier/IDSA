using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Models;
using IDSA.Models.DataStruct;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel;
using IDSA.Events.MainEvents;
using Microsoft.Practices.Prism.Events;
using IDSA.Events.DataControlEvents;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public interface IBasicDataControlPresenter
    {
        IBindingList CompanyBoxData { get; }
        IBindingList ReportsBoxData { get; }
        event PropertyChangedEventHandler CompanyDataChange;
    }

    public class BasicDataControlPresenter : IBasicDataControlPresenter
    {
        private readonly BasicDataControl _view;
        private readonly ICacheService _cache;
        private readonly IEventAggregator _eventAggregator;

        private IBindingList _reports = new BindingList<FinancialData>();

        public BasicDataControlPresenter(BasicDataControl view)
        {
            this._view = view;
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            //subscribe to events.
            _eventAggregator.GetEvent<CompanyInDataControlChangeEvent>().Subscribe(UpdateData);
        }

        private void UpdateData(Company cmp)
        {
            this.ReportsBoxData = new BindingList<FinancialData>(cmp.Reports.ToList());
        }

        public IBindingList CompanyBoxData
        {
            get { return _cache.GetAllInBindingList(); }
        }

        public IBindingList ReportsBoxData
        {
            get { return this._reports; }
            set
            {
                if (this._reports != value)
                {
                    this._reports = value;
                    NotifyPropertyChanged("ReportsBoxData");
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (CompanyDataChange != null)
                CompanyDataChange(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler CompanyDataChange;
    }
}
