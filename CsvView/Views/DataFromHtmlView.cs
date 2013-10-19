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
        #region Fields And Props
        private readonly DataFromHtmlPresenter presenter;
        private readonly IEventAggregator _eventAggregator;
        #endregion

        #region Ctor
        public DataFromHtmlView(IEventAggregator eventAggregator)
        {
            presenter = new DataFromHtmlPresenter(this);
            _eventAggregator = eventAggregator;
            //_eventAggregator.GetEvent<DatabaseCreatedEvent>().Subscribe(RefreshView);
            InitializeComponent();
        }
        #endregion

        private void searchExchangeBtn_Click(object sender, EventArgs e)
        {
            this.errors.Text = presenter.parsePapReports(this.startDatePicker.Value.Date, this.endDatePicker.Value.Date, false);
            //exchangeLabel.Text = presenter.GetExchangeFromHtmlAddress(compIDTextBox.Text);
        }

        private void UpdateDB_Click(object sender, EventArgs e)
        {
            this.errors.Text = presenter.updateDatabase();
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