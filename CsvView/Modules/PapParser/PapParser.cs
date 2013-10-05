using HtmlAgilityPack;
using IDSA.Models.DataStruct;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IDSA.Modules.PapParser
{
    /*
     * Propositions of using specific methods:
     * List<FinancialData> finData = parseReportsFromDate(date: new DateTime(2013, 8, 23));
     * List<FinancialData> finData = parseReportsFromDate(null);
     * 
     */
    public interface IPapParser
    {
        /*
         * Use this methods wisely.
         * It parse EVERY record from selected year !!!
         * TODO: Need to add delay between parse reports(web crawler).
         */
        List<ReportStructure> retrieveYearlyReports(int year);
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
        private ReportFields _reportFields;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Ctors
        public PapParser()
        {
            hw = new HtmlWeb();
            _reportFields = new ReportFields();
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
            if (startDate > endDate)
            {
                return parseReports(retrieveReportsFromDate(endDate, startDate));
            }
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
                try
                {
                    finData.Add(parseReport(item));
                }
                catch (Exception e)
                {
                    logger.Error("************************ {0} ************************", e.Message);
                }
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
            _financialData.Company = converter.ConvertToDb(report.CompanyName);
            _financialData.Id = Convert.ToInt32(report.Link.Split('/')[5]);
            _financialData.FinancialReportReleaseDate = report.ReleaseDate;
            _financialData.FinancialStatmentDate = report.FinancialStatmentDate;
            _financialData.Year = report.ReleaseDate.Year;
            _financialData.Quarter = report.Quarter;

            logger.Debug("Start log for report: --------------------- {0} {1} --------------------- \n",
                _financialData.Id, report.CompanyName);

            page = hw.Load(@"http://biznes.pap.pl" + report.Link);
            var rows = page.DocumentNode.SelectNodes("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]/tr");

            var matchStart = Regex.Match(page.DocumentNode.InnerHtml, "WYBRANE DANE FINANSOWE</td>");
            var matchEnd = Regex.Matches(page.DocumentNode.InnerHtml, "KOREKTA RAPORTU</a>");
            var strX = page.DocumentNode.InnerHtml.Substring(matchStart.Index, matchEnd[matchEnd.Count - 1].Index - matchStart.Index);
            var match = Regex.Match(strX, " I. ");

            if (!match.Success)         //Financial data has no data
            {
                return _financialData;
            }

            HeaderStructure header = parseHeader(strX.Substring(0, match.Index));

            //TODO: parseBaseData(strX.Substring(match.Index))

            strX = strX.Substring(match.Index);
            var matches = Regex.Matches(strX, " [VXIL]{1,}. [^<]*");

            foreach (Match item in matches)
            {
                // remove prefix " XVI. "
                int index = item.Value.IndexOf(' ');
                index = item.Value.IndexOf(' ', index + 1);
                var tempMatch = Regex.Match(item.Value.Substring(index + 1), " [VXIL]{1,}. ");

                if (tempMatch.Success == true)  //// remove prefix if is twice
                {
                    index = item.Value.IndexOf(' ', index + 1);
                }

                var field = _reportFields.findKey(item.Value.Substring(index + 1).Trim());
                if (field == null)
                {
                    logger.Debug("Item {0} was NOT FOUND!!!", item.Value.Substring(index + 1));
                    continue;
                }

                // Field is found!!!  get value now
                var str = strX.Substring(item.Value.Length + item.Index, 100);
                var match123 = Regex.Matches(str, "[0-9][0-9,. ]{0,}");
                if (match123.Count == 0 || match123[0].Success != true)
                {
                    match123 = Regex.Matches(str, "[-0-9][-0-9,. ]{0,}");
                    if (match123.Count == 0 || match123[0].Success != true)
                    {
                        logger.Debug("Field {0} HAS UNPROPER value!!!", field);
                        continue;
                    }
                    if (match123[0].Value.Trim() == "-")
                        continue;
                }

                var strVal = match123[0].Value.Replace(" ", string.Empty);
                int afterComma = 0;
                if (strVal.Contains('.'))
                {
                    if (strVal.Split('.').Count() == 3)
                        continue;
                    afterComma = Convert.ToInt32(strVal.Split('.')[1]);
                    afterComma *= header.factor / (int)Math.Pow(10, strVal.Split('.')[1].Length);
                    strVal = strVal.Split('.')[0];
                }

                if (strVal.Contains(','))
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
                            logger.Trace("Value {0} for {1} is not in financialData!!!", val, item.Value);
                            continue;
                        }
                    }
                }
            }

            logger.Debug("End log for report:   --------------------- {0} {1} -------------------\n",
                _financialData.Id, report.CompanyName);

            return _financialData;
        }
        #endregion

        #region Private Methods
        /* ------------------ parse Report's Header ------------------
         * Take from header:
         * year,
         * currency,
         * factor
         -------------------------------------------------------------*/
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
                var currencyMatch1 = Regex.Matches(rows, "EUR ");
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
        #endregion
    }
}
