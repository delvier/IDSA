using HtmlAgilityPack;
using IDSA.Models.Repository;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Modules.PapParser
{
    public class PapDbCompanyConverter
    {
        public PapDbCompanyConverter()
        {
            
        }

        public string ConvertToName(int cmpId)
        {
            HtmlWeb hw = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/company/"
                + cmpId.ToString() + ",0,0,1");
            var data = page.DocumentNode.SelectSingleNode
                ("//a [@href=\"/pl/reports/espi/company/" + cmpId.ToString() + ",0,0,0,1]\"\b[1]");
            return data.InnerText;
        }
        
        public int ConvertToDbId(string name)
        {
            if (name.Contains(" SA"))
            {
                name = name.Remove(name.Length - 3);
            }
            var model = ServiceLocator.Current.GetInstance<IUnitOfWork>();

            return 0;
        }

        public int ConvertToDbId(int papId)
        {
            return ConvertToDbId(ConvertToName(papId));
        }
    }
}
