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
        }

        public void InitTabElements ()
        {
            var testTabElement = new DataControlTabElement("test");
            //testTabElement.SetFieldName = financialDataBindingSource.
            this.Controls.Add(testTabElement);
        }
    }
}
