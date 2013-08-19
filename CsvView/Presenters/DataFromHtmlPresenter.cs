using HtmlAgilityPack;
using IDSA.Models.Repository;
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
        private Dictionary<string, long> values = new Dictionary<string, long>();
        private string data;
        #endregion

        #region Ctors
        public DataFromHtmlPresenter(IDataFromHtmlView view)
        {
            this._view = view;
            _dbModel = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            initializeDictionary();
        }
        #endregion

        #region Public Methods
        public void parsePAP(int reportId)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://biznes.pap.pl/NSE/pl/reports/espi/view/" + reportId.ToString());
            try
            {
                var startMatchPoint = Regex.Match(page.DocumentNode.InnerHtml, "WYBRANE DANE FINANSOWE</td>").Index;
                var endMatchPoint = Regex.Match(page.DocumentNode.InnerHtml, "Nazwa arkusza: <a name=\"[a-z0-9]{10}\">KOREKTA RAPORTU").Index;
                this.data = page.DocumentNode.InnerHtml.Substring(startMatchPoint, endMatchPoint - startMatchPoint);

                var lines = data.Split(new string[] { "</tr>" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var items = line.Split(new string[] { "</td>" }, StringSplitOptions.RemoveEmptyEntries);
                    if (items.Length < 2)
                        continue;
                    var itemName = items[1].Substring(items[1].IndexOf('.') + 1).Trim();
                    itemName = itemName.Replace("*", string.Empty);
                    if (values.ContainsKey(itemName))
                    {
                        var itemValue = items[2].Substring(items[2].IndexOf('>') + 1).Trim();
                        itemValue = itemValue.Replace(" ", string.Empty);
                        itemValue = itemValue.Replace(".", string.Empty);
                        values[itemName] = Convert.ToInt64(itemValue);
                    }

                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Page with ID " + reportId + " not found");
            }
        }

        public string getInfo()
        {
            return data;
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
        private void initializeDictionary()
        {
            values.Add("Przychody ze sprzedaży", 0);
            values.Add("Strata operacyjna", 0);
            values.Add("Strata przed opodatkowaniem", 0);
            values.Add("Przychody z tytułu odsetek", 0);
            values.Add("Przychody z tytułu prowizji", 0);
            values.Add("Zysk (strata) brutto", 0);
            values.Add("Zysk (strata) netto", 0);
            values.Add("Całkowite dochody", 0);
            values.Add("Zmiana stanu środków pieniężnych", 0);
            values.Add("Aktywa razem", 0);

            values.Add("Kapitał własny", 0);
            values.Add("Kapitał zakładowy", 0);
            //values.Add("Wartość księgowa na jedną akcję (w zł/EUR)", 0);
            //values.Add("Współczynnik wypłacalności (w %)", 0);
            //values.Add("Zysk (strata) na jedną akcję zwykłą (w zł/EUR)", 0);
            //values.Add("Rozwodniony zysk (strata) na jedną akcję (w zł/EUR)", 0);
            //values.Add("Zadeklarowana lub wypłacona dywidenda na jedną akcję (w zł/EUR)", 0);
        }

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