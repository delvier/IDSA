using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using NLog;
using System.Linq;

namespace IDSA.Modules.PapParser
{
    public class PapDbCompanyConverter
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

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
            if (papName.Contains("BUDOPOL-WROCŁAW S.A."))
                return "BUDOPOL WROCŁAW S.A.";
            if (papName.Contains("Jupiter"))
                return "Jupiter Narodowy Fundusz Inwestycyjny S.A.";
            if (papName.Contains("Black Lion Fund S.A."))
                return "Black Lion NFI S.A.";
            if (papName.Contains("IDEA Towarzystwo Funduszy Inwestycyjnych S.A."))
                return "Idea TFI S.A.";
            if (papName.Contains("W Investments S.A.")) //cmp change name
                return "Internet Group S.A.";
            if (papName.Contains("SMT S.A."))
                return "SMT Software S.A.";
            if (papName.Contains("ABM Solid S.A."))
                return "ABM Solid S.A. w upadłości układowej";
            if (papName.Contains("Intakus S.A."))
                return "Intakus S.A. w upadłości układowej";
            if (papName.Contains("Protektor S.A."))
                return "Lubelskie Zakłady Przemysłu Skórzanego Protektor S.A.";
            if (papName.Contains("Trakcja S.A."))
                return "Trakcja - Tiltra S.A.";
            if (papName.Contains("Drewex S.A."))
                return "Drewex S.A. w upadłości układowej";
            if (papName.Contains("GREENECO S.A."))
                return "Green Eco Technology S.A.";
            if (papName.Contains("Intersport  Polska S.A."))
                return "Intersport Polska S.A.";
            if (papName.Contains("Famur S.A."))
                return "Fabryka Maszyn Famur S.A.";
            if (papName.Contains("Inpro S.A."))
                return "Inpro S. A.";
            if (papName.Contains("Getin Noble Bank SA (d. Get Bank SA)"))
                return "Getin Noble Bank S.A.";
            if (papName.Contains("Przedsiębiorstwo Produkcyjno Handlowe Wadex S.A."))
                return "Wadex S.A.";
            if (papName.Contains("Apator S.A."))
                return "Grupa Apator S.A.";
            if (papName.Contains("Global Cosmed S.A."))     //new company, add to DB :)
                return "Global Cosmed S.A.";
            if (papName.Contains("Milkiland NV"))
                return "Milkland N.V.";
            if (papName.Contains("M.W. Trade S.A."))
                return "M.W. Trade SA";
            if (papName.Contains("Rawlplug S.A."))     //cmp change name
                return "Koelner S.A.";
            if (papName.Contains("PCC ROKITA S.A."))     //new company, add to DB :)
                return "PCC ROKITA S.A.";
            if (papName.Contains("BNP Paribas Bank Polska S.A."))
                return "BNP Paribas Polska S.A.";
            if (papName.Contains("Industrial Milk Company S.A."))
                return "Industrial Milk Company";
            if (papName.Contains("CCC S.A."))
                return "NG2 S.A.";
            if (papName.Contains("Fortuna Entertainment Group N.V."))
                return "Fortuna Entertainment Group";
            if (papName.Contains("Elkop S.A."))
                return "Elkop Energy S.A.";
            if (papName.Contains("Zespół Elektrowni Pątnów-Adamów-Konin S.A."))
                return "Zespół‚ Elektrowni \"Pątnów-Adamów-Konin\" S.A.";
            if (papName.Contains("Pekao Bank Hipoteczny S.A."))
                return "Bank Polska Kasa Opieki S.A.";
            return papName;
        }

        public Models.Company ConvertToDb(string papName)
        {
            string dbName = ConvertToDbName(papName);

            var cache = ServiceLocator.Current.GetInstance<ICacheService>();
            var cmp = cache.GetAll().FirstOrDefault(c => c.FullName.ToUpper() == dbName.ToUpper());
            if (cmp == null)
            {
                //TODO: Add to DB new company; Non existing cmp list:
                //Serinus Energy Inc.
                logger.Error("Company name: {0} doesn't exist in Db.", papName);
            }
            return cmp;
        }
    }
}
