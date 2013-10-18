using HtmlAgilityPack;
using IDSA.Models.Repository;
using IDSA.Modules.CachedListContainer;
using IDSA.Modules.PapParser;
using IDSA.Services;
using IDSA.Views;
using Microsoft.Practices.ServiceLocation;
using System;
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
        private readonly IPapParser _papParser;
        private readonly DbManageService _dbManageService;
        #endregion

        #region Ctors
        public DataFromHtmlPresenter(IDataFromHtmlView view)
        {
            this._view = view;
            _papParser = ServiceLocator.Current.GetInstance<IPapParser>();
            _dbManageService = ServiceLocator.Current.GetInstance<DbManageService>();
        }
        #endregion

        #region Public Methods
        public string updateDatabase()
        {
            //only for testing purposes
            //_papParser.GetCompanyDataFromPAP("AGORA SA", 18);
            //var names = _papParser.GetCompanyNames(); 
            //_dbManageService.ComparePapDbCompanyNames(names);
            
            _dbManageService.Update1CompanyNames();
            _dbManageService.Update2CompanyNames();
            
            return "DB successfully updated\n";
        }

        public string parsePapReports(DateTime startDate, DateTime endDate, bool saveReportsInDb)
        {
            var finData = _papParser.parseReportsFromDate(startDate, endDate);

            if (saveReportsInDb)
            {
                _dbManageService.AddReportsToDb(finData);
            }

            var str = finData.Count.ToString() + " new reports parsed.\n";

            foreach (var report in finData)
            {
                str += "cmpID: " + report.CompanyId + "  Q: " + report.Quarter
                    + "  Y: " + report.Year + "  ID: " + report.Id
                    + "  Assets: " + report.Balance.AssetsPrimary
                    + "  successfully parsed.\n";
            }
            return str;
        }

        public bool startReportsCrawler()
        {
            IReportsCrawler crawler = new ReportsCrawler();

            return true;
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