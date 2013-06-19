using System;
using System.ComponentModel;
using System.Windows.Forms;
using HtmlAgilityPack;
using IDSA.Models;
using IDSA.Models.Repository;
using IDSA.Services;
using IDSA.Views;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Presenters
{
    public enum TypeOfData
    {
        Exchange, Change, Date, Time
    }

    public class DataFromHtmlPresenter
    {
        DataFromHtmlView _view;
        private readonly IUnitOfWork _dbModel;
        private readonly IDataService<ICompany> _companyDataService;

        public DataFromHtmlPresenter(DataFromHtmlView view)
        {
            this._companyDataService = (IDataService<Company>)(new CompanyDataService());
            this._view = view;
            _dbModel = ServiceLocator.Current.GetInstance<IUnitOfWork>();
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

        private string GetTypeOfData(TypeOfData data, string companyId)
        {
            string link = "//span [@id='aq_" + companyId.ToLower();
            switch(data)
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
    }
}