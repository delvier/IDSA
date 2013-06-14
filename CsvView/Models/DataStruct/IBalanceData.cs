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

        long FixedAssets { get; set; }
        long IntangibleAssets { get; set; }
        long TangibleFixedAssets { get; set; }
        long LongTermReceivablesFixA { get; set; }
        long LongTermInvestmentFixA { get; set; }
        long OtherFixedAssets { get; set; }

        long CurrentAssets {get; set;}
        long Inventory {get;set;}
        long LongTermReceivablesCurA { get; set; }
        long LongTermInvestmentCurA { get; set; }
        long Cash {get;set;}
        long OtherCurentAssets { get; set; }
        long AssetsForSale { get; set; }

        long Equity {get;set;}  
        long CapitalMasterFund {get;set;}
        long ShareOfTreasuryStock {get;set;}
        long CapitalreserveFund {get;set;}
            //ColumnY,    //25  ? 0
            //ColumnZ,    //26  ? 0
        long NonControllingInterests {get;set;}
    }
    class BalanceData : IBalanceData
    {

        public long AssetsPrimary { get; set; }
        public long LiabilitiesPrimary { get; set; }

        public long FixedAssets { get; set; }
        public long IntangibleAssets { get; set; }
        public long TangibleFixedAssets { get; set; }
        public long LongTermReceivablesFixA { get; set; }
        public long LongTermInvestmentFixA { get; set; }
        public long OtherFixedAssets { get; set; }

        public long CurrentAssets { get; set; }
        public long Inventory { get; set; }
        public long LongTermReceivablesCurA { get; set; }
        public long LongTermInvestmentCurA { get; set; }
        public long Cash { get; set; }
        public long OtherCurentAssets { get; set; }
        public long AssetsForSale { get; set; }

        public long Equity { get; set; }
        public long CapitalMasterFund { get; set; }
        public long ShareOfTreasuryStock { get; set; }
        public long CapitalreserveFund { get; set; }
        //ColumnY,    //25  ? 0
        //ColumnZ,    //26  ? 0
        public long NonControllingInterests { get; set; }

        public enum BalanceDataKey
        {   
            AssetsPrimary = 6,            //6  //AKTYWA OGOLEM - WIDOK (UKRYJ SZCZEGOLY)
            LiabilitiesPrimary,           //7  //PASYWA OGOLEM - WIDOK (UKRYJ SZCZEGOLY)

            FixedAssets,                  //8  //AKTYWA TRWAŁE
            IntangibleAssets,             //9  //Wartosci Niematerialne i Prawne WNiP
            TangibleFixedAssets,          //10 //Rzeczowe składniki majątku trwałego
            LongTermReceivablesFixA,     //11 //!* Należnosci długoterminowe
            LongTermInvestmentFixA,      //12 //!* Inwestycje długoterminowe
            OtherFixedAssets,            //13 //Pozostałe aktywa trwałe

            CurrentAssets,              //14 //AKTYWA OBROTOWE
            Inventory,                  //15 //Zapasy
            LongTermReceivablesCurA,    //16 //Naleznosci krótkoterminowe
            LongTermInvestmentCurA,     //17 //Inwestycje krótkoterminowe
            Cash,                       //18 //!* środki pieniężne
            OtherCurentAssets,          //19 //Pozostałe aktywa obrotowe
            AssetsForSale,              //20 //Aktywa przeznaczone do sprzedaży

            Equity,                    //21 //KAPITAŁ WŁASNY
            CapitalMasterFund,         //22 //kapitał fundusz podstawowy
            ShareOfTreasuryStock,      //23 //Udział (akcje) własne (-)
            CapitalreserveFund,        //24 //Kapitał fundusz zapasowy
            ColumnY,                   //25  ? 0
            ColumnZ,                   //26  ? 0
            NonControllingInterests,   //27 //Udziały niekontrolujące

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

        
    }
}
