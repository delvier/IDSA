using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IDSA.Models.DataStruct;

namespace IDSA.Modules.PapParser
{
    public class ReportStructure
    {
        public string CompanyName { get; set; }
        public int CompanyId
        {
            get
            {
                if (string.Empty == CompanyLink)
                    return 0;
                return Convert.ToInt32(CompanyName.Split('/')[5].Split(',')[0]);
            }
        }
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
        //private IFinancialData _financialData;
        #endregion

        #region Ctors
        public PapParser(int reportId)
        {
            hw = new HtmlWeb();
            InitializeReportFields();
            //_reportsStruct = getReportsFromDate(date: new DateTime(2013, 8, 23));
            _reportsStruct = getReportsFromDate(null);
            /*
             * Test reports:
             * 241020 and 241021
             */

            //TODO: move model to other class
            //IUnitOfWork model = ServiceLocator.Current.GetInstance<IUnitOfWork>();

            foreach (var report in _reportsStruct)
            {
                var finData = parseReport(report.Link);
                //model.Reports.Add(finData);
            }
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
            /*  TODO:
             * Dodac obsluge Pages.
             * Na stronie PAP, jezeli mamy wiecej, niz 20 raportow, to sa one rozmieszczone
             * na kolejnych stronach :(
             */
            if (date == null)   //default 0,0,0, -> shows the newest adding reports date
            {
                page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term,0,0,0,1");
            }
            else
            {
                page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term," +
                        date.Value.Year + "," + date.Value.Month + "," + date.Value.Day + ",1");
            }

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
                    Link = row.SelectSingleNode("./td[4]/a[1]").Attributes["href"].Value,
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

        public IFinancialData parseReport(string innerUrl)
        {
            IFinancialData _financialData = new FinancialData();
            _financialData.IncomeStatement = new IncomeStatmentData();
            _financialData.Balance = new BalanceData();
            _financialData.CashFlow = new CashFlowData();

            page = hw.Load(@"http://biznes.pap.pl" + innerUrl);

            var rows = page.DocumentNode.SelectNodes("/html[1]/span[1]/table[5]/tr[1]/td[1]/table[1]/tr");
            var header = parseHeader(rows);

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

                if (!row[1].InnerText.Contains(". "))
                {
                    if (row[1].InnerText.Trim() != string.Empty)
                        break;
                    continue;
                }
                if (row[1].InnerText.IndexOf("jednostkowe", 0, StringComparison.CurrentCultureIgnoreCase) != -1 && i > 5)
                {
                    break;
                }
                if (row[1].InnerText.Trim() == string.Empty || row[1].InnerText.Contains("sp&oacute;łka") && i > 5)
                    break;
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
                            if (value == "-")
                                value = "0";
                            field.Value *= Convert.ToInt64(value) * header.factor;

                            //Move values from ReportFieldsNames to IncomeStatementData and to BalanceData
                            //Slow because using REFLECTION ;)
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

            t = headerRow[2].InnerText.Split('/');
            headerStructure.periodOld = t[0].Trim();
            try
            {
                headerStructure.yearOld = Convert.ToInt32(t[1].Trim());
            }
            catch (FormatException)
            {
                headerStructure.yearOld = headerStructure.year - 1;
            }

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
