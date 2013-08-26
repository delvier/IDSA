using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Modules.PapParser
{
    public class PapParser
    {
        #region Fields
        private HtmlWeb hw;
        private HtmlAgilityPack.HtmlDocument page;
        private List<ReportFields> _reportFields;
        private Dictionary<string, string> _cmpRepId;
        #endregion

        #region Ctors
        public PapParser(int reportId)
        {
            hw = new HtmlWeb();

            InitializeReportFields();
            getTodaysReports(date: new DateTime(2013, 8, 23));
            parseReport(230737);
        }
        #endregion

        #region Public Methods
        public void retrieveYearlyReports(int year = 2013)
        {
            page = hw.Load(@"http://biznes.pap.pl/NSE/pl/reports/espi/term," + year + ",0,0,1");

            //tabela roczna wszystkich raportow
            var data = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[1]/div[7]/table[1]");
            foreach (var row in data.Descendants("TR"))
            {
                //TODO: add to list/dictionary
            }
        }

        public /*IEnumerable<KeyValuePair<string, string>>*/ void getTodaysReports(DateTime? date)
        {
            if (date == null)   //default 0,0,0, -> shows the newest adding reports date
            {
                date = new DateTime(0, 0, 0);
            }
            page = hw.Load(@"http://biznes.pap.pl/NSE/pl/reports/espi/term," +
                        date.Value.Year + "," + date.Value.Month + "," + date.Value.Day + ",1");
            
            //tabela raportow z danego dnia
            var data = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[1]/div[8]/table[1]");
            var rows = data.Descendants("TR");
            string XPathCmp = "/html[1]/body[1]/div[1]/div[12]/div[1]/div[8]/table[1]/tr[3]/td[3]/a[1]/b[1]";   ///#text[1]
            for (int i = 2; i < rows.Count(); ++i)
            {
                var row = rows.ElementAt(i);
                //struct newestReport{
                //    DateTime time;    //row.ChildNode[1]
                //    String number;    //row.ChildNode[3]
                //    String company;   //row.ChildNode[5] +a href = company link
                //    String title;     //row.ChildNode[7] + <a href = report link(report ID)
                //}
                var t = row.SelectSingleNode("/tr[3]/td[3]/a[1]/b[1]");
                _cmpRepId.Add(row.SelectSingleNode(XPathCmp).InnerText,
                    row.ChildNodes[7].InnerHtml); //TODO: poprawic wydobycie linka
                //yield return new KeyValuePair<string, string>(
                  //  row.ChildNodes[5].InnerText, row.ChildNodes[7].InnerText);
                
            }
        }

        public void parseReport(int reportId)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://biznes.pap.pl/NSE/pl/reports/espi/view/" + reportId.ToString());

            // /tr[x] (numOfElements-1)/2
            var daneTemp = page.DocumentNode.SelectSingleNode("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]");

            var daneFinansowe = page.DocumentNode.ChildNodes["HTML"].ChildNodes["SPAN"]
                .ChildNodes[25].ChildNodes["TR"].ChildNodes["TD"].ChildNodes["table"];
            var dane = daneFinansowe.ChildNodes.Elements("TR");
            foreach (var row in daneFinansowe.Descendants("TR"))
            {
                //if (row. isHeader(0-3))
                {

                }
                //first row = header
                // row[2] WYBRANE DANE FINANSOWE
                // row[3] tys. mln.
                // row[4] zl. EUR
                foreach (var item in row.Descendants("TD"))
                {

                }
            }
        }
        #endregion

        #region Private Methods
        private void InitializeReportFields()
        {
            // 29 fields
            _reportFields = new List<ReportFields>();
            _reportFields.Add(new AssetsPrimary());
            _reportFields.Add(new LiabilitiesPrimary());
            _reportFields.Add(new FixedAssets());
            _reportFields.Add(new IntangibleAssets());
            _reportFields.Add(new TangibleFixedAssets());
            _reportFields.Add(new LongTermReceivablesFixA());
            _reportFields.Add(new LongTermInvestmentFixA());
            _reportFields.Add(new OtherFixedAssets());
            _reportFields.Add(new CurrentAssets());
            _reportFields.Add(new Inventory());
            _reportFields.Add(new LongTermReceivablesCurA());
            _reportFields.Add(new LongTermInvestmentCurA());
            _reportFields.Add(new Cash());
            _reportFields.Add(new OtherCurentAssets());
            _reportFields.Add(new AssetsForSale());
            _reportFields.Add(new Equity());
            _reportFields.Add(new CapitalMasterFund());
            _reportFields.Add(new ShareOfTreasuryStock());
            _reportFields.Add(new CapitalreserveFund());
            _reportFields.Add(new NonControllingInterests());
            _reportFields.Add(new LongTermLiabilities());
            _reportFields.Add(new SuppliesAndServicesLT());
            _reportFields.Add(new LoansAndAdvancesLT());
            _reportFields.Add(new OtherFinancialLT());
            _reportFields.Add(new OtherLT());
            _reportFields.Add(new ShortTermLiabilities());
            _reportFields.Add(new SuppliesAndServicesST());
            _reportFields.Add(new LoansAndAdvancesST());
            _reportFields.Add(new OtherFinancialST());
            _reportFields.Add(new OtherST());
        }
        #endregion
    }
}
