using System.Collections.Generic;
using System.Linq;

namespace IDSA.Modules.PapParser
{
    public interface IReportFields
    {
        List<string> Names { get; }
        long Value { get; set; }
    }

    public class ReportFields
    {
        private Dictionary<string, List<string>> dict;

        public ReportFields()
        {
            dict = new Dictionary<string, List<string>>();

            dict.Add("EarningOnSales", EarningOnSales);                 //IncomeStatmentDataKey 45
            dict.Add("EBIT", EBIT);                                     //IncomeStatmentDataKey 48
            dict.Add("EarningBeforeTaxes", EarningBeforeTaxes);         //IncomeStatmentDataKey 54
            dict.Add("NetProfit", NetProfit);                           //IncomeStatmentDataKey 56

            dict.Add("OperatingActivitiesCF", OperatingActivitiesCF);   //ICashFlowDataKey 57
            dict.Add("WorkingCapital", WorkingCapital);                 //ICashFlowDataKey 62
            dict.Add("InvestmentCF", InvestmentCF);                     //ICashFlowDataKey 64
            dict.Add("FinancialCF", FinancialCF);                       //ICashFlowDataKey 66
            dict.Add("TotalCF", TotalCF);                               //ICashFlowDataKey 72

            dict.Add("AssetsPrimary", AssetsPrimary);                   //BalanceDataKey 5
            dict.Add("LiabilitiesPrimary", LiabilitiesPrimary);         //BalanceDataKey 6
            dict.Add("FixedAssets", FixedAssets);                       //BalanceDataKey 7
            dict.Add("IntangibleAssets", IntangibleAssets);             //BalanceDataKey 8
            dict.Add("CurrentAssets", CurrentAssets);                   //BalanceDataKey 13
            dict.Add("Inventory", Inventory);                           //BalanceDataKey 14
            dict.Add("Equity", Equity);                                 //BalanceDataKey 21
            dict.Add("CapitalMasterFund", CapitalMasterFund);           //BalanceDataKey 22
            dict.Add("CapitalReserveFund", CapitalReserveFund);           //BalanceDataKey 24
            dict.Add("LongTermLiabilities", LongTermLiabilities);       //BalanceDataKey 28
            dict.Add("ShortTermLiabilities", ShortTermLiabilities);     //BalanceDataKey 34

            dict.Add("ShareNumbers", ShareNumbers);                     //XXXX
            dict.Add("Other", Other);                                   //XXXX
        }

        public string findKey(string value)
        {
            return dict.FirstOrDefault(el
                =>
                el.Value.Contains(value) == true)
                .Key;
        }

        public Dictionary<string, List<string>> getAllFields()
        {
            return dict;
        }
        //dict.Keys() klucze dla foreach()

        private List<string> EarningOnSales = new List<string> {
            "Przychody ze sprzedaży",
            "Przychody ze sprzedaży netto",
            "Przychody ze sprzedaży akcji",
            "Przychody ze sprzedaży og&oacute;łem",
            "Przychody ze sprzedaży produkt&oacute;w i towar&oacute;w",
            "Przychody ze sprzdaży produkt&oacute;w, towarow i materiał&oacute;w",
            "Przychody ze sprzedaży produkt&oacute;w, towar&oacute;w i materiał&oacute;w",
            "Przychody netto ze sprzedaży produkt&oacute;w, usług, towar&oacute;w i materiał&oacute;w",
            "Przychody netto ze sprzedaży",
            "Przychody netto ze sprzedaży produkt&oacute;w, towar&oacute;w i materiał&oacute;w",
            "Przychody netto ze sprzedaży produkt&oacute;w, towar&oacute;w i materiałow",
            "Przych&oacute;d netto ze sprzedaży produkt&oacute;w, towar&oacute;w i materiał&oacute;w",
            "Przychody netto ze sprzedaży produkt&oacute;w,  towar&oacute;w i materiał&oacute;w",
            "PRZYCHODY NETTO ZE SPRZEDAŻY PRODUKT&Oacute;W, TOWAR&Oacute;W I MATERIAŁ&Oacute;W",
            "Przychody netto ze sprzedaży produkt&oacute;w, towar&oacute;w i usług",
            "Przychody netto ze sprzedaży produkt&oacute;w, towar&oacute;w,materiał&oacute;w i usług",
            "Przychody og&oacute;łem",
            "Przychody z tytułu odsetek związanych z portfelem wierzytelności",
            "Przychody ze sprzedaży i zr&oacute;wnane z nimi",
            "Przychody ze sprzedaży z działalności kontynuowanej",
            "Składki ubezpieczeniowe przypisane brutto",
            "Działaln. kontyn. przychody ze sprzedaży",
            "Przychody z tytułu odsetek",
            "Przychody",
            "Suma przychod&oacute;w operacyjnych",
            "Revenues " };

