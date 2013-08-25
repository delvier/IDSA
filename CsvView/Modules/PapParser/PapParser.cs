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
        private List<ReportFields> _reportFields;
        #endregion

        #region Ctors
        public PapParser(int reportId)
        {

            InitializeReportFields();

            takeTodaysReports("2013,8,23");
            parseReport(230737);
        }
        #endregion

        #region Public Methods
        public HtmlNode takeTodaysReports(string specificDay)
        {
            specificDay = "2013,8,23";  //default 0,0,0, -> shows the newest adding reports date
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page;

            page = hw.Load(@"http://biznes.pap.pl/NSE/pl/reports/espi/term," + specificDay + ",1");
            //tabela roczna wszystkich raportow     table[1]/tr[x]-ki
            var data = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[1]/div[7]");
            //tabela raportow z danego dnia
            var data1 = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[1]/div[8]");

            return page.DocumentNode;
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
