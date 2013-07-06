using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models.DataStruct
{
    interface IIncomeStatmentData
    {
        long Sales { get; set; }  //AO //RZiS
        long OwnSaleCosts { get; set; }
        long SalesCost1 { get; set; }
        long SalesCost2 { get; set; }
        long EarningOnSales { get; set; }
        long OtherOperationalActivity1 { get; set; }
        long OtherOperationalActivity2 { get; set; }
        long EBIT { get; set; }
        long FinancialActivity1 { get; set; }
        long FinancialActivity2 { get; set; }
        long OtherCostOrSales { get; set; }
        long SalesOnEconomicActivity { get; set; }
        long ExceptionalOccurence { get; set; }
        long EarningBeforeTaxes { get; set; }
        long DiscontinuedOperations { get; set; }
        long NetProfit { get; set; }
        long NetParentProfit { get; set; }
    }
    public class IncomeStatmentData : IIncomeStatmentData
    {
        public enum IncomeStatmentDataKey
        {
            Sales = 40,                //AO //RZiS //41
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
            NetParentProfit            //BE        //57 
        }
        public long Sales { get; set; }
        public long OwnSaleCosts { get; set; }
        public long SalesCost1 { get; set; }
        public long SalesCost2 { get; set; }
        public long EarningOnSales { get; set; }
        public long OtherOperationalActivity1 { get; set; }
        public long OtherOperationalActivity2 { get; set; }
        public long EBIT { get; set; }
        public long FinancialActivity1 { get; set; }
        public long FinancialActivity2 { get; set; }
        public long OtherCostOrSales { get; set; }
        public long SalesOnEconomicActivity { get; set; }
        public long ExceptionalOccurence { get; set; }
        public long EarningBeforeTaxes { get; set; }
        public long DiscontinuedOperations { get; set; }
        public long NetProfit { get; set; }
        public long NetParentProfit { get; set; }
    }
}