        private List<string> EBIT = new List<string> {
            "Zysk z działalności operacyjnej",
            "Zysk na działalności operacyjnej",
            "Zysk  na działalności operacyjnej",
            "Zysk z działalności operacyjnej (EBIT)",
            "Zysk (strata) z działalności operacyjnej",
            "Zysk / strata z działalności operacyjnej",
            "Zysk / (strata) z działalności operacyjnej",
            "Zysk / (strata) operacyjny",
            "Zysk/strata na działalności operacyjnej",
            "Zysk (strata) na działalności operacyjnej",
            "Zysk ( strata ) z działaności operacyjnej",
            "Zysk  ( strata ) z działaności operacyjnej",
            "ZYSK (STRATA) NA DZIAŁALNOŚCI OPERACYJNEJ",
            "EBIT (zysk brutto + odsetki od kredyt&oacute;w)",
            "Wynik na działalności operacyjnej",
            "Operating profit" };

        private List<string> EarningBeforeTaxes = new List<string> { 
            "Zysk brutto",
            "Zysk brutto ze sprzedaży",
            "Zysk przed opodatkowaniem",
            "Zysk ze sprzedaży",
            "Zysk  brutto przed opodatkowaniem",
            "Zysk (strata) brutto przed opodatkowaniem",
            "Zysk (strata) przed opodatkowaniem",
            "Zysk / (strata) przed opodatkowaniem",
            "Zysk / (Strata) przed opodatkowaniem",
            "Zysk ( strata ) przed opodatkowaniem",
            "Zysk/strata brutto",
            "Zysk / strata brutto",
            "Zysk / (strata) brutto",
            "Zysk (strata) brutto na sprzedaży",
            "Zysk (strata) ze sprzedaży",
            "Zysk (starta) brutto",
            "ZYSK (STRATA) BRUTTO",
            "Zysk (strata) brutto",
            "Zysk/(strata) brutto ze sprzedaży  z działaności kontynuowanej",
            "Strata przed opodatkowaniem", 
            "Strata brutto",
            "Wynik brutto",
            "Profit (loss) before tax" };

        private List<string> NetProfit = new List<string> { 
            "Zysk netto",
            "Zysk netto og&oacute;łem",
            "Zysk netto okresu sprawozdawczego",
            "Zysk  netto z działalności kontynuowanej",
            "Zysk (strata) netto",
            "ZYSK (STRATA) NETTO",
            "Zysk / (strata) netto",
            "Zysk / (Strata) netto",
            "Zysk ( strata ) netto",
            "Zysk (strat) netto",
            "Zysk /strata netto",
            "Zysk/strata netto",
            "Zysk (strata) netto za okres",
            "Zysk (strata) netto razem",
            "Zysk (strata) netto podmiotu dominującego",
            "Zysk (strata) netto akcjonariuszy jednostki dominującej",
            "Zysk / strata netto przypadający na akcjonariuszy jednostki dominującej",
            "Zysk / (strata) netto przypadający akcjonariuszom Jednostki Dominującej",
            "Zysk (strata) netto przypadający na akcjonariuszy jednostki dominującj",
            "Zysk (strata) netto przypadający akcjonariuszom jednostki dominującej",
            "Zysk (strata) netto z działalności kontynuowanej",
            "Zysk / (Strata) netto z działalności kontynuowanej przypadający na akcjonariuszy Emitenta",
            "Zysk za okres sprawozdawczy",
            "Zysk za okres sprawozdawczy przypadający Akcjonariuszom Jednostki Dominującej",
            "Wynik netto przypadający akcjonariuszom ING Banku Śląskiego S.A.",
            "Całkowite dochody netto za okres",
            "Zysk za okres",
            "Net profit (loss)" };

