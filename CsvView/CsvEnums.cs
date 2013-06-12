namespace IDSA
{
    public class CsvEnums
    {
        public enum DataType
        {
            Company,
            Financial
        }

        public enum financialData
        {
            Id,         //1
            CmpId,      //2
            ColumnC,    //3
            Year,       //4
            Quater,     //5
            ColumnF,    //6  //AKTYWA OGOLEM - WIDOK (UKRYJ SZCZEGOLY)
            ColumnG,    //7  //PASYWA OGOLEM - WIDOK (UKRYJ SZCZEGOLY)

            ColumnH,    //8  //AKTYWA TRWAŁE
            ColumnI,    //9  //Wartosci Niematerialne i Prawne WNiP
            ColumnJ,    //10 //Rzeczowe składniki majątku trwałego
            ColumnK,    //11 //!* Należnosci długoterminowe
            ColumnL,    //12 //!* Inwestycje długoterminowe
            ColumnM,    //13 //Pozostałe aktywa trwałe

            ColumnN,    //14 //AKTYWA OBROTOWE
            ColumnO,    //15 //Zapasy
            ColumnP,    //16 //Naleznosci krótkoterminowe
            ColumnQ,    //17 //Inwestycje krótkoterminowe
            ColumnR,    //18 //!* środki pieniężne
            ColumnS,    //19 //Pozostałe aktywa obrotowe
            ColumnT,    //20 //Aktywa przeznaczone do sprzedaży

            ColumnU,    //21 //KAPITAŁ WŁASNY
            ColumnV,    //22 //kapitał fundusz podstawowy
            ColumnW,    //23 //Udział (akcje) własne (-)
            ColumnX,    //24 //Kapitał fundusz zapasowy
            ColumnY,    //25  ? 0
            ColumnZ,    //26  ? 0
            ColumnAA,   //27 //Udziały niekontrolujące

            ColumnAB,   //28 //ZOBOWIĄZANIA DŁUGOTERMINOWE
            ColumnAC,   //29 //Z tytułu dostaw i usług
            ColumnAD,   //30 //!* Kredyty i pożyczki
            ColumnAE,   //31  ? 0
            ColumnAF,   //32 //!* Inne finansowe zob. długoterminowe
            ColumnAG,   //33 //Inne zobowiązania długoterminowe

            ColumnAH,   //34 //ZOBOWIĄZANIA KRÓTKOTERMINOWE
            ColumnAI,   //35 //Z tytułu dostaw i usług
            ColumnAJ,   //36 //!*Kredyty i pożyczki
            ColumnAK,   //37  ? 0
            ColumnAL,   //38 //!*Inne finanoswe zob. krótkoterminowe
            ColumnAM,   //39 //Inne zobowiązania krótkoterminowe.
            ColumnAN,   //40  ? 0

            Sales,                     //AO //RZiS //41
            OwnSaleCosts,              //AP        //42
            SalesCost1,                //AQ - Sum. //43
            SalesCost2,                //AR        //44
            EarningOnSales,            //AS        //45
            OtherOperationalActivity1, //AT - Sum. //46
            OtherOperationalActivity2, //AU        //47
            EBIT,                      //AV        //48
            FinancialActivity1,        //AW - Sum. //49
            FinancialAcvitity2,        //AX        //50
            OtherCostOrSales,          //AY        //51
            SalesOnEconomicActivity,   //AZ        //52
            ExceptionalOccurence,      //BA        //53
            EarningBeforeTaxes,        //BB        //54
            DiscontinuedOperations,    //BC        //55
            NetProfit,                 //BD        //56
            NetParentProfit,           //BE        //57

            //RACHUNEK CASH FLOW
            ColumnBF,                  //BF        //58 //Przepływy pieniężne z działaności operacyjnej
            ColumnBG, //?                          //59 //Amortyzacja.
            ColumnBH,   //60 //Zmiana stanu należności ?
            ColumnBI,   //61 //Zmiana stanu zobowiązań ?
            ColumnBJ,   //62 //Zmiana rezerw i pozostałe ?
            ColumnBK,   //63 //Kapitał obrotowy ?
            ColumnBL,   //64 ? hm dziura...
            ColumnBM,   //65 !* Przepływy pieniezne z działanosci inwestycyjnej
            ColumnBN,   //66 !* CAPEX (niematerialne i rzeczowe)
            ColumnBO,   //67 !* Przepływy z działalności finansowej.
            ColumnBP,   //68 ? Emisja akcji
            ColumnBQ,   //69 ? Kredyty i pożyczki uzyskane.
            ColumnBR,   //70 ? Spłata kredytów i pożyczek
            ColumnBS,   //71 ? Zmiana zadłużenia
            ColumnBT,   //72 Dywidenda
            ColumnBU,   //73 !* PRZEPŁYWY PIENIĘŻNE RAZEM
            //DATY
            ColumnBV,   //74  Sytuacja finansowa na dzień.
            ColumnBW,   //75  Raport wydany dnia. (KEY FOR SORT!)
            ColumnBX    //76
        }

        public enum company
        {
            Id,
            ColumnB,
            Name,
            Shortcut,
            ShareNumbers,
            SharePrice, //F
            Date,
            Description,
            ColumnI,
            ColumnJ,
            ColumnK,
            ColumnL,
            Href,
            PhoneNumber,
            Email,
            FullName,
            HeadAccount,
            Profile,
            Address,
            HrefStatus,
            VoteNumbers,
            Date2,
            ColumnW,
            ColumnX,
            Volumen20    //20SesyjnyObrot
        }
    }
}
