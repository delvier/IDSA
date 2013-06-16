using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models.DataStruct
{
    interface IFinancialData
    {
        BaseFinData Base                   { get; set; }
        BalanceData Balance                { get; set; }
        IncomeStatmentData IncomeStatement { get; set; }
        CashFlowData CashFlow              { get; set; }
        // Potential of "Segmenty" Data
    }
    public class FinancialData : IFinancialData
    {
        public BaseFinData Base { get; set; }
        public BalanceData Balance {get;set;}
        public IncomeStatmentData IncomeStatement { get; set; }
        public CashFlowData CashFlow {get;set;}
    }
}
