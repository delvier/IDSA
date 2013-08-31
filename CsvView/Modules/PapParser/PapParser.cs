using HtmlAgilityPack;
using IDSA.Models.DataStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IDSA.Modules.PapParser
{
    /*
     * Propositions of using specific methods:
     * var reportsStruct = retrieveReportsFromDate(date: new DateTime(2013, 8, 23));
     * var reportsStruct = retrieveReportsFromDate(null);
     * 
     */
    public interface IPapParser
    {
        /*
         * Use this moethod wisely.
         * It parse EVERY record from selected year !!!
         * TODO: Need to add delay between parse reports(web crawler).
         */
        List<List<ReportStructure>> retrieveYearlyReports(int year);
        //Dictionary<DateTime, List<ReportStructure>> retrieveYearlyReports(int year);
        List<ReportStructure> retrieveReportsFromDate(DateTime? date);
        List<IFinancialData> parseReports(List<ReportStructure> reports);
        IFinancialData parseReport(ReportStructure report);
        IFinancialData parseReport(int reportId);
        IFinancialData parseReport(string innerUrl);
    }

    public class PapParser : IPapParser
    {
        #region Fields
        private HtmlWeb hw;
        private HtmlAgilityPack.HtmlDocument page;
        private List<ReportFields> _reportFields;
        #endregion

        #region Ctors
        public PapParser(int reportId)
        {
            hw = new HtmlWeb();
            InitializeReportFields();
            //var reportsStruct = retrieveReportsFromDate(date: new DateTime(2013, 8, 23));
            //var reportsStruct = retrieveReportsFromDate(null);

            foreach (var report in retrieveReportsFromDate(null))
            {
                var finData = parseReport(report.Link);
            }
        }
        #endregion

        #region Public Methods
        public List<IFinancialData> parseReports(List<ReportStructure> reports)
        {
            var finData = new List<IFinancialData>();

            foreach (var item in reports)
            {
                finData.Add(parseReport(item.Link));
            }

            return finData;
        }


        public List<List<ReportStructure>> retrieveYearlyReports(int year = 2013)
        {
            var repStructure = new List<List<ReportStructure>>();
            page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term," + year + ",0,0,1");

            //tabela roczna wszystkich raportow
            // (/html[1]/body[1]/div[1]/div[12]/div[1]/div[7]/table[1]");
            var data = page.DocumentNode.SelectSingleNode("//div [@id=\"kratka\"]/table[1]");
            var rows = data.Descendants("tr");

            for (int i = 2; i < 14; ++i)   //for every month
            {
                var row = data.SelectSingleNode("./tr[" + i + "]");
                int counter = 0;
                foreach (var item in row.Descendants("TD"))     //for every day
                {
                    counter++;
                    if (counter == 1)
                        continue;
                    if (item.InnerText == string.Empty)
                        continue;

                    DateTime dt = new DateTime(year, i - 1, counter - 1);
                    int numOfReports = Convert.ToInt32(item.InnerText);
                    repStructure.Add(retrieveReportsFromDate(dt));
                }
            }
            return repStructure;
        }

        public List<ReportStructure> retrieveReportsFromDate(DateTime? date)
        {
            List<ReportStructure> reportsStruct = new List<ReportStructure>();

            int pageX = 1;
            int numOfPages = 0;
            HtmlNode data;

            do
            {
                if (date == null)   //default 0,0,0, -> shows the newest adding reports date
                {
                    page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term,0,0,0,"
                        + pageX.ToString());
                }
                else
                {
                    page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term," +
                            date.Value.Year + "," + date.Value.Month + "," + date.Value.Day + ","
                            + pageX.ToString());
                }

                if (numOfPages == 0)    // Counting pages
                {
                    data = page.DocumentNode.SelectSingleNode("//div [@class=\"stronicowanie\"]/b[2]");
                    numOfPages = data == null ? 1 : Convert.ToInt32(data.InnerText);        
                }

                //tabela raportow
                data = page.DocumentNode.SelectSingleNode("//table [@class=\"espi\"]");

                string XPathCmp = "./td[3]/a[1]/b[1]";

                var rows = data.Descendants("TR");

                for (int i = 2; i < rows.Count(); ++i)
                {
                    var row = rows.ElementAt(i);

                    var temp = row.SelectSingleNode("./td[1]").InnerText.Split(':');
                    TimeSpan reportTime = new TimeSpan(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), 0);

                    //  PSr - Skonsolidowany raport półroczny
                    //  RS - Skonsolidowany raport roczny
                    //  P - Raport półroczny
                    var reportType = row.SelectSingleNode("./td[2]").InnerText.
                        Replace('\n', ' ').Replace('\t', ' ').Replace('\r', ' ').Trim();

                    reportsStruct.Add(new ReportStructure
                    {
                        CompanyLink = row.SelectSingleNode(XPathCmp).ParentNode.Attributes["href"].Value,
                        CompanyName = row.SelectSingleNode(XPathCmp).InnerText,
                        Link = row.SelectSingleNode("./td[4]/a[1]").Attributes["href"].Value,
                        Kind = Regex.Match(row.SelectSingleNode("//td[4]/a[1]").InnerText,
                                "[a-zA-Zóżłąę ]+").ToString()
                    });
                }
            } while (pageX < numOfPages);

            return reportsStruct;
        }

        public IFinancialData parseReport(ReportStructure report)
        {
            return parseReport(report.Link);
        }

        public IFinancialData parseReport(int reportId)
        {
            return parseReport("/pl/reports/espi/view/" + reportId.ToString());
        }

        public IFinancialData parseReport(string innerUrl)
        {
            IFinancialData _financialData = new FinancialData();
            _financialData.IncomeStatement = new IncomeStatmentData();
            _financialData.Balance = new BalanceData();
            _financialData.CashFlow = new CashFlowData();

            page = hw.Load(@"http://biznes.pap.pl" + innerUrl);

            var rows = page.DocumentNode.SelectNodes("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]/tr");

            var header = parseHeader(rows);

            if(rows.Count() <= 4)       //Financial data not showed on side
                return _financialData;

            int i = 3;
            if (rows[4].SelectNodes("./td")[1].InnerText.Contains(" I."))
            {
                i = 4;
            }
            if (rows[2].SelectNodes("./td")[1].InnerText.Contains("I."))
            {
                i = 2;
            }

            bool found;
            for (; i < rows.Count(); ++i)
            {
                var row = rows[i].SelectNodes("./td");

                if (row[1].InnerText.IndexOf("jednostkowe", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    break;
                if (row[1].InnerText.IndexOf("finansowego", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    break;
                if (row[1].InnerText.IndexOf("finansowe ", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                    break;
                if (row[1].InnerText.Trim() == string.Empty)
                    continue;

                var name = row[1].InnerText.Split('.').Last().Trim();

                found = false;
                foreach (var field in _reportFields)
                {
                    foreach (var item in field.Names)
                    {
                        if (string.Equals(item, name))  // Field is found!!!
                        {
                            field.Value = 1;
                            var value = row[2].InnerText.TrimStart();
                            if (value.Contains('('))  //remove brackets
                            {
                                value = value.Replace("(", string.Empty).Replace(")", string.Empty);
                                field.Value = -1;
                            }
                            value = value.Replace(" ", string.Empty).Replace(".", string.Empty);
                            if (value.Contains('-'))
                            {
                                value = value.Replace("-", string.Empty);
                                if (value == string.Empty)
                                    value = "0";
                                else
                                    field.Value = -1;
                            }
                            field.Value *= Convert.ToInt64(value) * header.factor;

                            //Move values from ReportFieldsNames to IncomeStatementData and to BalanceData
                            //Slow because of using REFLECTION ;)
                            var prop = _financialData.IncomeStatement.GetType().GetProperty(field.GetType().Name);
                            if (prop == null)
                            {
                                prop = _financialData.Balance.GetType().GetProperty(field.GetType().Name);
                                prop.SetValue(_financialData.Balance, field.Value, null);
                            }
                            else
                            {
                                prop.SetValue(_financialData.IncomeStatement, field.Value, null);
                            }
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
            }

            //TODO: Move values to IncomeStatementData not by REFLECTION
            //income.Sales = _reportFields[0].Value;

            return _financialData;
        }
        #endregion

        #region Private Methods

        private HeaderStructure parseHeader(HtmlNodeCollection rows)
        {
            var headerStructure = new HeaderStructure();

            int i = 0;
            var headerRow = rows[i].SelectNodes("./td");
            if (headerRow[2].InnerText.Trim() != "WYBRANE DANE FINANSOWE" && headerRow[1].InnerText.Trim() != "WYBRANE DANE FINANSOWE")
            {
                ++i;
                headerRow = rows[i].SelectNodes("./td");
            }

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

            headerRow = rows[i + 1].SelectNodes("./td");

            var t = headerRow[i + 1].InnerText.Split('/');
            headerStructure.period = t[0].Trim();
            headerStructure.year = Convert.ToInt32(t[1].Trim());

            int temp = 0;
            t = headerRow[2].InnerText.Split('/');
            if (t.Count() == 1)
            {
                t = headerRow[2].InnerText.TrimStart().Split(' ');
                ++temp;
            }
            headerStructure.periodOld = t[temp].Trim();
            if (t[temp+1].Trim() == string.Empty)
            {
                headerStructure.yearOld = headerStructure.year - 1;
            }
            else
                headerStructure.yearOld = Convert.ToInt32(t[temp+1].Trim());
            
            return headerStructure;
        }

        private void InitializeReportFields()
        {
            // 32 fields
            _reportFields = new List<ReportFields>();

            _reportFields.Add(new Sales());
            _reportFields.Add(new EarningOnSales());
            _reportFields.Add(new EarningBeforeTaxes());

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
