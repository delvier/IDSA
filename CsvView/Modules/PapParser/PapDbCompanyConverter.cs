using HtmlAgilityPack;
using IDSA.Models.Repository;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using System.Linq;

namespace IDSA.Modules.PapParser
{
    public class PapDbCompanyConverter
    {
        public PapDbCompanyConverter()
        {

        }

        public string ConvertToDbName(string papName)
        {
            if (papName.EndsWith("SA"))
            {
                papName = papName.Insert(papName.Length - 1, ".");
                papName = papName.Insert(papName.Length, ".");
            }
            if (papName.Contains("Krezus"))
                return papName.Insert(0, "Narodowy Fundusz Inwestycyjny ");
            if (papName.Contains("BBI Development"))
                return papName.Insert(16, "Narodowy Fundusz Inwestycyjny ");
            return papName;
        }

        //public string ConvertToName(int cmpId)
        //{
        //    HtmlWeb hw = new HtmlWeb();
        //    HtmlAgilityPack.HtmlDocument page = hw.Load(@"http://biznes.pap.pl/pl/reports/espi/company/"
        //        + cmpId.ToString() + ",0,0,1");
        //    var data = page.DocumentNode.SelectSingleNode
        //        ("//a [@href=\"/pl/reports/espi/company/" + cmpId.ToString() + ",0,0,0,1]\"\b[1]");
        //    return data.InnerText;
        //}

        public int ConvertToDbId(string papName)
        {
            string dbName = ConvertToDbName(papName);

            var cache = ServiceLocator.Current.GetInstance<ICacheService>();
            var cmp = cache.GetAll().FirstOrDefault(c => c.FullName == dbName);
            if (cmp == null)
            {
                //TODO: Add to DB new company
                return 0;
            }
            return cmp.Id;
        }

        //public int ConvertToDbId(int papId)
        //{
        //    return ConvertToDbId(ConvertToName(papId));
        //}
    }
}
