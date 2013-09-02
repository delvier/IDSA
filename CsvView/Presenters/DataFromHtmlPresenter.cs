using HtmlAgilityPack;
using IDSA.Models.DataStruct;
using IDSA.Models.Repository;
using IDSA.Modules.PapParser;
using IDSA.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace IDSA.Presenters
{
    public enum TypeOfData
    {
        Exchange, Change, Date, Time
    }

    public class DataFromHtmlPresenter
    {
        #region Props
        private readonly IDataFromHtmlView _view;
        private readonly IUnitOfWork _dbModel;
        private readonly IPapParser _papParser;
        private Dictionary<string, long> values = new Dictionary<string, long>();
        #endregion

        #region Ctors
        public DataFromHtmlPresenter(IDataFromHtmlView view)
        {
            this._view = view;
            _dbModel = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _papParser = ServiceLocator.Current.GetInstance<IPapParser>();
        }
        #endregion

        #region Public Methods
        public string parsePapReports(DateTime? date)
        {
            IReportsCrawler crawler = new ReportsCrawler();
            int counter = 0;
            foreach (var report in _papParser.parseReportsFromDate(date))
            {
                _dbModel.Reports.Add(report);
                //TODO: Show to user report.CompanyNames
                ++counter;
            }

            return counter.ToString() + " new reports saved in Db";
        }
        
        public string GetExchangeFromHtmlAddress(string companyId)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://stooq.pl/q/?s=" + companyId.ToLower());
            string exchange;
            try
            {
                exchange = String.Format("{0} ({1}) \n {2}, {3}",
                    page.DocumentNode.SelectSingleNode(GetTypeOfData(TypeOfData.Exchange, companyId)).InnerText,
                    page.DocumentNode.SelectSingleNode(GetTypeOfData(TypeOfData.Change, companyId)).InnerText,
                    page.DocumentNode.SelectSingleNode(GetTypeOfData(TypeOfData.Date, companyId)).InnerText,
                    page.DocumentNode.SelectSingleNode(GetTypeOfData(TypeOfData.Time, companyId)).InnerText);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("ID not found");
                return "";
            }
            return exchange;
        }
        #endregion

        #region Private Methods
        private string GetTypeOfData(TypeOfData data, string companyId)
        {
            string link = "//span [@id='aq_" + companyId.ToLower();
            switch (data)
            {
                case TypeOfData.Exchange:
                    link += "_c2']";
                    break;
                case TypeOfData.Change:
                    link += "_m2']";
                    break;
                case TypeOfData.Date:
                    link += "_d3']";
                    break;
                case TypeOfData.Time:
                    link += "_t2']";
                    break;
                default:
                    break;
            }
            return link;
        }
        #endregion
    }
}