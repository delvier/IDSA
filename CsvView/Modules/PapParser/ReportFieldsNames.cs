using System.Collections.Generic;

namespace IDSA.Modules.PapParser
{
    public interface ReportFields
    {
        List<string> Names { get; }
        long Value { get; set; }
    }

    //Środki pieniężne netto z działalności operacyjnej
    //Środki pieniężne netto z działalności inwestycyjnej
    //Przepływy pieniężne netto z działalności operacyjnej
    //Przepływy pieniężne netto z działalności inwestycyjnej
    //PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI OPERACYJNEJ
    //PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI INWESTYCYJNEJ

    //PRZEPŁYWY PIENIĘŻNE NETTO RAZEM
    //Przepływy pieniężne netto, razem

    //Zysk (strata) netto przypadający akcjonariuszom podmiotu dominującego
    //Zmiana netto stanu środków pieniężnych i ich ekwiwalentów
    //Kapitał własny przypadający akcjonariuszom jednostki dominującej

    //Zobowiązania razem = Zobowiązania długoterminowe + Zobowiązania kr&oacute;tkoterminowe
    //ZOBOWIĄZANIA I REZERWY NA ZOBOWIĄZANIA

    //ZYSK (STRATA) BRUTTO
    //"Strata operacyjna"
    //"Przychody z tytułu odsetek"
    //Przychody z tytułu prowizji"
    //"Zysk (strata) brutto"
    //"Całkowite dochody"
    //Zmiana stanu środków pieniężnych"

    //Średnioważona liczba akcji
    //Średnioważona liczba akcji (w szt.)
    //LICZBA AKCJI

    //Zysk netto na akcję (w PLN/EUR na jedną akcję)
    //Zysk na akcję (PLN; EUR)
    //ZYSK (STRATA) NA JEDNĄ AKCJĘ ZWYKŁĄ (W ZŁ/EURO)
    //Zysk (strata) na jedną akcję zwykłą (w zł / EURO)

    //Rozwodniony zysk  na jedną akcję (w zł / EURO)
    //Rozwodniony zysk na akcję (w PLN/EUR na jedną akcję)
    //Rozwodniony zysk na akcję (PLN; EUR)

    //Wartość księgowa na jedną akcję (w zł / EURO)
    //Wartość księgowa na akcję (w PLN/EUR na jedną akcję)
    //Rozwodniona wartość księgowa na akcję (w PLN/EUR na jedną akcję)
    //Rozwodniona wartość księgowa na jedną akcję (w zł / EURO)

