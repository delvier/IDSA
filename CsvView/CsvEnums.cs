using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsvReaderModule
{
    class CsvEnums
    {

        public _company Company { get; set; }
        public _financialData FinancialData { get; set; }

        public enum _financialData
        {
            Id,
            CmpId,
            ColumnC,
            Year,
            Quater,
            ColumnF,
            ColumnG,
            ColumnH,
            ColumnI,
            ColumnJ,
            ColumnK,
            ColumnL,
            ColumnM,
            ColumnN,
            ColumnO,
            ColumnP,
            ColumnQ,
            ColumnR,
            ColumnS,
            ColumnT,
            ColumnU,
            ColumnV,
            ColumnW,
            ColumnX,
            ColumnY,
            ColumnAA,
            ColumnAB,
            ColumnAC,
            ColumnAD,
            ColumnAE,
            ColumnAF,
            ColumnAG,
            ColumnAH,
            ColumnAI,
            ColumnAJ,
            ColumnAK,
            ColumnAL,
            ColumnAM,
            ColumnAN,
            Sales,                     //AO //RZiS
            OwnSaleCosts,              //AP
            SalesCost1,                //AQ
            SalesCost2,                //AR
            EarningOnSales,            //AS
            OtherOperationalActivity1, //AT
            OtherOperationalActivity2, //AU
            EBIT,                      //AV
            FinancialActivity1,        //AW
            FinancialAcvitity2,        //AX
            OtherCostOrSales,          //AY
            SalesOnEconomicActivity,   //AZ
            ExceptionalOccurence,      //BA
            EarningBeforeTaxes,        //BB
            DiscontinuedOperations,    //BC
            NetProfit,                 //BD
            NetParentProfit,           //BE
            ColumnBF, //? where is EBITDA
            ColumnBG, //?
            ColumnBH,
            ColumnBI,
            ColumnBJ,
            ColumnBK,
            ColumnBL,
            ColumnBM,
            ColumnBN,
            ColumnBO,
            ColumnBP,
            ColumnBR,
            ColumnBS,
            ColumnBT,
            ColumnBU,
            ColumnBV,
            ColumnBW,
            ColumnBX
        }

        public enum _company
        {
            Id,
            ColumnB,
            Name,
            Shortcut,
            ColumnE,
            ColumnF,
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
            Addrees,
            HrefStatus,
            ShareNumbers,
            Date2,
            ColumnW,
            ColumnX
        }
    }
}
