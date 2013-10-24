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
using IDSA.Services;
using IDSA.Presenters.ReportManagment;

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
        private readonly IReportStoreService _reportStore;
        private readonly IUserReportActionService _userReportAction;
        private readonly INewReportGeneratorService _newReportGenerator;


        private IBindingList _reports = new BindingList<FinancialData>();

        public BasicDataControlPresenter(BasicDataControl view)
        {
            this._view = view;
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this._reportStore = ServiceLocator.Current.GetInstance<IReportStoreService>();
            this._userReportAction = ServiceLocator.Current.GetInstance<IUserReportActionService>();
            this._newReportGenerator = ServiceLocator.Current.GetInstance<INewReportGeneratorService>();

            //subscribe to events.
            _eventAggregator.GetEvent<CompanyInDataControlChangeEvent>().Subscribe(UpdateReportsBox);
            _eventAggregator.GetEvent<CompanyInDataControlChangeEvent>().Subscribe(GenerateNewReport);
            _eventAggregator.GetEvent<ReportInDataControlChangeEvent>().Subscribe(UpdateReportFields);
        }

        private void UpdateReportsBox(Company cmp)
        {
            this.ReportsBoxData = new BindingList<FinancialData>(cmp.Reports.ToList());
        }

        private void GenerateNewReport(Company cmp)
        {
            if (_userReportAction.userReportAction == ReportActionEnum.ADD)
	        {
                _reportStore.financialData = _newReportGenerator.GetNewTemplateReport(cmp);
	        }
        }

        private void UpdateReportFields(FinancialData report)
        {
            if (_userReportAction.userReportAction == ReportActionEnum.EDIT ||
                _userReportAction.userReportAction == ReportActionEnum.DELETE)
            {
                _reportStore.financialData = report;
            }
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

        public void SetUserActionType(ReportActionEnum reportActionEnum)
        {
            _userReportAction.userReportAction = reportActionEnum;
        }
    }
}
