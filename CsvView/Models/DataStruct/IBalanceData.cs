using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models.DataStruct
{
    interface IBalanceData
    {
        long AssetsPrimary { get; set; }
        long LiabilitiesPrimary { get; set; }

    }
    class BalanceData : IBalanceData
    {
        public enum BalanceDataKey
        {
            ColumnF = 6,    //6  //AKTYWA OGOLEM - WIDOK (UKRYJ SZCZEGOLY)
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
        }

        public long AssetsPrimary { get; set; }
        public long LiabilitiesPrimary { get; set; }
    }
}
