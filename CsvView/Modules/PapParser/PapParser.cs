using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace IDSA.Modules.PapParser
{
    public class ReportStructure
    {
        public int CompanyId
        {
            get
            {
                // TODO: CompanyName.Substring(CompanyName.IndexOf('/'), )
                return 123;
            }
        }
        public string CompanyName { get; set; }
        public string CompanyLink { get; set; }
        public string Link { get; set; }
        public string Kind { get; set; }
    }

    public class HeaderStructure
    {
        public int factor { get; set; }
        public string currency { get; set; }
        public string period { get; set; }
        public int year { get; set; }
        public string periodOld { get; set; }
        public int yearOld { get; set; }
    }

    public class PapParser
    {
        #region Fields
        private HtmlWeb hw;
        private HtmlAgilityPack.HtmlDocument page;
        private List<ReportFields> _reportFields;
        private List<ReportStructure> _reportsStruct;
        #endregion

        #region Ctors
        public PapParser(int reportId)
        {
            hw = new HtmlWeb();
            InitializeReportFields();
            _reportsStruct = getReportsFromDate(date: new DateTime(2013, 8, 23));
            foreach (var report in _reportsStruct)
            {
                parseReport(report.Link);
            }
            //parseReport(230737);
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

        public List<ReportStructure> getReportsFromDate(DateTime? date)
        {
            if (date == null)   //default 0,0,0, -> shows the newest adding reports date
            {
                date = new DateTime(0, 0, 0);
            }
            page = hw.Load(@"http://biznes.pap.pl/NSE/pl/reports/espi/term," +
                        date.Value.Year + "," + date.Value.Month + "," + date.Value.Day + ",1");
            List<ReportStructure> reportsStruct = new List<ReportStructure>();

            //tabela raportow z danego dnia
            var data = page.DocumentNode.SelectSingleNode("/html[1]/body[1]/div[1]/div[12]/div[1]/div[8]/table[1]");
            var rows = data.Descendants("TR");
            string XPathCmp = "./td[3]/a[1]/b[1]";   ///#text[1]
            for (int i = 2; i < rows.Count(); ++i)
            {
                var row = rows.ElementAt(i);
                //struct newestReport{
                //    DateTime time;    //row.ChildNode[1]
                //    String number;    //row.ChildNode[3]
                //    String company;   //row.ChildNode[5] +a href = company link
                //    String title;     //row.ChildNode[7] + <a href = report link(report ID)
                //}
                reportsStruct.Add(new ReportStructure
                {
                    CompanyLink = row.SelectSingleNode(XPathCmp).ParentNode.Attributes["href"].Value,
                    CompanyName = row.SelectSingleNode(XPathCmp).InnerText,
                    Link = row.SelectSingleNode("//td[4]/a[1]").Attributes["href"].Value,
                    Kind = Regex.Match(row.SelectSingleNode("//td[4]/a[1]").InnerText,
                            "[a-zA-Zóżłąę ]+").ToString()
                });
            }
            return reportsStruct;
        }

        public void parseReport(int reportId)
        {
            parseReport("/NSE/pl/reports/espi/view/" + reportId.ToString());
        }

        public void parseReport(string innerUrl)
        {
            page = hw.Load(@"http://biznes.pap.pl" + innerUrl);

            var rows = page.DocumentNode.SelectNodes("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]/tr");

            var header = parseHeader(rows);
                        
            int i = 3;
            if (rows[2].SelectNodes("./td")[1].InnerText.Contains("I."))
            {
                i = 2;
            }

            for (; i < rows.Count(); ++i)
            {
                var row = rows[i].SelectNodes("./td");

                var name = row[1].InnerText.Split('.')[1].Trim();
                
                //TODO: Main POINT! Find fild in report properties!!!
                

                var value = row[2].InnerText.Replace(" ", string.Empty);
                var val = Convert.ToInt64(value) * header.factor;
                value = row[3].InnerText.Replace(" ", string.Empty);
                var valOld = Convert.ToInt64(value) * header.factor;
            }
        }
        #endregion

        #region Private Methods

        private HeaderStructure parseHeader(HtmlNodeCollection rows)
        {
            var headerStructure = new HeaderStructure();

            var headerRow = rows[0].SelectNodes("./td");

            headerStructure.factor = 1;
            if (headerRow[2].InnerText.Contains("tys."))    // row[3] tys.
            {
                headerStructure.factor = 1000;
            }
            else if (headerRow[2].InnerText.Contains("tys."))    // row[3] mln.
            {
                headerStructure.factor = 1000000;
            }

            var currency = headerRow[3].InnerText;      // row[4] zl. EUR
            if (currency.Trim() == string.Empty)
                headerStructure.currency = "PLN";
            else headerStructure.currency = currency.Trim();

            headerRow = rows[1].SelectNodes("./td");

            var t = headerRow[1].InnerText.Split('/');
            headerStructure.period = t[0].Trim();
            headerStructure.year = Convert.ToInt32(t[1].Trim());

            t = headerRow[2].InnerText.Split('/');
            headerStructure.periodOld = t[0].Trim();
            headerStructure.yearOld = Convert.ToInt32(t[1].Trim());

            return headerStructure;
        }
        
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
