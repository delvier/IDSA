using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters.BasicViewsPresenters;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using IDSA.Events.DataControlEvents;
using IDSA.Models;
using IDSA.Models.DataStruct;
using System.Reflection;
using System.Collections;
using IDSA.Services;
using IDSA.Presenters.ReportManagment;

namespace IDSA.Views.BasicViews
{
    public abstract partial class BasicDataControl : UserControl
    {
        protected IEventAggregator _eventAggregator;
        protected BasicDataControlPresenter _presenter;

        protected bool EnableReportBox { set { reportsBox.Visible = value; } }
        protected bool EnableCompanyBox { set { companyBox.Visible = value; } }

        private FinancialInternalTabProvider _internalTabProvider;

        public BasicDataControl()
        {
            this._presenter =  new BasicDataControlPresenter(this);
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            this._internalTabProvider = new FinancialInternalTabProvider();

            InitializeComponent();
            InitPresenterData();
            InitInternalTabs();

            /*presenter events subscribe*/
            _presenter.CompanyDataChange += new PropertyChangedEventHandler((s, e) => Bind());
        }

        private void companyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventAggregator.GetEvent<CompanyInDataControlChangeEvent>()
                .Publish((Company)companyBox.SelectedItem);
        }

        private void reportsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _eventAggregator.GetEvent<ReportInDataControlChangeEvent>()
                .Publish((FinancialData)reportsBox.SelectedItem);
        }

        private void InitPresenterData()
        {
            companyBox.DataSource = _presenter.CompanyBoxData;
            companyBox.DisplayMember = "Name";

            reportsBox.DataSource = _presenter.ReportsBoxData;
            reportsBox.DisplayMember = "Id";

            SetActionBtnLabel();
            SetVisibleBoxOption();
        }

        private void InitInternalTabs ()
        {
            //foreach (TabPage tabPage in _internalTabProvider.GetTabs() )
            //{
            //    tabDataControl.Controls.Add(tabPage);  
            //}
            var tabPage = new TabPage();
            var view = (Control)new MasterTabFinData();
            view.Dock = DockStyle.Fill;
            tabPage.Controls.Add(view);
            tabDataControl.Controls.Add(tabPage);
                
        }

        public void Bind()
        {
            //companyBox.DataSource = _presenter.CompanyBoxData;
            reportsBox.DataSource = _presenter.ReportsBoxData;
        }

        public abstract void SetActionBtnLabel();
        public abstract void SetVisibleBoxOption();
        public abstract void BtnOnClickAction();
    }
}
