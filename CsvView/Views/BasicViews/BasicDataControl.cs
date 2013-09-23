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

namespace IDSA.Views.BasicViews
{
    public abstract partial class BasicDataControl : UserControl
    {
        protected IEventAggregator _eventAggregator;
        protected BasicDataControlPresenter _presenter;

        protected bool EnableReportBox { set { reportsBox.Visible = value; } }
        protected bool EnableCompanyBox { set { companyBox.Visible = value; } }

        public BasicDataControl()
        {
            this._presenter =  new BasicDataControlPresenter(this);
            this._eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();

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
            var structDict = new PropertiesExtractorService(typeof(FinancialData)).GetStructureDict();
            // *****************************
            // optimalize as viewProvider.cs
            foreach (var dictElement in structDict)
            {
                var flowPanel = new FlowLayoutPanel();
                flowPanel.AutoSize = true;
                flowPanel.Dock = DockStyle.Fill;
                flowPanel.AutoScrollMinSize = new System.Drawing.Size(350, 350);
                foreach (var prop in dictElement.Value)
                {
                    flowPanel.Controls.Add(new DataControlTabElement(prop.Name));
                }
                var singleTabPage = new TabPage(dictElement.Key);
                singleTabPage.Controls.Add(flowPanel);
                tabDataControl.Controls.Add(singleTabPage);    
            }
            // ******** TODO: This should be done by some tabprovider, or sth *******
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
