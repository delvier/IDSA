﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters.BasicViewsPresenters;
using Microsoft.Practices.Prism.Events;
using IDSA.Views.BasicViews;
using IDSA.Services;
using IDSA.Models.DataStruct;

namespace IDSA.Presenters.ReportManagment
{
    public partial class MasterTabFinData : UserControl
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly MultiTabFinDataPresenter _presenter;

        public MasterTabFinData()
        {
            _presenter = new MultiTabFinDataPresenter();
            InitializeComponent();
            financialDataBindingSource.DataSource = _presenter.GetFinData();
            //after base init.
            InitTabElements();
        }

        public void InitTabElements()
        {
            var financialBaseDataFlowPanel = new FlowLayoutPanel();
            financialBaseDataFlowPanel.AutoSize = true;
            financialBaseDataFlowPanel.Dock = DockStyle.Fill;

            //generating base fin data
            var basePropertiesFinData = new PropertiesExtractorService(typeof(FinancialData)).GetBaseProperties();
            foreach (var baseProp in basePropertiesFinData)
            {
                var uiElement = new DataControlTabElement(baseProp.Name);
                uiElement.DataBindings.Add("fieldValueText", financialDataBindingSource, baseProp.Name);
                financialBaseDataFlowPanel.Controls.Add(uiElement);
            }

            /* this should be done by using provider ? */
            var tabPage = new TabPage("BaseData");
            tabPage.Controls.Add(financialBaseDataFlowPanel);
            masterTabControl.Controls.Add(tabPage);

            foreach (var tabDescriptor in new FinancialDataTabDescriptorProvider().GetDescriptors())
            {
                var tabPage2 = new TabPage(tabDescriptor.Header);
                tabPage2.Controls.Add(
                    buildFlowPanelBasedOnBindingSource(financialDataBindingSource, tabDescriptor.Header, tabDescriptor.View)
                    );
                masterTabControl.Controls.Add(tabPage2);    
            }
        }

        /*
         * Used to build bindable flow panels for the tabs.
         */
        private FlowLayoutPanel buildFlowPanelBasedOnBindingSource
            (BindingSource mainBindingSource, String bindingPropertyName, Type dataType)
        {
            var internalFlowPanel = new FlowLayoutPanel();
            internalFlowPanel.AutoSize = true;
            internalFlowPanel.Dock = DockStyle.Fill;

            var innerDataBindingSource = new BindingSource(mainBindingSource, bindingPropertyName);

            var propertiesCollection = dataType.GetProperties();
            foreach (var property in propertiesCollection)
            {
                var uiElement = new DataControlTabElement(property.Name);
                uiElement.DataBindings.Add("fieldValueText", innerDataBindingSource, property.Name);
                internalFlowPanel.Controls.Add(uiElement);
            }
            return internalFlowPanel;
        }
    }
}