        private List<string> OperatingActivitiesCF = new List<string> {
            "Środki pieniężne netto z działalności operacyjnej",
            "Przepływy pieniężne netto z działalności operacyjnej",
            "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI OPERACYJNEJ",
            "Przepływy pieniężne z działalności operacyjnej",
            "Przepływy netto z działalności operacyjnej",
            "Przepływy środk&oacute;w pieniężnych z działalności operacyjnej",
            "Przepływyw pieniężne netto z działalności operacyjnej",
            "Przepływy środk&oacute;w pieniężnych netto z działalności operacyjnej",
            "Przepływy środk&oacute;w pieniężnych w działalności operacyjnej",
            "Cash flows provided by (used in) operating activities" };

        private List<string> WorkingCapital = new List<string> {
            "Kapitał obrotowy" };

        private List<string> InvestmentCF = new List<string> {
            "Środki pieniężne netto z działalności inwestycyjnej",
            "Środki pieniężne neto z działalności inwestycyjnej",
            "Przepływy pieniężne netto z działalności inwestycyjnej",
            "Przepływy pieniezne netto z działalności inwestycyjnej",
            "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI INWESTYCYJNEJ",
            "Przepływy pieniężne z działalności inwestycyjnej",
            "Przepływy pieniężne  z działalności inwestycyjnej",
            "Przepływy netto z działalności inwestycyjnej",
            "Przepływy środk&oacute;w pieniężnych z działalności inwestycyjnej",
            "Przepływy środk&oacute;w pieniężnych netto z działalności inwestycyjnej",
            "Przepływy środk&oacute;w pieniężnych w działalności inwestycyjnej",
            "Cash flows used in investing activities" };

        private List<string> FinancialCF = new List<string> {
            "Środki pieniężne netto z działalności finansowej",
            "Przepływy pieniężne netto z działalności finansowej",
            "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI FINANSOWEJ",
            "Przepływy pieniężne z działalności finansowej",
            "Przepływy pieniężne  z działalności finansowej",
            "Przepływy netto z działalności finansowej",
            "Przepływy pieniężne netto z działalności fnansowej",
            "Przepływy środk&oacute;w pieniężnych z działalności finansowej",
            "Przepływy środk&oacute;w pieniężnych netto z działalności finansowej",
            "Przepływy środk&oacute;w pieniężnych w działalności finansowej",
            "Cash flows (used in) provided by financing activities" };

        private List<string> TotalCF = new List<string> {
            "PRZEPŁYWY PIENIĘŻNE NETTO RAZEM",
            "Przepływy pieniężne netto, razem",
            "Przepływy pieniężne netto razem",
            "Przepływy pienięzne netto, razem",
            "Przepływyw pieniężne netto - razem",
            "Przepływy pieniężne netto - razem",
            "Przepływy pieniężne razem",
            "Przepływy pieniężne netto",
            "Przepływyw pieniężne netto, razem",
            "Przepływy środk&oacute;w pieniężnych w danym roku",
            "Total net cash flow" };

        private List<string> AssetsPrimary = new List<string> {
            "Aktywa",
            "Aktywa razem",
            "Aktywa, razem",
            "Aktywa ogolem",
            "Aktywa og&oacute;łem", 
            "AKTYWA RAZEM",
            "A k t y w a r a z e m",
            "Aktywa, razem (*)",
            "Aktywa razem (*)",
            "Aktywa razem *",
            "Aktywa razem*",
            "Aktywa razem***",
            "Aktywa razem ***",
            "Suma aktyw&oacute;w",
            "Aktywa, razem (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Aktywa razem (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Total assets" };

        private List<string> LiabilitiesPrimary = new List<string> {
            "Pasywa razem",
            "Pasywa ogolem",
            "P a s y w a r a z e m",
            "Pasywa razem (*)" };

        private List<string> FixedAssets = new List<string> {
            "Aktywa trwałe",
            "Aktywa trwałe (*)",
            "Aktywa trwale" };

        private List<string> IntangibleAssets = new List<string> {
            "Wartości niematerialne" };

