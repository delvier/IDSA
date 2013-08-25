using System.Collections.Generic;

namespace IDSA.Modules.PapParser
{
    public interface ReportFields
    {
        List<string> Names { get; }
        long Value { get; set; }
    }


    //values.Add("Przychody ze sprzedaży", 0);
    //values.Add("Strata operacyjna", 0);
    //values.Add("Strata przed opodatkowaniem", 0);
    //values.Add("Przychody z tytułu odsetek", 0);
    //values.Add("Przychody z tytułu prowizji", 0);
    //values.Add("Zysk (strata) brutto", 0);
    //values.Add("Zysk (strata) netto", 0);
    //values.Add("Całkowite dochody", 0);
    //values.Add("Zmiana stanu środków pieniężnych", 0);

    public class AssetsPrimary : ReportFields         //BalanceDataKey 5
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public AssetsPrimary()
        {
            Names = new List<string> { "Aktywa razem", "Aktywa ogolem",
                                        "A k t y w a r a z e m"};
        }

        public void addName(string additionalName)
        {
            Names.Add(additionalName);
        }
    }

    public class LiabilitiesPrimary : ReportFields    //BalanceDataKey 6
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LiabilitiesPrimary()
        {
            Names = new List<string> { "Pasywa razem", "Pasywa ogolem",
                                        "P a s y w a r a z e m"};
        }
    }

    public class FixedAssets : ReportFields           //BalanceDataKey 7
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FixedAssets()
        {
            Names = new List<string> { "Aktywa trwale" };
        }
    }

    public class IntangibleAssets : ReportFields      //BalanceDataKey 8
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public IntangibleAssets()
        {
            Names = new List<string> { "Wartosci niematerialne", 
                                        "Wartosci niematerialne i prawne",
                                        "Wartosci niematerialne i prawne, w tym:" };
        }
    }

    public class TangibleFixedAssets : ReportFields   //BalanceDataKey 9
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public TangibleFixedAssets()
        {
            ////Rzeczowe składniki majątku trwałego
            Names = new List<string> { "Rzeczowe aktywa trwale", 
                                        "Rzeczowe aktywa trwale:" };
        }
    }

    public class LongTermReceivablesFixA : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermReceivablesFixA()
        {
            Names = new List<string> { "Naleznosci dlugoterminowe", 
                                        "Należności handlowe oraz pozostałe należności" };
        }
    }

    public class LongTermInvestmentFixA : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermInvestmentFixA()
        {
            Names = new List<string> { "Inwestycje dlugoterminowe", 
                                        "Nieruchomosci inwestycyjne" };
        }
    }

    public class OtherFixedAssets : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherFixedAssets()
        {
            Names = new List<string> { "Pozostale aktywa dlugoterminowe", 
                                        "Pozostale dlugoterminowe aktywa finansowe",
                                        "Pozostałe wartości niematerialne",
                                        "Pozostałe rozliczenia międzyokresowe",
                                        "Inne dlugoterminowe aktywa finansowe" };
        }
    }

    public class CurrentAssets : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CurrentAssets()
        {
            Names = new List<string> { "Aktywa obrotowe" };
        }
    }

    public class Inventory : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Inventory()
        {
            Names = new List<string> { "Zapasy" };
        }
    }

    public class LongTermReceivablesCurA : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermReceivablesCurA()
        {
            Names = new List<string> { "Naleznosci krotkoterminowe",
                                        "Naleznosci krótkoterminowe" };
        }
    }

    public class LongTermInvestmentCurA : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermInvestmentCurA()
        {
            Names = new List<string> { "Inwestycje krotkoterminowe" };
        }
    }

    public class Cash : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Cash()
        {
            Names = new List<string> { "Srodki pieniezne i ich ekwiwalenty",
                                        "srodki pieniezne i inne aktywa pieniezne" };
        }
    }

    public class OtherCurentAssets : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherCurentAssets()
        {
            Names = new List<string> { "Pozostale aktywa obrotowe" };
        }
    }

    public class AssetsForSale : ReportFields //20 //Aktywa przeznaczone do sprzedaży
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public AssetsForSale()
        {
            Names = new List<string> { "Aktywa przeznaczone do sprzedazy",
                                        "Aktywa sklasyfikowane jako przeznaczone do sprzedazy" };
        }
    }

    //EQUITY - pasywa

    public class Equity : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Equity()
        {
            Names = new List<string> { "Kapitał własny", "Kapital wlasny" };
        }
    }

    public class CapitalMasterFund : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CapitalMasterFund()
        {
            Names = new List<string> { "Kapitał zakładowy" };
        }
    }

    public class ShareOfTreasuryStock : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ShareOfTreasuryStock()
        {
            Names = new List<string> { "Udzial akcji wlasnych" };
        }
    }

    public class CapitalreserveFund : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CapitalreserveFund()
        {
            Names = new List<string> { "Kapital zapasowy" };
        }
    }

    // ColumnY,                   //25  ? 0
    // ColumnZ,                   //26  ? 0

    public class NonControllingInterests : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public NonControllingInterests()
        {
            Names = new List<string> { "Udzialy niekontrolujace" };
        }
    }


    public class LongTermLiabilities : ReportFields       //28 //ZOBOWIĄZANIA DŁUGOTERMINOWE
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermLiabilities()
        {
            Names = new List<string> { "Zobowiazania dlugoterminowe" };
        }
    }

    public class SuppliesAndServicesLT : ReportFields     //29 //Z tytułu dostaw i usług
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SuppliesAndServicesLT()
        {
            Names = new List<string> { "Z tytulu dostaw i uslug" };
        }
    }

    public class LoansAndAdvancesLT : ReportFields        //30 //!* Kredyty i pożyczki
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LoansAndAdvancesLT()
        {
            Names = new List<string> { "Kredyty i pozyczki dlugoterminowe",
                                        "Kredyty i pozyczki" };
        }
    }

    public class OtherFinancialLT : ReportFields        //32 //!* Inne finansowe zob. długoterminowe
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherFinancialLT()
        {
            Names = new List<string> { "Inne finansowe zobowiazania dlugoterminowe" };
        }
    }

    public class OtherLT : ReportFields        //33 //Inne zobowiązania długoterminowe
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherLT()
        {
            Names = new List<string> { "Inne zobowiazania dlugoterminowe" };
        }
    }


    public class ShortTermLiabilities : ReportFields  //34 //ZOBOWIĄZANIA KRÓTKOTERMINOWE
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ShortTermLiabilities()
        {
            Names = new List<string> { "Zobowiazania krotkoterminowe",
                                        "Zobowiazania krótkoterminowe" };
        }
    }

    public class SuppliesAndServicesST : ReportFields  //35 //Z tytułu dostaw i usług
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SuppliesAndServicesST()
        {
            Names = new List<string> { "Zobowiazania z tytulu dostaw i uslug",
                                        "Z tytulu dostaw i uslug" };
        }
    }

    public class LoansAndAdvancesST : ReportFields  //36 //!*Kredyty i pożyczki
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LoansAndAdvancesST()
        {
            Names = new List<string> { "Krótkoterminowe kredyty i pozyczki",
                                        "Kredyty i pozyczki" };
        }
    }

    //        ColumnAK,                //37  ? 0

    public class OtherFinancialST : ReportFields  //38 //!*Inne finanoswe zob. krótkoterminowe
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherFinancialST()
        {
            Names = new List<string> { "Inne finansowe zobowiazania krotkoterminowe" };
        }
    }

    public class OtherST : ReportFields  //39 //Inne zobowiązania krótkoterminowe.
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherST()
        {
            Names = new List<string> { "Inne zobowiazania krotkoterminowe" };
        }
    }

    //        ColumnAN                //40  ? 0

}
