using IDSA.Models;
using IDSA.Models.DataStruct;
using IDSA.Models.Repository;
using IDSA.Modules.CachedListContainer;
using IDSA.Modules.PapParser;
using Microsoft.Practices.ServiceLocation;
using NLog;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IDSA.Services
{
    /// <summary>
    /// Database Manage Service is a service for managing database operations.
    /// 
    /// 
    /// TODO: in the future use strategy pattern for adding patches to the db :)
    /// </summary>
    public class DbManageService
    {
        #region Fields
        private readonly ICacheService cache;
        private readonly IUnitOfWork model;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Dictionary<string, string> cmpNames;
        private Dictionary<string, string> addedCmpNames;
        private List<string> newCmpNames;
        private List<string> newNewCmpNames;
        #endregion

        #region Ctors
        public DbManageService()
        {
            cache = ServiceLocator.Current.GetInstance<ICacheService>();
            model = ServiceLocator.Current.GetInstance<IUnitOfWork>();

            InitializeFields();
        }
        #endregion

        #region Public Methods
        public void AddReportsToDb(List<FinancialData> finData)
        {
            int counter = 0;

            foreach (var item in finData)
            {
                if (item.Company != null && !cache.GetCompany(item.Company.Name).Reports.Contains(item))
                {
                    model.Reports.Add(item);
                    cache.GetCompany(item.Company.Name).Reports.Add(item);
                    ++counter;
                }
            }
            model.Commit();
            logger.Info("\nAdd {0} new reports.\n", counter);
        }

        public Company GetCompanyFromData(string name, int id)
        {
            return cache.GetAll().FirstOrDefault(c => c.FullName.ToUpper() == name.ToUpper());
        }

        public void ComparePapDbCompanyNames(List<string> names)
        {
            var companies = cache.GetAll();
            int counter = 0;

            foreach (var name in names)
            {
                if (companies.FirstOrDefault(c => c.FullName.ToUpper() == name.ToUpper()) == null)
                {
                    logger.Error("Company name:   {0} ------  is not recognised in Db", name);
                    ++counter;
                }
            }
            logger.Info("-------- {0} Companies are not recognised in Db", counter);
        }

        /// <summary>
        /// Update Company Names in Database in comparison to PAP names.
        /// At first update names, which were completly different
        /// At second remove dots from 'S.A' to 'SA' form
        /// At last add new companies
        /// 
        /// THIS ACTION MAY TAKE LONG TIME -> MORE THAN 1-2 minutes
        /// </summary>
        public void Update1CompanyNames()
        {
            int counter = 0;

            foreach (var company in cmpNames)
            {
                var cmp = model.Companies.Query().FirstOrDefault(c => c.FullName.ToUpper() == company.Key.ToUpper());
                if (cmp != null)
                {
                    cmp.FullName = company.Value;
                    logger.Debug("Company name: {0}\n changed to: {1}\n", company.Key, company.Value);
                    ++counter;
                }
            }
            if (counter != 0)
                model.Commit();
            logger.Debug("------------\n {0} of {1} companies updated(1)\n", counter, cmpNames.Count);

            RemoveDotsFromSA();

            AddNewCompanies();
        }

        /// <summary>
        /// Update newly company names added to the container by AddCompanyNamesToUpdate() function
        /// </summary>
        public void Update2CompanyNames()
        {
            int counter = 0;

            foreach (var company in addedCmpNames)
            {
                var cmp = model.Companies.Query().FirstOrDefault(c => c.FullName.ToUpper() == company.Key.ToUpper());
                if (cmp != null)
                {
                    cmp.FullName = company.Value;
                    logger.Debug("Company name: {0}\n changed to: {1}\n", company.Key, company.Value);
                    ++counter;
                }
            }
            model.Commit();
            logger.Debug("------------\n {0} of {1} companies updated(2)\n", counter, addedCmpNames.Count);
        }

        /// <summary>
        /// Add new names for company to update in database
        /// </summary>
        /// <param name="dict"></param>
        /// Key(old name), Value(new name) pair
        public void AddCompanyNamesToUpdate(Dictionary<string, string> dict)
        {
            foreach (var name in dict)
            {
                addedCmpNames.Add(name.Key.Trim(), name.Value.Trim());
            }
        }
        #endregion

        #region Private Methods
        private void RemoveDotsFromSA()
        {
            int counter = 0;

            foreach (var company in model.Companies.GetAll())
            {
                if (company.FullName.EndsWith("S.A."))
                {
                    company.FullName = company.FullName.Remove(company.FullName.Length - 3);
                    company.FullName += "A";
                    ++counter;
                }
            }
            if (counter != 0)
                model.Commit();
            logger.Debug("\nRemove dots from S.A. in {0} companies\n", counter);
        }

        private void AddNewCompanies()
        {
            Context context = new Context();
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;
            context.Companies.Load();
            int counter = 0;

            foreach (var company in newCmpNames)
            {
                if (context.Companies.FirstOrDefault(c => c.FullName == company) == null)
                {
                    var papParser = ServiceLocator.Current.GetInstance<IPapParser>();
                    var tempCmp = papParser.GetCompanyDataFromPAP(company);

                    if (!CompanyValidate(tempCmp))
                    {
                        logger.Error("\nAdd company -- {0} -- failed because of validation problems: --ID-- {1} -- --NAME-- {2}\n",
                            company, tempCmp.Id, tempCmp.Name);
                        continue;
                    }

                    context.Companies.Add(tempCmp);
                    context.SaveChanges();
                    cache.AddCompany(tempCmp);
                    ++counter;
                }
            }
            context.Dispose();
            logger.Debug("\nAdd {0} new companies.\n", counter);
        }

        private bool CompanyValidate(Company cmp)
        {
            if (cmp.Name == null)
                return false;
            if (model.Companies.Query().FirstOrDefault(c => c.Id == cmp.Id) != null)
                return false;
            return true;
        }

        private void InitializeFields()
        {
            addedCmpNames = new Dictionary<string, string>();
            cmpNames = new Dictionary<string, string>() //db(old), pap(new) names
                {
                    {"Narodowy Fundusz Inwestycyjny Krezus S.A.", "Krezus SA"},
                    {"BBI Development Narodowy Fundusz Inwestycyjny S.A.", "BBI Development SA"},
                    {"Dom Maklerski IDM SA.", "Dom Maklerski IDM SA"},
                    {"ENERGOMONTAŻ-POŁUDNIE S.A. w upadłości układowej", "ENERGOMONTAŻ-POŁUDNIE SA"},
                    {"Rafako S.A.", "RAFAKO SA"},
                    {"Zakłady Przemysłu Cukierniczego Mieszko S.A.", "MIESZKO SA"},
                    {"Bomi S.A. w upadłości likwidacyjnej", "Bomi SA"},
                    {"Grupa Ambra S.A.", "Ambra SA"},
                    {"Asseco Central Europe, a.s.", "Asseco Central Europe a.s."},
                    {"Quercus TFI S.A.", "Quercus Towarzystwo Funduszy Inwestycyjnych SA"},
                    {"BUDOPOL WROCŁAW S.A.", "BUDOPOL-WROCŁAW SA"},
                    {"Jupiter Narodowy Fundusz Inwestycyjny S.A.", "Jupiter SA"},
                    {"Black Lion NFI S.A.", "Black Lion Fund SA"},
                    {"Idea TFI S.A.", "IDEA Towarzystwo Funduszy Inwestycyjnych SA"},
                    {"Internet Group S.A.", "W Investments SA"},
                    {"SMT Software S.A.", "SMT SA"},
                    {"ABM Solid S.A. w upadłości układowej", "Ambra SA"},
                    {"Intakus S.A. w upadłości układowej", "Intakus SA"},
                    {"Lubelskie Zakłady Przemysłu Skórzanego Protektor S.A.", "Protektor SA"},
                    {"Trakcja - Tiltra S.A.", "Trakcja SA"},
                    {"Drewex S.A. w upadłości układowej", "Drewex SA"},
                    {"Green Eco Technology S.A.", "GREENECO SA"},
                    {"Intersport Polska S.A.", "Intersport  Polska SA"},    //niestety blad w PAP
                    {"Fabryka Maszyn Famur S.A.", "Famur SA"},
                    {"Inpro S. A.", "Inpro SA"},
                    {"Getin Noble Bank S.A.", "Getin Noble Bank SA (d. Get Bank SA)"},
                    {"Wadex S.A.", "Przedsiębiorstwo Produkcyjno Handlowe Wadex SA"},
                    {"Grupa Apator S.A.", "Apator SA"},
                    {"Milkland N.V.", "Milkiland NV"},
                    {"Koelner S.A.", "Rawlplug SA"},
                    {"BNP Paribas Polska S.A.", "BNP Paribas Bank Polska SA"},
                    {"Industrial Milk Company", "Industrial Milk Company SA"},
                    {"NG2 S.A.", "CCC SA"},
                    {"Fortuna Entertainment Group", "Fortuna Entertainment Group N.V."},
                    {"Elkop Energy S.A.", "Elkop SA"},
                    {"Zespół Elektrowni \"Pątnów-Adamów-Konin\" S.A.", "Zespół Elektrowni Pątnów-Adamów-Konin SA"},
                    {"Bank Polska Kasa Opieki S.A.", "Pekao Bank Hipoteczny SA"},
                    {"Interbud Lublin S.A.", "Interbud-Lublin SA"},
                    {"Agrowill Group AB", "AB Agrowill Group"},
                    {"P.R.E.S.C.O. Group S.A. ", "P.R.E.S.C.O. Group SA"},
                    {"5TH Aavenue Holding S.A.", "5TH Avenue Holding SA"},
                    {"AC .S.A.", "AC SA"},
                    {"Agroton Group of Companies", "Agroton Public Limited"},
                    {"Apolonia Medica S.A.", "Apolonia Medical SA"},
                    {"ATC Cargo S.A.", "ATC-Cargo SA"},
                    {"Aton HT S.A.", "Aton-HT SA"},
                    {"Auto Spa S.A.", "Auto-Spa SA"},
                    {"Avia Solutions Group", "Avia Solutions Group AB"},
                    {"Bank BGŻ S.A.", "Bank Gospodarki Żywnościowej SA"},
                    {"Baumal Group S.A.", "Baumal SA"},
                    {"\"BIOMED-LUBLIN\" Wytwórnia Surowic i Szczepionek S.A.", "Biomed-Lublin Wytwórnia Surowic i Szczepionek SA"},
                    {"Blumerang PRE IPO S.A.", "Blumerang Investors SA"},
                    {"bmp Aktiengesellschaft", "bmp media investors AG"},
                    {"City Interactive S.A.", "CI Games SA"},
                    {"Clean & Carbon Energy S.A.", "Clean&Carbon Energy SA"},
                    {"D&D S.A. w upadłości z możliwością zawarcia układu", "D&D SA"},
                    {"Abbey House S.A.", "Dom Aukcyjny Abbey House SA"},
                    {"ECA Auxilium S.A.", "ECA SA"},
                    {"Ecotech S.A.", "ECOTECH Polska SA"},
                    {"Emmerson S.A.", "Emmerson Realty SA"},
                    {"Esperotia Energy Investments", "Esperotia Energy Investments SA"},
                    {"E-Star Alternative Energy Service Pic.", "E-Star Alternative Energy Service Plc."},
                    {"Eurostystem S.A.", "Eurosystem SA"},
                    {"EZO Recykling S.A.", "EZO SA"},
                    {"Forever Entertaiment S.A.", "Forever Entertainment SA"},
                    {"iCom Vision Holding, a.s.", "iCom Vision Holding a.s."},
                    {"TRO Media S.A.", "Indata Software"},
                    {"Izolacja Jarocin S.A.", "IZOLACJA-JAROCIN SA"},
                    {"Kampa S.A. ", "Kampa SA"},
                    {"Komfort Klima S.A.", "Komfort-Klima SA"},
                    {"Korbnak S.A.", "Korbank SA"},
                    {"Krka d.d.", "Krka, d. d."},
                    {"Druk-Pak Kujawskie Zakłady Poligraficzne S.A.", "Kujawskie Zakłady Poligraficzne Druk-Pak SA"},
                    {"Makora Krośnieńska Huta Szkła S.A.", "Makora SA"},
                    {"MarSoft S.A", "MarSoft SA"},
                    {"Mostostal Plock S.A.", "MOSTOSTAL Płock SA"},
                    {"Mr Kuchar S.A.", "Mr Hamburger SA"},          //?????????????no nie wiem
                    {"Navimor Invest S.A.", "NAVIMOR-INVEST SA"},
                    {"New World Resources N.V.", "New World Resources Plc"},
                    {"Nicolas Games S.A.", "Nicolas Entertainment Group SA"},
                    {"OSTATNIEMIEJSCA.PL S.A.", "OEM SA"},
                    {"Olympic Entertainment Group A.S.", "Olympic Entertainment Group AS"},
                    {"Orphee S.A.", "Orphée SA"},
                    {"Phoenix Energy a.s.", "Photon Energy N.V."},
                    {"PPB Prefabet - Białe Błota S.A.", "Przedsiębiorstwo Przemysłu Betonów PREFABET - Białe Błota SA"},
                    {"R&C Union S.A.", "R&C Union"},
                    {"Reinhold Polska A.B.", "Reinhold Polska AB"},
                    {"Kulczyk Oil Ventures Inc.", "Serinus Energy Inc."},
                    {"Stopklatka.pl S.A.", "Stopklatka SA"},
                    {"Synkret S.A. w upadłości z możliwością zawarcia układu", "Synkret SA"},
                    {"Tatry Mountain Resorts", "Tatry Mountain Resorts AS"},
                    {"Tax - Net S.A.", "TAX-NET SA"},
                    {"Telemedycyna S.A.", "Telemedycyna Polska SA"},
                    {"Uboat Line S.A.", "Uboat-Line SA"},
                    {"Unimot Gaz S.A.", "Unimot  Gaz SA"},              //niestety blad w PAP
                    {"Weglopex Holding S.A.", "Węglopex Holding SA"},
                };

            newCmpNames = new List<string>()
            {
                "Agrotour SA",
                "APS Energia SA",
                "AviaAM Leasing AB",
                "Bank Gospodarstwa Krajowego SA",
                "BARCLAYS BANK PLC",
                "Efix Dom Maklerski SA",        // reports from 2013.07.26
                "EURO GOLD SA",                 // reports from 2013.06.12
                "Global Cosmed SA",
                "Grupa Exorigo-Upos SA",
                "HM Inwest SA",
                "Imagis SA",
                "InfoScope SA",
                "Investment Fund Managers SA",
                "Leasing-Experts SA",
                "MEGA SONIC SA",
                "NC NUTRITION CENTER S.A.",
                "Novavis SA",
                "OT Logistics SA",
                "Peixin International Group NV",
                "PIK SA",
                "Przedsiębiorstwo Telekomunikacyjne Telgam SA",
                "Pylon SA",
                "Standrew SA",
                "Tarczyński SA"
            };

            newNewCmpNames = new List<string>();

            //var tempCompanies = new List<string>()
            //{
            //    "Automatyka-Pomiary-Sterowanie SA",
            //    "Europejski Fundusz Energii SA",
            //    "GMINA BRZESKO",
            //    "GMINA MIASTA BRODNICY",
            //    "GMINA MIASTO WŁOCŁAWEK",
            //    "Gmina Miejska Kraków",
            //    "GMINA OSTRÓW",
            //    "Gmina Wałbrzych",
            //    "MIASTO ELBLĄG",
            //    "Miasto Poznań",
            //    "Miasto Radlin",
            //    "Miasto Rybnik",
            //    "Miasto Siedlce",
            //    "Miasto Stołeczne Warszawa",
            //    "Grupa Konsultingowo-Inżynieryjna KOMPLEKS",
            //    "Instytut Szkoleń i Analiz Gospodarczych SA",
            //    "Mennica Skarbowa SA"
            //};

            //var notNeededCompanies = new List<string>()
            //{
            //    "BPH TFI SA",
            //    "BRE BANK HIPOTECZNY SA",
            //    "BZ WBK TFI SA",
            //    "Copernicus Capital TFI",
            //    "DEUTSCHE BANK AG",
            //    "DWS POLSKA TFI",
            //    "ERSTE BANK AG",                //reports in english
            //    "ING Towarzystwo Funduszy Inwestycyjnych SA",
            //    "Investors TFI SA",
            //    "IPOPEMA TFI SA",
            //    "KBC Towarzystwo Funduszy Inwestycyjnych SA",
            //    "MCI CAPITAL TFI",
            //    "OPERA TFI",
            //    "PIONEER PEKAO TFI S.A.",
            //    "PKO TFI S.A.",
            //    "Polsko-Amerykański Dom Inwestycyjny S.A.",
            //    "RAIFFEISEN CENTROBANK AG",
            //    "SKARBIEC TFI",
            //    "TFI Legg Mason SA",
            //    "TFI SECUS SA",
            //    "Union Investment TFI S.A.",      //ma domyslnie S.A.
            //    "Venturion Investment Fund SA"
            //};

            //"Electus Hipoteczny S.A." -> "Polski Fundusz Hipoteczny S.A.";
        }
        #endregion
    }
}
