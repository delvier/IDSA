using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models.DataStruct
{
    interface ICashFlowData
    {
    }
    class CashFlowData : ICashFlowData
    {
        enum CalshFlowDataKey
        {
            //RACHUNEK CASH FLOW
            ColumnBF =58,                  //BF        //58 //Przepływy pieniężne z działaności operacyjnej
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
    }
}
