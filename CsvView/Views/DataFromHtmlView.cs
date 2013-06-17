using System;
using System.Windows.Forms;
using IDSA.Presenters;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using IDSA.Models.Repository;
using IDSA.Services;
using IDSA.Events;

namespace IDSA.Views
{
    public partial class DataFromHtmlView : UserControl
    {
        DataFromHtmlPresenter presenter;
        private readonly IEventAggregator _eventAggregator;

        public DataFromHtmlView(IEventAggregator eventAggregator, IUnitOfWork uow, IChartService chart)
        {
            presenter = new DataFromHtmlPresenter(this, uow, chart);
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<DatabaseCreatedEvent>().Subscribe(RefreshView);
            InitializeComponent();
            //ServiceLocator.Instance.Register(new DataFromHtmlPresenter(this));
            //presenter = ServiceLocator.Instance.Resolve<DataFromHtmlPresenter>();
        }

        private void searchExchangeBtn_Click(object sender, EventArgs e)
        {
            exchangeLabel.Text = presenter.GetExchangeFromHtmlAddress(compIDTextBox.Text);
        }

        private void RefreshView(bool isCreated)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => RefreshView(isCreated)));
            }
            else
            {
                this.InitCompaniesList();
            }
        }

        private void InitCompaniesList()
        {
        }
    }
}