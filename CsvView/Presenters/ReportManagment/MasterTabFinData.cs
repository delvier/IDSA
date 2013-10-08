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

        public void InitTabElements ()
        {
            var flowPanel = new FlowLayoutPanel();
            flowPanel.AutoSize = true;
            flowPanel.Dock = DockStyle.Fill;

            //generating base fin data.
            var basePropertiesFinDatas = new PropertiesExtractorService(typeof(FinancialData)).GetBaseProperties();
            foreach (var baseProp in basePropertiesFinDatas)
            {
                var uiElement = new DataControlTabElement(baseProp.Name);
                uiElement.DataBindings.Add("fieldValueText", financialDataBindingSource, baseProp.Name);
                flowPanel.Controls.Add(uiElement);
            }

            //test bind label property.
            var label = new Label() { Text = "Test Bind Label" };
            label.DataBindings.Add("Text" , financialDataBindingSource, "Year");
            flowPanel.Controls.Add(label);

            // master holder flow pan.
            this.Controls.Add(flowPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter.ChangeFinData();
        }
    }
}
