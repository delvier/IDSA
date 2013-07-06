using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models.DataStruct
{
    interface ICashFlowData
    {
            long OperatingActivitiesCF {get;set;}           //58 //Przepływy pieniężne z działaności operacyjnej
            long Depreciation {get;set;} //?                //59 //Amortyzacja.
            long ReceivablesChange {get;set;}               //60 //Zmiana stanu należności ?
            long ObligationsStateChange { get; set; }       //61 //Zmiana stanu zobowiązań ?
            long ReserveAndOtherChange {get;set;}           //62 //Zmiana rezerw i pozostałe ?
            long WorkingCapital {get;set;}                  //63 //Kapitał obrotowy ?
            
            //ColumnBL,   //64 ? hm dziura...

            long InvestmentCF {get;set;}                 //65 !* Przepływy pieniezne z działanosci inwestycyjnej
            long CapexIntangible {get;set;}              //66 !* CAPEX (niematerialne i rzeczowe)

            long FinancialCF {get;set;}                  //67 !* Przepływy z działalności finansowej.
            long SharesIssue {get;set;}                  //68 ? Emisja akcji
            long LoansAndAdvancesObtained {get;set;}     //69 ? Kredyty i pożyczki uzyskane.
            long LoansAndAdvancesRepayed {get;set;}      //70 ? Spłata kredytów i pożyczek
            long LiabilitiesChange {get;set;}            //71 ? Zmiana zadłużenia
            long Dividend {get;set;}                    //72 Dywidenda

            long TotalCF {get; set;}                    //73 !* PRZEPŁYWY PIENIĘŻNE RAZEM
    }
    public class CashFlowData : ICashFlowData
    {
        public long OperatingActivitiesCF { get; set; }        //58 //Przepływy pieniężne z działaności operacyjnej
        public long Depreciation { get; set; } //?             //59 //Amortyzacja.
        public long ReceivablesChange { get; set; }            //60 //Zmiana stanu należności ?
        public long ObligationsStateChange { get; set; }       //61 //Zmiana stanu zobowiązań ?
        public long ReserveAndOtherChange { get; set; }        //62 //Zmiana rezerw i pozostałe ?
        public long WorkingCapital { get; set; }               //63 //Kapitał obrotowy ?

        //ColumnBL,   //64 ? hm dziura...

        public long InvestmentCF { get; set; }                 //65 !* Przepływy pieniezne z działanosci inwestycyjnej
        public long CapexIntangible { get; set; }              //66 !* CAPEX (niematerialne i rzeczowe)

        public long FinancialCF { get; set; }                  //67 !* Przepływy z działalności finansowej.
        public long SharesIssue { get; set; }                  //68 ? Emisja akcji
        public long LoansAndAdvancesObtained { get; set; }     //69 ? Kredyty i pożyczki uzyskane.
        public long LoansAndAdvancesRepayed { get; set; }      //70 ? Spłata kredytów i pożyczek
        public long LiabilitiesChange { get; set; }            //71 ? Zmiana zadłużenia
        public long Dividend { get; set; }                     //72 Dywidenda

        public long TotalCF { get; set; }                     //73 !* PRZEPŁYWY PIENIĘŻNE RAZEM

        public enum CalshFlowDataKey
        {
            //RACHUNEK CASH FLOW
            OperatingActivitiesCF = 57,                //58 //Przepływy pieniężne z działaności operacyjnej
            Depreciation, //?                          //59 //Amortyzacja.
            ReceivablesChange,                         //60 //Zmiana stanu należności ?
            ObligationsStateChange,                    //61 //Zmiana stanu zobowiązań ?
            ReserveAndOtherChange,                     //62 //Zmiana rezerw i pozostałe ?
            WorkingCapital,                            //63 //Kapitał obrotowy ?
            
            ColumnBL,                                  //64 ? hm...

            InvestmentCF,                              //65 !* Przepływy pieniezne z działanosci inwestycyjnej
            CapexIntangible,                           //66 !* CAPEX (niematerialne i rzeczowe)

            FinancialCF,                               //67 !* Przepływy z działalności finansowej.
            SharesIssue,                               //68 ? Emisja akcji
            LoansAndAdvancesObtained,                  //69 ? Kredyty i pożyczki uzyskane.
            LoansAndAdvancesRepayed,                   //70 ? Spłata kredytów i pożyczek
            LiabilitiesChange,                         //71 ? Zmiana zadłużenia
            Dividend,                                  //72 Dywidenda
            
            TotalCF                                    //73 !* PRZEPŁYWY PIENIĘŻNE RAZEM
        }
    }
}
