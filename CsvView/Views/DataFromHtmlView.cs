using IDSA.Presenters;
using Microsoft.Practices.Prism.Events;
using System;
using System.Windows.Forms;

namespace IDSA.Views
{
    public interface IDataFromHtmlView
    {
    }

    public partial class DataFromHtmlView : UserControl, IDataFromHtmlView
    {
        private readonly DataFromHtmlPresenter presenter;
        private readonly IEventAggregator _eventAggregator;

        public DataFromHtmlView(IEventAggregator eventAggregator)
        {
            presenter = new DataFromHtmlPresenter(this);
            _eventAggregator = eventAggregator;
            //_eventAggregator.GetEvent<DatabaseCreatedEvent>().Subscribe(RefreshView);
            InitializeComponent();
        }

        private void searchExchangeBtn_Click(object sender, EventArgs e)
        {
            int reportId = 230737;
            presenter.parsePAP(reportId);
            exchangeLabel.Text = presenter.GetExchangeFromHtmlAddress(compIDTextBox.Text);
        }

        //private void RefreshView(bool isCreated)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.Invoke(new Action(() => RefreshView(isCreated)));
        //    }
        //    else
        //    {
        //        this.InitCompaniesList();
        //    }
        //}

        //private void InitCompaniesList()
        //{
        //}
    }
}