        private List<string> Equity = new List<string> {
            "Kapitał własny",
            "Kapital wlasny", 
            "KAPITAŁ WŁASNY",
            "Kapitały własne",
            "Kapitał własny og&oacute;łem",
            "Kapitały własne og&oacute;łem",
            "Kapitał własny (aktywa netto)",
            "Kapitał własny razem",
            "Kapitał własny razem***",
            "Kapitał (fundusz) własny",
            "Kapitał własny przypadający na akcjonariuszy jednostki dominującej",
            "Kapitał własny przypisany akcjonariuszom jednostki dominującej",
            "Kapitał własny przypadający na akcjonariuszy Emitenta",
            "Kapitał własny Grupy (*)",
            "Kapitał własny (*)",
            "Kapitał własny *",
            "Kapitał własny ***",
            "Kapitał własny (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };

        private List<string> CurrentAssets = new List<string> {
            "Aktywa obrotowe",
            "Aktywa obrotowe i przeznaczone do sprzedaży (*)" };

        private List<string> Inventory = new List<string> {
            "Zapasy" };

        private List<string> CapitalMasterFund = new List<string> {
            "Kapitał zakładowy",
            "KAPITAŁ ZAKŁADOWY",
            "Kapitał podstawowy",
            "Kapitał (fundusz) podstawowy",
            "Kapitał podstawowy ***",
            "Kapitał zakładowy *",
            "Kapitał zakładowy*",
            "Kapitał zakłądowy *",
            "Kapitał zakładowy (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Kapitał zakładowy  (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };

        private List<string> CapitalReserveFund = new List<string> {
            "Kapital zapasowy",
            "Kapitał (fundusz) zapasowy" };

        private List<string> LongTermLiabilities = new List<string> {
            "Zobowiązania długoterminowe",
            "Zobowiązanie długoterminowe",
            "ZOBOWIĄZANIA DŁUGOTERMINOWE",
            "Zobowiazania długoterminowe",
            "Zobowiazania dlugoterminowe",
            "Zobowiązania długoterminowe i rezerwy",
            "Zobowiązania i rezerwy długoterminowe",
            "Zobowiązania długoterminowe (*)",
            "Zobowiązania długoterminowe *",
            "Zobowiązania długoterminowe ***",
            "Zobowiązania długoterminowe (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Długotermiowe zobowiązania i rezerwy" };

        private List<string> ShortTermLiabilities = new List<string> {
            "Zobowiązania kr&oacute;tkoterminowe",
            "Zobowiazania kr&oacute;tkoterminowe",
            "ZOBOWIAZANIA KRÓTKOTERMINOWE",
            "Zobowiazania krotkoterminowe",
            "Zobowiazania krótkoterminowe",
            "w tym zobowiązania kr&oacute;tkoterminowe",
            "Zobowiązana kr&oacute;tkoterminowe",
            "Zobowiązania i rezerwy kr&oacute;tkoterminowe",
            "Zobowiązania kr&oacute;tkoterminowe (*)",
            "Zobowiązania kr&oacute;tkoterminowe *",
            "Zobowiazania kr&oacute;tkoterminowe*",
            "Zobowiązania kr&oacute;tkoterminowe ***",
            "ZOBOWIAZANIA KR&Oacute;TKOTERMINOWE",
            "Zobowiązania kr&oacute;tkoterminowe (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Kr&oacute;tkoterminowe zobowiązania i rezerwy" };

        private List<string> ShareNumbers = new List<string> {
            "Liczba akcji",
            "Liczba akcji w szt.",
            "Liczba akcji (w szt.)",
            "Liczba akcji (szt.)",
            "Liczba akcji  (w szt.)",
            "Liczba akcji ( w szt. )",
            "Liczba akcji (tys. szt.)",
            "Liczba akcji na dzień bilansowy",
            "Liczba akcji (w szt.) (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Liczba akcji na dzień bilansowy, pomniejszona o akcje własne (w szt.)",
            "Liczba akcji na dzień bilansowy (w szt.)",
            "Liczba akcji (w szt.) (*)",
            "Liczba akcji (w tys. szt.)",
            "Liczba akcji  (w szt.)*",
            "Liczba akcji &ndash;  w szt.",
            "LICZBA AKCJI",
            "Ilość akcji",
            "Ilość akcji (w szt.)",
            "Ilość akcji zwykłych (co do dywidendy)",
            "Średnia ważona liczba akcji zwykłych (w szt.)",
            "Średnia ważona akcji zwykłych",
            "Średnia ważona liczba wyemitowanych akcji w sztukach",
            "Średnia ważona liczba akcji w okresie" };

        private List<string> Other = new List<string> {
            "Zobowiązania",
            "Zobowiązania razem",
            "Zobowiązania, razem",
            "Zobowiązanie i rezerwy na zobowiązania",
            "Zobowiązania i rezerwy na zobowiązania",
            "Zobowiązania i rezerwy na zobowiązania*",
            "Zobowiązania i rezerwy na zobowiązania***",
            "Zobowiązania i rezerwy na zobowiązania ***",
            "Zobowiązania i rezerwy, razem",
            "Zobowiązania i rezerwy na zobowiązania (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Rezerwy",

            "Koszt własny sprzedaży",

            "Zadłużenie netto/ (środki pieniężne netto)",
            "Nakłady kapitałowe",
            
            "Całkowite dochody og&oacute;łem",
            "Całkowite dochody",

            "Zysk brutto ze sprzedazy",
            "Zyski/ (Straty) ze sprzedaży akcji",
            "Zysk/strata na sprzedaży",
            "Zysk EBITDA",
            "EBITDA",
            "EBITDA (wynik operacyjny + amortyzacja)",
            "EBITDA (EBIT + amortyzacja)",
            "Zysk (strata) brutto ze sprzedaży",

            "Środki pieniężne i depozyty kr&oacute;tkoterminowe",
            "Środki pieniężne i ich ekwiwalenty na koniec okresu",

            "",
            "i",

            "Zwiększenie /(zmniejszenie) netto środk&oacute;w pieniężnych i ich ekwiwalent&oacute;w", //??????????????????
            
            "Średnioważona liczba akcji w okresie",
            "Średnia ważona liczba akcji (w szt.)",
            "Średnia ważona liczba akcji zastosowana do obliczenia rozwodnionego zysku na akcję  (w szt.)",
            "Średnia ważona liczba akcji (w szt.)",
            "Średnia ważona rozwodniona liczba akcji zwykłych (w szt.)",

            "Podstawowy i rozwodniony zysk (strata) na jedną akcję zwykłą (w zł)",
            "Podstawowy zysk / (strata) z działalności kontynuowanej na jedną akcję zwykłą (w zł)",
            "Rozwodniony zysk /(strata)  z działalności kontynuowanej na jedną akcję zwykłą (w zł)",
            "Rozwodniony zysk (strata) na jedną akcję zwykłą (w zł/EUR)",
            "Rozwodniony zysk za okres sprawozdawczy na jedną akcję zwykłą przypisany Akcjonariuszom Jednostki Dominującej (w PLN/EUR)",
            "Zysk (strata) netto na jedną akcję zwykłą (w zł /  EUR) przypadający na akcjonariuszy jednostki dominującej",
            "Zysk / (strata) na jedną akcję zwykłą (w PLN/EUR)",
            "Zysk (strata) na jedną akcję zwykłą (w zł/ EUR)",
            "Zysk / strata na jedną akcję zwykłą ( w zł/EUR )",
            "Zysk (strata) na jedną akcję - podstawowy z zysku za okres (w zł/EUR)",
            "Zysk (strata) na jedną akcję zwykłą",
            "Zysk (strata) na jedną akcję zwykłą (w zł / EUR)",
            "Zysk netto na jedną akcję zwykłą",
            "Zysk (strata) na jedną akcję",
            "Zysk za okres sprawozdawczy na jedną akcję zwykłą przypisany Akcjonariuszom Jednostki Dominującej (w PLN/EUR)",

            "Wartość księgowa na jedną akcję",
            "Wartość księgowa na akcję (zł/euro)",
            "Wartość księgowa na jedną akcję (w zł/EUR)",
            "Wartość księgowa na jedną akcję ( w zł/EUR )",
            "Wartość księgowa na jedną akcję (w zł / EUR)",
            "Wartość księgowa na jedną akcję (w zł/EUR) (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",
            "Wartość aktyw&oacute;w netto na jedną akcję (w zł.)",
            "Rozwodniona wartość aktyw&oacute;w na jedną akcję (w zł)",
            "Rozwodniona wartość księgowa na jedną akcję (w zł/EUR)",
            "Rozwodniona wartość księgowa na jedną akcję (w zł/EUR) (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)",

            "Przypadający: Akcjonariuszom podmiotu dominującego",
            "Zysk (strata) netto podmiotu dominującego na akcję zwykłą (zł/euro)",

            "Zadeklarowana lub wypłacona dywidenda na jedną akcję (w zł/EUR)",
            "Zadeklarowana lub wypłacona dywidenda na jedną akcję (w zł / EUR)" };
    }

    //II. Krezus SA
    //Zysk (strata) ze sprzedaży akcji i udział&oacute;w

    //Zysk (strata) netto przypadający akcjonariuszom podmiotu dominującego
    //Zmiana netto stanu środków pieniężnych i ich ekwiwalentów
    //Kapitał własny przypadający akcjonariuszom jednostki dominującej

    //Zobowiązania razem = Zobowiązania długoterminowe + Zobowiązania kr&oacute;tkoterminowe
    //ZOBOWIĄZANIA I REZERWY NA ZOBOWIĄZANIA

    //ZYSK (STRATA) BRUTTO
    //"Strata operacyjna"
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

    public class Sales : IReportFields    //IncomeStatmentDataKey 41
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Sales()
        {
            Names = new List<string> { "Sprzedaż" };
        }
    }

