using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using NLog;
using System.Linq;

namespace IDSA.Modules.PapParser
{
    public class PapDbCompanyConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PapDbCompanyConverter()
        {
            logger = LogManager.GetLogger("PapDbCompanyConverter");
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
            if (papName.Contains("Dom Maklerski IDM S.A."))
                return "Dom Maklerski IDM SA.";
            if (papName.Contains("ENERGOMONTAŻ-POŁUDNIE S.A."))
                return papName + " w upadłości układowej";
            //if (papName.Contains("RAFAKO S.A."))
            //    return "Rafako S.A.";
            //if (papName.Contains("MIESZKO S.A."))
            //    return papName.Replace("MIESZKO", "Mieszko");
            if (papName.Contains("Bomi S.A."))
                return papName + " w upadłości likwidacyjnej";
            if (papName.Contains("Ambra S.A."))
                return "Grupa Ambra S.A.";
            if (papName.Contains("Asseco Central Europe a.s."))
                return "Asseco Central Europe, a.s.";
            if (papName.Contains("Quercus Towarzystwo Funduszy Inwestycyjnych S.A."))
                return "Quercus TFI S.A.";
                
            return papName;
        }

        public int ConvertToDbId(string papName)
        {
            string dbName = ConvertToDbName(papName);

            var cache = ServiceLocator.Current.GetInstance<ICacheService>();
            var cmp = cache.GetAll().FirstOrDefault(c => c.FullName.ToUpper() == dbName.ToUpper());
            if (cmp == null)
            {
                //TODO: Add to DB new company; Non existing cmp list:
                //Serinus Energy Inc.
                logger.Error("Company name: {0} doesn't exist in Db.", papName);
                return -1;
            }
            return cmp.Id;
        }
    }
}
