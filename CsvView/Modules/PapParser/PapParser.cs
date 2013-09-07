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
        List<ReportStructure> retrieveYearlyReports(int year);
        //Dictionary<DateTime, List<ReportStructure>> retrieveYearlyReports(int year);
        List<ReportStructure> retrieveReportsFromDate(DateTime startDate, DateTime endDate);
        List<ReportStructure> retrieveReportsFromDate(DateTime? date);

        List<FinancialData> parseReportsFromDate(DateTime startDate, DateTime endDate);
        List<FinancialData> parseReportsFromDate(DateTime? date);
        List<FinancialData> parseReports(List<ReportStructure> reports);
        FinancialData parseReport(ReportStructure report);
    }

    //TODO: Odroznic raport od skonsolidowanego raportu dla danej spolki.
    //Wprowadzic do bazy tylko ten skonsolidowany
    public class PapParser : IPapParser
    {
        #region Fields
        private HtmlWeb hw;
        private HtmlAgilityPack.HtmlDocument page;
        private List<ReportFields> _reportFields;
        #endregion

        #region Ctors
        public PapParser()
        {
            hw = new HtmlWeb();
            InitializeReportFields();
        }
        #endregion

        #region Public Methods
        public List<ReportStructure> retrieveYearlyReports(int year = 2013)
        {
            var repStructure = new List<ReportStructure>();
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
                    repStructure.AddRange(retrieveReportsFromDate(dt));
                }
            }
            return repStructure;
        }

        public List<ReportStructure> retrieveReportsFromDate(DateTime beginDate, DateTime endDate)
        {
            List<ReportStructure> reportsStruct = new List<ReportStructure>();

            for (DateTime day = beginDate; day <= endDate; day = day.AddDays(1))
            {
                reportsStruct.AddRange(retrieveReportsFromDate(day));
            }

            return reportsStruct;
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
                    date = DateTime.Today;
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
                    //TODO: getReportsDataFromRow()
                    var row = rows.ElementAt(i);

                    var temp = row.SelectSingleNode("./td[1]").InnerText.Split(':');
                    TimeSpan reportTime = new TimeSpan(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), 0);

                    var reportType = row.SelectSingleNode("./td[2]").InnerText.
                        Replace('\n', ' ').Replace('\t', ' ').Replace('\r', ' ').Trim();

                    ReportStructure rep = getReportQuarter(reportType, date.Value.Month);
                    rep.ReleaseDate = date.Value;
                    switch(rep.Quarter)
                    {
                        case 1:
                            rep.FinancialStatmentDate = new DateTime(2013, 03, 31);
                            break;
                        case 2:
                            rep.FinancialStatmentDate = new DateTime(2013, 06, 30);
                            break;
                        case 3:
                            rep.FinancialStatmentDate = new DateTime(2013, 09, 30);
                            break;
                        case 4:
                            rep.FinancialStatmentDate = new DateTime(2013, 12, 31);
                            break;
                    }
                    rep.CompanyLink = row.SelectSingleNode(XPathCmp).ParentNode.Attributes["href"].Value;
                    rep.CompanyName = row.SelectSingleNode(XPathCmp).InnerText;
                    rep.Link = row.SelectSingleNode("./td[4]/a[1]").Attributes["href"].Value;

                    reportsStruct.Add(rep);
                }
            } while (++pageX <= numOfPages);

            return reportsStruct;
        }

        public List<FinancialData> parseReportsFromDate(DateTime startDate, DateTime endDate)
        {
            return parseReports(retrieveReportsFromDate(startDate, endDate));
        }

        public List<FinancialData> parseReportsFromDate(DateTime? date)
        {
            return parseReports(retrieveReportsFromDate(date));
        }

        public List<FinancialData> parseReports(List<ReportStructure> reports)
        {
            var finData = new List<FinancialData>();

            foreach (var item in reports)
            {
                finData.Add(parseReport(item));
            }

            return finData;
        }

        public FinancialData parseReport(ReportStructure report)
        {
            FinancialData _financialData = new FinancialData();
            _financialData.IncomeStatement = new IncomeStatmentData();
            _financialData.Balance = new BalanceData();
            _financialData.CashFlow = new CashFlowData();
            var converter = new PapDbCompanyConverter();
            _financialData.CompanyId = converter.ConvertToDbId(report.CompanyName);
            _financialData.Id = Convert.ToInt32(report.Link.Split('/')[5]);
            _financialData.FinancialReportReleaseDate = report.ReleaseDate;
            _financialData.FinancialStatmentDate = report.FinancialStatmentDate;

            page = hw.Load(@"http://biznes.pap.pl" + report.Link);

            var rows = page.DocumentNode.SelectNodes("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]/tr");

            var header = parseHeader(rows);
            _financialData.Year = header.year;

            if (rows.Count() <= 4)       //Financial data not showed on side
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
                if (row[1].InnerText.IndexOf(report.CompanyName, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
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
                            //if (field.Value != 0)
                            //{
                            //    found = true;
                            //    break;
                            //}
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
                            if (value == string.Empty)
                                value = "0";
                            int afterComma = 0;
                            if (value.Contains(','))
                            {
                                afterComma = Convert.ToInt32(value.Split(',')[1]);
                                value = value.Split(',')[0];
                            }
                            field.Value *= Convert.ToInt64(value) * header.factor + afterComma;

                            //Move values from ReportFieldsNames to IncomeStatementData and to BalanceData
                            //Slow because of using REFLECTION ;)
                            var fieldTypeName = field.GetType().Name;
                            var prop = _financialData.IncomeStatement.GetType().GetProperty(fieldTypeName);
                            if (prop != null)
                            {
                                prop.SetValue(_financialData.IncomeStatement, field.Value, null);
                            }
                            else
                            {
                                prop = _financialData.Balance.GetType().GetProperty(fieldTypeName);
                                if (prop != null)
                                {
                                    prop.SetValue(_financialData.Balance, field.Value, null);
                                }
                                else
                                {
                                    prop = _financialData.CashFlow.GetType().GetProperty(fieldTypeName);
                                    prop.SetValue(_financialData.CashFlow, field.Value, null);
                                }
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
            else if (headerRow[2].InnerText.Contains("mln."))    // row[3] mln.
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
            headerStructure.year = Convert.ToInt32(t[1].TrimStart().Split(' ')[0]);

            int temp = 0;
            t = headerRow[i + 2].InnerText.Split('/');
            if (t.Count() == 1)
            {
                t = headerRow[i + 2].InnerText.TrimStart().Split(' ');
                ++temp;
            }
            headerStructure.periodOld = t[temp].Trim();
            if (t[temp + 1].Trim() == string.Empty)
            {
                headerStructure.yearOld = headerStructure.year - 1;
            }
            else
                headerStructure.yearOld = Convert.ToInt32(t[temp + 1].Trim());

            return headerStructure;
        }

        private ReportStructure getReportQuarter(string reportType, int month)
        {
            var rep = new ReportStructure();
            switch (reportType)
            {
                case "QSr":	//Skonsolidowany raport kwartalny
                case "QS":
                case "SA-QS":
                case "SA-QSr":
                    rep.IsConsolidated = true;
                    if (month > 9 || month < 4)  //3 kwartal
                        rep.Quarter = 3;
                    else
                        rep.Quarter = 1;
                    break;
                case "Q":	//Raport kwartalny
                case "SA-Q":
                    if (month > 9 || month < 4)  //3 kwartal
                        rep.Quarter = 3;
                    else
                        rep.Quarter = 1;
                    break;
                case "PSr":	//Skonsolidowany raport półroczny
                case "PS":
                case "SA-PS":
                case "SA-PSr":
                    rep.IsConsolidated = true;
                    rep.Quarter = 2;
                    break;
                case "P":	//Raport półroczny
                case "SA-P":
                    rep.Quarter = 2;
                    break;
                case "RS":	//Skonsolidowany raport roczny
                case "SA-RS":
                    rep.IsConsolidated = true;
                    rep.Quarter = 4;
                    break;
                case "R":	//Raport roczny
                case "SA-R":
                    rep.Quarter = 4;
                    break;
                default:
                    //TODO: FuckUp
                    rep.Quarter = 0;
                    break;
            }
            return rep;
        }

        private void InitializeReportFields()
        {
            // 62 fields
            _reportFields = new List<ReportFields>();

            //Income Statment (17 items)
            _reportFields.Add(new Sales());
            _reportFields.Add(new OwnSaleCosts());
            _reportFields.Add(new SalesCost1());
            _reportFields.Add(new SalesCost2());
            _reportFields.Add(new EarningOnSales());
            _reportFields.Add(new OtherOperationalActivity1());
            _reportFields.Add(new OtherOperationalActivity2());
            _reportFields.Add(new EBIT());
            _reportFields.Add(new FinancialActivity1());
            _reportFields.Add(new FinancialActivity2());
            _reportFields.Add(new OtherCostOrSales());
            _reportFields.Add(new SalesOnEconomicActivity());
            _reportFields.Add(new ExceptionalOccurence());
            _reportFields.Add(new EarningBeforeTaxes());
            _reportFields.Add(new DiscontinuedOperations());
            _reportFields.Add(new NetProfit());
            _reportFields.Add(new NetParentProfit());

            //Cash Flow Data (15 items)
            _reportFields.Add(new OperatingActivitiesCF());
            _reportFields.Add(new Depreciation());
            _reportFields.Add(new ReceivablesChange());
            _reportFields.Add(new ObligationsStateChange());
            _reportFields.Add(new ReserveAndOtherChange());
            _reportFields.Add(new WorkingCapital());
            _reportFields.Add(new InvestmentCF());
            _reportFields.Add(new CapexIntangible());
            _reportFields.Add(new FinancialCF());
            _reportFields.Add(new SharesIssue());
            _reportFields.Add(new LoansAndAdvancesObtained());
            _reportFields.Add(new LoansAndAdvancesRepayed());
            _reportFields.Add(new LiabilitiesChange());
            _reportFields.Add(new Dividend());
            _reportFields.Add(new TotalCF());

            //Balance Data (30 items)
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