    public class OwnSaleCosts : IReportFields    //IncomeStatmentDataKey 42
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OwnSaleCosts()
        {
            Names = new List<string> { "" };
        }
    }
    public class SalesCost1 : IReportFields    //IncomeStatmentDataKey 43
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SalesCost1()
        {
            Names = new List<string> { "" };
        }
    }
    public class SalesCost2 : IReportFields    //IncomeStatmentDataKey 44
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SalesCost2()
        {
            Names = new List<string> { "" };
        }
    }
    public class EarningOnSales : IReportFields    //IncomeStatmentDataKey 45
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public EarningOnSales()
        {
            Names = new List<string> { "Przychody ze sprzedaży",
                    "Przychody ze sprzedaży netto",
                    "Przychody ze sprzedaży akcji",
                    "Przychody netto ze sprzedaży produkt&oacute;w, towar&oacute;w i materiał&oacute;w",
                    "PRZYCHODY NETTO ZE SPRZEDAŻY PRODUKT&Oacute;W, TOWAR&Oacute;W I MATERIAŁ&Oacute;W",
                    "Składki ubezpieczeniowe przypisane brutto",
                    "Działaln. kontyn. przychody ze sprzedaży",
                    "Przychody z tytułu odsetek" };
        }
    }


    public class OtherOperationalActivity1 : IReportFields    //IncomeStatmentDataKey 46
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherOperationalActivity1()
        {
            Names = new List<string> { "" };
        }
    }

    public class OtherOperationalActivity2 : IReportFields    //IncomeStatmentDataKey 47
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherOperationalActivity2()
        {
            Names = new List<string> { "" };
        }
    }

    public class EBIT : IReportFields    //IncomeStatmentDataKey 48
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

    public class FinancialActivity1 : IReportFields    //IncomeStatmentDataKey 49
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FinancialActivity1()
        {
            Names = new List<string> { "??????" };
        }
    }

    public class FinancialActivity2 : IReportFields    //IncomeStatmentDataKey 50
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FinancialActivity2()
        {
            Names = new List<string> { "" };
        }
    }

    public class OtherCostOrSales : IReportFields    //IncomeStatmentDataKey 51
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherCostOrSales()
        {
            Names = new List<string> { "" };
        }
    }

    public class SalesOnEconomicActivity : IReportFields    //IncomeStatmentDataKey 52
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SalesOnEconomicActivity()
        {
            Names = new List<string> { "" };
        }
    }

    public class ExceptionalOccurence : IReportFields    //IncomeStatmentDataKey 53
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ExceptionalOccurence()
        {
            Names = new List<string> { "" };
        }
    }

    public class EarningBeforeTaxes : IReportFields    //IncomeStatmentDataKey 54
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public EarningBeforeTaxes()
        {
            Names = new List<string> { "Zysk (strata) przed opodatkowaniem",
                                        "Zysk / (Strata) przed opodatkowaniem",
                                        "Strata przed opodatkowaniem", 
                                        "Zysk przed opodatkowaniem" };
        }
    }

    public class DiscontinuedOperations : IReportFields    //IncomeStatmentDataKey 55
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public DiscontinuedOperations()
        {
            Names = new List<string> { "" };
        }
    }

    public class NetProfit : IReportFields    //IncomeStatmentDataKey 56
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public NetProfit()
        {
            Names = new List<string> { "Zysk (strata) netto", "Zysk netto", 
                                        "ZYSK (STRATA) NETTO",
                                        "Zysk netto okresu sprawozdawczego",
                                        "Zysk / (Strata) netto z działalności kontynuowanej przypadający na akcjonariuszy Emitenta" };
        }
    }

    public class NetParentProfit : IReportFields    //IncomeStatmentDataKey 57
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public NetParentProfit()
        {
            Names = new List<string> { "" };
        }
    }

    //Cash Flow Data

    public class OperatingActivitiesCF : IReportFields    //ICashFlowDataKey 57
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OperatingActivitiesCF()
        {
            Names = new List<string> { "Środki pieniężne netto z działalności operacyjnej",
                    "Przepływy pieniężne netto z działalności operacyjnej",
                    "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI OPERACYJNEJ" };
        }
    }

    public class Depreciation : IReportFields    //ICashFlowDataKey 58
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Depreciation()
        {
            Names = new List<string> { "Amortyzacja" };
        }
    }

    public class ReceivablesChange : IReportFields    //ICashFlowDataKey 59
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ReceivablesChange()
        {
            Names = new List<string> { "Zmiana stanu należności" };
        }
    }

    public class ObligationsStateChange : IReportFields    //ICashFlowDataKey 60
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ObligationsStateChange()
        {
            Names = new List<string> { "Zmiana stanu zobowiązań" };
        }
    }

    public class ReserveAndOtherChange : IReportFields    //ICashFlowDataKey 61
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ReserveAndOtherChange()
        {
            Names = new List<string> { "Zmiana rezerw i pozostałe" };
        }
    }

    public class WorkingCapital : IReportFields    //ICashFlowDataKey 62
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public WorkingCapital()
        {
            Names = new List<string> { "Kapitał obrotowy" };
        }
    }

    //ColumnBL,                                  //64 ? hm...

    public class InvestmentCF : IReportFields    //ICashFlowDataKey 64
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public InvestmentCF()
        {
            Names = new List<string> { "Środki pieniężne netto z działalności inwestycyjnej",
                    "Przepływy pieniężne netto z działalności inwestycyjnej",
                    "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI INWESTYCYJNEJ" };
        }
    }

    public class CapexIntangible : IReportFields    //ICashFlowDataKey 65
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CapexIntangible()
        {
            Names = new List<string> { "CAPEX (niematerialne i rzeczowe)" };
        }
    }

    public class FinancialCF : IReportFields    //ICashFlowDataKey 66
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FinancialCF()
        {
            Names = new List<string> { "Środki pieniężne netto z działalności finansowej",
                    "Przepływy pieniężne netto z działalności finansowej",
                    "PRZEPŁYWY PIENIĘŻNE NETTO Z DZIAŁALNOŚCI FINANSOWEJ" };
        }
    }

    public class SharesIssue : IReportFields    //ICashFlowDataKey 67
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SharesIssue()
        {
            Names = new List<string> { "Emisja akcji" };
        }
    }


    public class LoansAndAdvancesObtained : IReportFields    //ICashFlowDataKey 68
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LoansAndAdvancesObtained()
        {
            Names = new List<string> { "Kredyty i pożyczki uzyskane" };
        }
    }

    public class LoansAndAdvancesRepayed : IReportFields    //ICashFlowDataKey 69
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LoansAndAdvancesRepayed()
        {
            Names = new List<string> { "Spłata kredytów i pożyczek" };
        }
    }

    public class LiabilitiesChange : IReportFields    //ICashFlowDataKey 70
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LiabilitiesChange()
        {
            Names = new List<string> { "Zmiana zadłużenia" };
        }
    }

    public class Dividend : IReportFields    //ICashFlowDataKey 71
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Dividend()
        {
            Names = new List<string> { "Dywidenda" };
        }
    }

    public class TotalCF : IReportFields    //ICashFlowDataKey 72
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public TotalCF()
        {
            Names = new List<string> { "PRZEPŁYWY PIENIĘŻNE NETTO RAZEM",
                    "Przepływy pieniężne netto, razem" };
        }
    }

    //Balance Data

    public class AssetsPrimary : IReportFields         //BalanceDataKey 5
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public AssetsPrimary()
        {
            Names = new List<string> { "Aktywa", "Aktywa razem", "Aktywa ogolem",
                                        "Aktywa og&oacute;łem", 
                                        "AKTYWA RAZEM", "A k t y w a r a z e m",
                    "Aktywa razem (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
        }

        public void addName(string additionalName)
        {
            Names.Add(additionalName);
        }
    }

    public class LiabilitiesPrimary : IReportFields    //BalanceDataKey 6
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LiabilitiesPrimary()
        {
            Names = new List<string> { "Pasywa razem", "Pasywa ogolem",
                                        "P a s y w a r a z e m"};
        }
    }

    public class FixedAssets : IReportFields           //BalanceDataKey 7
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public FixedAssets()
        {
            Names = new List<string> { "Aktywa trwale", "Aktywa trwałe" };
        }
    }

    public class IntangibleAssets : IReportFields      //BalanceDataKey 8
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

    public class TangibleFixedAssets : IReportFields   //BalanceDataKey 9
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

    public class LongTermReceivablesFixA : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermReceivablesFixA()
        {
            Names = new List<string> { "Naleznosci dlugoterminowe", 
                                        "Należności handlowe oraz pozostałe należności" };
        }
    }

    public class LongTermInvestmentFixA : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermInvestmentFixA()
        {
            Names = new List<string> { "Inwestycje dlugoterminowe", 
                                        "Nieruchomosci inwestycyjne" };
        }
    }

    public class OtherFixedAssets : IReportFields
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

    public class CurrentAssets : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CurrentAssets()
        {
            Names = new List<string> { "Aktywa obrotowe" };
        }
    }

    public class Inventory : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Inventory()
        {
            Names = new List<string> { "Zapasy" };
        }
    }

    public class LongTermReceivablesCurA : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermReceivablesCurA()
        {
            Names = new List<string> { "Naleznosci krotkoterminowe",
                                        "Naleznosci krótkoterminowe" };
        }
    }

    public class LongTermInvestmentCurA : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LongTermInvestmentCurA()
        {
            Names = new List<string> { "Inwestycje krotkoterminowe" };
        }
    }

    public class Cash : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public Cash()
        {
            Names = new List<string> { "Srodki pieniezne i ich ekwiwalenty",
                                        "srodki pieniezne i inne aktywa pieniezne" };
        }
    }

    public class OtherCurentAssets : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherCurentAssets()
        {
            Names = new List<string> { "Pozostale aktywa obrotowe" };
        }
    }

    public class AssetsForSale : IReportFields //20 //Aktywa przeznaczone do sprzedaży
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

    public class Equity : IReportFields
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

    public class CapitalMasterFund : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public CapitalMasterFund()
        {
            Names = new List<string> { "Kapitał zakładowy", "KAPITAŁ ZAKŁADOWY",
                                        "Kapitał zakładowy  (na koniec p&oacute;łrocza bieżącego roku obrotowego i na koniec poprzedniego roku obrotowego)" };
        }
    }

    public class ShareOfTreasuryStock : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public ShareOfTreasuryStock()
        {
            Names = new List<string> { "Udzial akcji wlasnych" };
        }
    }

    public class CapitalreserveFund : IReportFields
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

    public class NonControllingInterests : IReportFields
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public NonControllingInterests()
        {
            Names = new List<string> { "Udzialy niekontrolujace" };
        }
    }


    public class LongTermLiabilities : IReportFields       //28 //ZOBOWIĄZANIA DŁUGOTERMINOWE
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

    public class SuppliesAndServicesLT : IReportFields     //29 //Z tytułu dostaw i usług
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SuppliesAndServicesLT()
        {
            Names = new List<string> { "Z tytulu dostaw i uslug" };
        }
    }

    public class LoansAndAdvancesLT : IReportFields        //30 //!* Kredyty i pożyczki
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public LoansAndAdvancesLT()
        {
            Names = new List<string> { "Kredyty i pozyczki dlugoterminowe",
                                        "Kredyty i pozyczki" };
        }
    }

    public class OtherFinancialLT : IReportFields        //32 //!* Inne finansowe zob. długoterminowe
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherFinancialLT()
        {
            Names = new List<string> { "Inne finansowe zobowiazania dlugoterminowe" };
        }
    }

    public class OtherLT : IReportFields        //33 //Inne zobowiązania długoterminowe
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherLT()
        {
            Names = new List<string> { "Inne zobowiazania dlugoterminowe" };
        }
    }

    public class ShortTermLiabilities : IReportFields  //34 //ZOBOWIĄZANIA KRÓTKOTERMINOWE
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

    public class SuppliesAndServicesST : IReportFields  //35 //Z tytułu dostaw i usług
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public SuppliesAndServicesST()
        {
            Names = new List<string> { "Zobowiazania z tytulu dostaw i uslug",
                                        "Z tytulu dostaw i uslug" };
        }
    }

    public class LoansAndAdvancesST : IReportFields  //36 //!*Kredyty i pożyczki
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

    public class OtherFinancialST : IReportFields  //38 //!*Inne finanoswe zob. krótkoterminowe
    {
        public List<string> Names { get; private set; }
        public long Value { get; set; }

        public OtherFinancialST()
        {
            Names = new List<string> { "Inne finansowe zobowiazania krotkoterminowe" };
        }
    }

    public class OtherST : IReportFields  //39 //Inne zobowiązania krótkoterminowe.
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
