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
        string getErrors();
    }

    //TODO: Odroznic raport od skonsolidowanego raportu dla danej spolki.
    //Wprowadzic do bazy tylko ten skonsolidowany
    public class PapParser : IPapParser
    {
        #region Fields
        private HtmlWeb hw;
        private HtmlAgilityPack.HtmlDocument page;
        private List<IReportFields> _IReportFields;
        private string errorContainer;
        #endregion

        #region Ctors
        public PapParser()
        {
            hw = new HtmlWeb();
            InitializeIReportFields();
        }
        #endregion

        #region Public Methods
        public string getErrors()
        {
            return errorContainer;
        }
        
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

                // Reports table
                data = page.DocumentNode.SelectSingleNode("//table [@class=\"espi\"]");
                var rows = data.Descendants("TR");

                // For each report
                for (int i = 2; i < rows.Count(); ++i)
                {
                    reportsStruct.Add(getReportsDataFromRow(rows.ElementAt(i), date.Value));
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
            _financialData.Year = report.ReleaseDate.Year;
            _financialData.Quarter = report.Quarter;

            page = hw.Load(@"http://biznes.pap.pl" + report.Link);

            var rows = page.DocumentNode.SelectNodes("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]/tr");

            //var matchStart = Regex.Match(page.DocumentNode.InnerText, "Nazwa arkusza: WYBRANE DANE FINANSOWE");
            //var matchEnd = Regex.Match(page.DocumentNode.InnerText, "Nazwa arkusza: KOREKTA RAPORTU");
            //var strX = page.DocumentNode.InnerText.Substring(matchStart.Index, matchEnd.Index - matchStart.Index);
            //var match = Regex.Match(strX, " I. ");

            var matchStart = Regex.Match(page.DocumentNode.InnerHtml, "WYBRANE DANE FINANSOWE</td>");
            var matchEnd = Regex.Matches(page.DocumentNode.InnerHtml, "KOREKTA RAPORTU</a>");
            var strX = page.DocumentNode.InnerHtml.Substring(matchStart.Index, matchEnd[matchEnd.Count - 1].Index - matchStart.Index);
            var match = Regex.Match(strX, " I. ");

            if (!match.Success)         //Financial data has no data
            {
                return _financialData;
            }

            HeaderStructure header = parseHeader(strX.Substring(0, match.Index));

            _financialData.Year = header.year;

            //TODO: parseBaseData(rows2.InnerText)

            // container for fields, that are in dict, but not in financialData (for testing purposes)
            errorContainer = string.Empty;

            // Refactoring continue here
            strX = strX.Substring(match.Index);
            var matches = Regex.Matches(strX, " [VXIL]{1,}. [^<]*");

            var reportFields = new ReportFields();

            foreach (Match item in matches)
            {
                // remove prefix " XVI. "
                int index = item.Value.IndexOf(' ');
                index = item.Value.IndexOf(' ', index + 1);
                var tempMatch = Regex.Match(item.Value.Substring(index + 1), " [VXIL]{1,}. ");
                if (tempMatch.Success == true)
                {
                    index = item.Value.IndexOf(' ', index + 1);
                }

                var field = reportFields.findKey(item.Value.Substring(index + 1).Trim());
                if (field == null)
                {
                    throw new Exception("report ID:" + _financialData.Id +
                        "\n" + item.Value.Substring(index + 1) + " IS NOT FOUND!!!!!!");
                    //continue;
                }
                // Field is found!!!  get value now
                var str = strX.Substring(item.Value.Length + item.Index, 100);
                var match123 = Regex.Matches(str, "[0-9][0-9,. ]{0,}");
                if (match123.Count == 0 || match123[0].Success != true)
                {
                    //TODO only - sign instead of numbers
                    match123 = Regex.Matches(str, "[-0-9][-0-9,. ]{0,}");
                    if (match123.Count == 0 || match123[0].Success != true)
                    {
                        throw new Exception("report ID:" + _financialData.Id +
                            "\n" + field + " VALUE IS UNPROPER :(");
                    }
                    if (match123[0].Value.Trim() == "-")
                        continue;
                }

                var strVal = match123[0].Value.Replace(" ", string.Empty);
                if (strVal.Contains('.'))
                {
                    if (strVal.Split('.').Count() == 3)
                        continue;
                }
                int afterComma = 0;
                if (str.Contains(','))
                {
                    afterComma = Convert.ToInt32(strVal.Split(',')[1]);
                    afterComma *= header.factor / (int)Math.Pow(10, strVal.Split(',')[1].Length);
                    strVal = strVal.Split(',')[0];
                }
                long val;
                if (strVal == "-")
                {
                    val = 0;
                }
                else
                    val = Convert.ToInt64(strVal) * header.factor + afterComma;

                if (str.ElementAt(match123[0].Index - 1) == '-'
                    || str.ElementAt(match123[0].Index - 1) == '(') //minus value
                {
                    val *= -1;
                }

                // and write by reflection to object's field
                var prop = _financialData.IncomeStatement.GetType().GetProperty(field);
                if (prop != null)
                {
                    prop.SetValue(_financialData.IncomeStatement, val, null);
                }
                else
                {
                    prop = _financialData.Balance.GetType().GetProperty(field);
                    if (prop != null)
                    {
                        prop.SetValue(_financialData.Balance, val, null);
                    }
                    else
                    {
                        prop = _financialData.CashFlow.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            prop.SetValue(_financialData.CashFlow, val, null);
                        }
                        else
                        {
                            errorContainer += "report ID:" + _financialData.Id +
                                "    " + item.Value + " has value: " + val
                                + " is not in financialData!";
                            continue;
                            //throw new Exception(field + " has value " + val.ToString() + " but NO PROPERTY!!!!!!!!!!!!!");
                        }
                    }
                }
            }



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
                foreach (var field in _IReportFields)
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

                            //Move values from IReportFieldsNames to IncomeStatementData and to BalanceData
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
            //income.Sales = _IReportFields[0].Value;

            return _financialData;
        }
        #endregion

        #region Private Methods

        /*
         * Take from header:
         * year,
         * currency,
         * factor
         */
        private HeaderStructure parseHeader(string rows)
        {
            var headerStructure = new HeaderStructure();

            //Year
            var matches = Regex.Matches(rows, "2[0-9]{3}"); //[</TD> \n\r] vs [ \n\r]{1}
            if (matches.Count >= 2)
            {
                int year = Convert.ToInt32(matches[0].Value);
                int oldYear = Convert.ToInt32(matches[1].Value);

                headerStructure.year = year <= oldYear ? oldYear : year;
            }
            else  //Exceptional occurrence
            {
                matches = Regex.Matches(rows, "2[0-9]{3}-[0-9]{2}-[0-9]{2}");
                if (matches.Count == 8 || matches.Count == 4)
                    headerStructure.year = Convert.ToInt32(matches[0].Value.Substring(0, 4));//TODO: check
            }

            // currency
            var currencyMatch = Regex.Match(rows, "zł");
            if (currencyMatch.Success)
            {
                headerStructure.currency = "PLN";
            }
            else
            {
                var currencyMatch1 = Regex.Matches(rows, "EUR");
                if (currencyMatch1.Count == 2)
                    headerStructure.currency = "EUR";
                else
                    headerStructure.currency = "PLN";
            }

            // factor
            if (Regex.Match(rows, "tys.").Success)
                headerStructure.factor = 1000;
            else if (Regex.Match(rows, "mln.").Success)
                headerStructure.factor = 1000000;
            else
                headerStructure.factor = 1;

            return headerStructure;
        }

        private ReportStructure getReportsDataFromRow(HtmlNode row, DateTime date)
        {
            ReportStructure rep = getReportQuarter(row, date.Month);
            rep.FinancialStatmentDate = getReportFinancialDate(rep.Quarter, date.Year);
            rep.ReleaseDate = date;

            string XPathCmp = "./td[3]/a[1]/b[1]";
            rep.CompanyLink = row.SelectSingleNode(XPathCmp).ParentNode.Attributes["href"].Value;
            rep.CompanyName = row.SelectSingleNode(XPathCmp).InnerText;
            rep.Link = row.SelectSingleNode("./td[4]/a[1]").Attributes["href"].Value;

            return rep;
        }

        private ReportStructure getReportQuarter(HtmlNode row, int month)
        {
            var rep = new ReportStructure();

            var reportType = row.SelectSingleNode("./td[2]").InnerText.
                Replace('\n', ' ').Replace('\t', ' ').Replace('\r', ' ').Trim();

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

        private DateTime getReportFinancialDate(int quarter, int year)
        {
            switch (quarter)
            {
                case 1:
                    return new DateTime(year, 03, 31);
                case 2:
                    return new DateTime(year, 06, 30);
                case 3:
                    return new DateTime(year, 09, 30);
                case 4:
                    return new DateTime(year, 12, 31);
                default:
                    return new DateTime(2000, 12, 31);
            }
        }

        private void InitializeIReportFields()
        {
            // 62 fields
            _IReportFields = new List<IReportFields>();

            //Income Statment (17 items)
            _IReportFields.Add(new Sales());
            _IReportFields.Add(new OwnSaleCosts());
            _IReportFields.Add(new SalesCost1());
            _IReportFields.Add(new SalesCost2());
            _IReportFields.Add(new EarningOnSales());
            _IReportFields.Add(new OtherOperationalActivity1());
            _IReportFields.Add(new OtherOperationalActivity2());
            _IReportFields.Add(new EBIT());
            _IReportFields.Add(new FinancialActivity1());
            _IReportFields.Add(new FinancialActivity2());
            _IReportFields.Add(new OtherCostOrSales());
            _IReportFields.Add(new SalesOnEconomicActivity());
            _IReportFields.Add(new ExceptionalOccurence());
            _IReportFields.Add(new EarningBeforeTaxes());
            _IReportFields.Add(new DiscontinuedOperations());
            _IReportFields.Add(new NetProfit());
            _IReportFields.Add(new NetParentProfit());

            //Cash Flow Data (15 items)
            _IReportFields.Add(new OperatingActivitiesCF());
            _IReportFields.Add(new Depreciation());
            _IReportFields.Add(new ReceivablesChange());
            _IReportFields.Add(new ObligationsStateChange());
            _IReportFields.Add(new ReserveAndOtherChange());
            _IReportFields.Add(new WorkingCapital());
            _IReportFields.Add(new InvestmentCF());
            _IReportFields.Add(new CapexIntangible());
            _IReportFields.Add(new FinancialCF());
            _IReportFields.Add(new SharesIssue());
            _IReportFields.Add(new LoansAndAdvancesObtained());
            _IReportFields.Add(new LoansAndAdvancesRepayed());
            _IReportFields.Add(new LiabilitiesChange());
            _IReportFields.Add(new Dividend());
            _IReportFields.Add(new TotalCF());

            //Balance Data (30 items)
            _IReportFields.Add(new AssetsPrimary());
            _IReportFields.Add(new LiabilitiesPrimary());
            _IReportFields.Add(new FixedAssets());
            _IReportFields.Add(new IntangibleAssets());
            _IReportFields.Add(new TangibleFixedAssets());
            _IReportFields.Add(new LongTermReceivablesFixA());
            _IReportFields.Add(new LongTermInvestmentFixA());
            _IReportFields.Add(new OtherFixedAssets());
            _IReportFields.Add(new CurrentAssets());
            _IReportFields.Add(new Inventory());
            _IReportFields.Add(new LongTermReceivablesCurA());
            _IReportFields.Add(new LongTermInvestmentCurA());
            _IReportFields.Add(new Cash());
            _IReportFields.Add(new OtherCurentAssets());
            _IReportFields.Add(new AssetsForSale());
            _IReportFields.Add(new Equity());
            _IReportFields.Add(new CapitalMasterFund());
            _IReportFields.Add(new ShareOfTreasuryStock());
            _IReportFields.Add(new CapitalreserveFund());
            _IReportFields.Add(new NonControllingInterests());
            _IReportFields.Add(new LongTermLiabilities());
            _IReportFields.Add(new SuppliesAndServicesLT());
            _IReportFields.Add(new LoansAndAdvancesLT());
            _IReportFields.Add(new OtherFinancialLT());
            _IReportFields.Add(new OtherLT());
            _IReportFields.Add(new ShortTermLiabilities());
            _IReportFields.Add(new SuppliesAndServicesST());
            _IReportFields.Add(new LoansAndAdvancesST());
            _IReportFields.Add(new OtherFinancialST());
            _IReportFields.Add(new OtherST());
        }
        #endregion
    }
}
