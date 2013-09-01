using HtmlAgilityPack;

namespace IDSA.Modules.PapParser
{
    public class CompanyNameConverter
    {
        public CompanyNameConverter()
        {

        }

        public string ConvertToName(int cmpId)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/term,"
                + cmpId.ToString() + ",0,0,1");
            var data = page.DocumentNode.SelectSingleNode
                ("//a [@href=\"/pl/reports/espi/company/" + cmpId.ToString() + ",0,0,1]\"\b[1]");
            return data.InnerText;
        }

        public string ConvertToDbId(string name)
        {
            if (name.Contains(" SA"))
            {

            }
            return "";
        }
    }
}