    public class Sales : ReportFields    //IncomeStatmentDataKey 41
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Sales()
        {
            Names = new List<string> { "Sprzedaż" };
        }
    }

    public class OwnSaleCosts : ReportFields    //IncomeStatmentDataKey 42
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OwnSaleCosts()
        {
            Names = new List<string> { "" };
        }
    }
    public class SalesCost1 : ReportFields    //IncomeStatmentDataKey 43
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SalesCost1()
        {
            Names = new List<string> { "" };
        }
    }
    public class SalesCost2 : ReportFields    //IncomeStatmentDataKey 44
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SalesCost2()
        {
            Names = new List<string> { "" };
        }
    }
    public class EarningOnSales : ReportFields    //IncomeStatmentDataKey 45
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public EarningOnSales()
        {
            Names = new List<string> { "Przychody ze sprzedaży",
                    "Przychody ze sprzedaży netto",
                    "Przychody netto ze sprzedaży produkt&oacute;w, towar&oacute;w i materiał&oacute;w",
                    "PRZYCHODY NETTO ZE SPRZEDAŻY PRODUKT&Oacute;W, TOWAR&Oacute;W I MATERIAŁ&Oacute;W",
                    "Składki ubezpieczeniowe przypisane brutto" };
        }
    }


    public class OtherOperationalActivity1 : ReportFields    //IncomeStatmentDataKey 46
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherOperationalActivity1()
        {
            Names = new List<string> { "" };
        }
    }

    public class OtherOperationalActivity2 : ReportFields    //IncomeStatmentDataKey 47
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherOperationalActivity2()
        {
            Names = new List<string> { "" };
        }
    }

    public class EBIT : ReportFields    //IncomeStatmentDataKey 48
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public EBIT()
        {
            Names = new List<string> { "Zysk z działalności operacyjnej",
                    "Zysk (strata) z działalności operacyjnej",
                    "ZYSK (STRATA) NA DZIAŁALNOŚCI OPERACYJNEJ" };
        }
    }

    public class FinancialAcvitity1 : ReportFields    //IncomeStatmentDataKey 49
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FinancialAcvitity1()
        {
            Names = new List<string> { "Środki pieniężne netto z działalności finansowej",
                "Przepływy pieniężne netto z działalności finansowej",
                "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI FINANSOWEJ" };
        }
    }

    public class FinancialAcvitity2 : ReportFields    //IncomeStatmentDataKey 50
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FinancialAcvitity2()
        {
            Names = new List<string> { "" };
        }
    }

    public class OtherCostOrSales : ReportFields    //IncomeStatmentDataKey 51
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherCostOrSales()
        {
            Names = new List<string> { "" };
        }
    }

    public class SalesOnEconomicActivity : ReportFields    //IncomeStatmentDataKey 52
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SalesOnEconomicActivity()
        {
            Names = new List<string> { "" };
        }
    }

    public class ExceptionalOccurence : ReportFields    //IncomeStatmentDataKey 53
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ExceptionalOccurence()
        {
            Names = new List<string> { "" };
        }
    }

    public class EarningBeforeTaxes : ReportFields    //IncomeStatmentDataKey 54
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public EarningBeforeTaxes()
        {
            Names = new List<string> { "Zysk (strata) przed opodatkowaniem",
                                        "Strata przed opodatkowaniem", 
                                        "Zysk przed opodatkowaniem" };
        }
    }

    public class DiscontinuedOperations : ReportFields    //IncomeStatmentDataKey 55
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public DiscontinuedOperations()
        {
            Names = new List<string> { "" };
        }
    }

    public class NetProfit : ReportFields    //IncomeStatmentDataKey 56
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public NetProfit()
        {
            Names = new List<string> { "Zysk (strata) netto", "Zysk netto", 
                                        "ZYSK (STRATA) NETTO",
                                        "Zysk netto okresu sprawozdawczego" };
        }
    }

    public class NetParentProfit : ReportFields    //IncomeStatmentDataKey 57
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public NetParentProfit()
        {
            Names = new List<string> { "" };
        }
    }

    //Balance Data

    public class AssetsPrimary : ReportFields         //BalanceDataKey 5
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public AssetsPrimary()
        {
            Names = new List<string> { "Aktywa", "Aktywa razem", "Aktywa ogolem",
                                        "AKTYWA RAZEM", "A k t y w a r a z e m",
                    "Aktywa razem (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
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
            Names = new List<string> { "Kapitał własny", "Kapital wlasny", 
                                        "KAPITAŁ WŁASNY",
                                        "Kapitał własny (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
        }
    }

    public class CapitalMasterFund : ReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CapitalMasterFund()
        {
            Names = new List<string> { "Kapitał zakładowy", "KAPITAŁ ZAKŁADOWY",
                                        "Kapitał zakładowy  (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
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
            Names = new List<string> { "Zobowiązania długoterminowe",
                                        "ZOBOWIĄZANIA DŁUGOTERMINOWE",
                                        "Zobowiazania dlugoterminowe",
                                        "Zobowiązania długoterminowe (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
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
            Names = new List<string> { "Zobowiązania kr&oacute;tkoterminowe",
                                        "ZOBOWIAZANIA KRÓTKOTERMINOWE",
                                        "Zobowiazania krotkoterminowe",
                                        "Zobowiazania krótkoterminowe",
                                        "Zobowiązania kr&oacute;tkoterminowe (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
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
