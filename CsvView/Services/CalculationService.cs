using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Reflection;
using IDSA.Models.DataStruct;
using System;

namespace IDSA.Modules.DataCalculation
{
    public class CalculationService : ICalculationService
    {

        public Company ToQuarter(Company cmp)
        {
            cmp.Reports = CalculateToQurater(cmp.Reports);
            return cmp;
        }

        public Company ToPercentage(Company cmp)
        {
            throw new NotImplementedException();
        }

        public float GetTerminalValue(Company cmp)
        {
            var TV = new TvCalculationFormula();
            TV.Ebit4q = cmp.Reports.Take(4).Select(a => a.IncomeStatement.EBIT).ToList();
            TV.Cash = cmp.Reports.Take(1).Select(r => r.Balance.Cash).FirstOrDefault();

            TV.Loans = cmp.Reports.Take(1).Select(r => r.Balance.LoansAndAdvancesLT).FirstOrDefault() +
                       cmp.Reports.Take(1).Select(r => r.Balance.LoansAndAdvancesST).FirstOrDefault();

            TV.ShareNumbers = cmp.ShareNumbers;
            return TV.Calculate();
        }

        /* provide calculation to single quarter data, by default the reports are cumulative */
        private static ObservableListSource<FinancialData> CalculateToQurater(ObservableListSource<FinancialData> lst)
        {
            var res = new ObservableListSource<FinancialData>();
            var prevRep = new FinancialData();
            foreach (FinancialData curRep in lst)
            {
                if (prevRep != null)
                {
                    if (prevRep.Quarter > 1)
                    {
                        ReportsSubstract(
                                    new IncomeStatmentData().GetType().GetProperties(),
                                    prevRep.IncomeStatement,
                                    curRep.IncomeStatement
                                    );
                    }
                }
                prevRep = curRep;
            }
            return res;
        }

        /* propertyInfo[] ReferencePropetries based on them the substraction will take place
           prevReport - on this object data will be manipulated 
           curRep - the report we will substract from */
        private static void ReportsSubstract(PropertyInfo[] propertyInfo, IncomeStatmentData prevRep, IncomeStatmentData curRep)
        {
            PropertyInfo[] ReportPropetries = prevRep.GetType().GetProperties();
            PropertyInfo[] ReferencePropetries = propertyInfo;
            foreach (PropertyInfo rprop in ReportPropetries)
            {
                if (ReferencePropetries.Any(p => p.Name == rprop.Name))
                {
                    Int64 prevPropValue = Int64.Parse(prevRep.GetType().GetProperty(rprop.Name).GetValue(prevRep, null).ToString());
                    Int64 curPropValue = Int64.Parse(curRep.GetType().GetProperty(rprop.Name).GetValue(curRep, null).ToString());
                    var valueToSet = prevPropValue - curPropValue;
                    prevRep.GetType().GetProperty(rprop.Name).SetValue(prevRep, valueToSet, null);
                }
            }
        }
    }
}
