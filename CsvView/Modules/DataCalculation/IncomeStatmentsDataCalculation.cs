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

        /* provide calculation to single quarter data, by default the reports are cumulative */
        public static IList<Report> CalculateToQurater(IList<Report> lst)
        {
            var res = new List<Report>();
            var prevRep = new Report();
            foreach (Report curRep in lst)
            {
                if (prevRep != null)
                {
                    if (prevRep.Quarter > 1)
                    {
                        ReportsSubstract(new IncomeStatmentData().GetType().GetProperties(), prevRep, curRep);
                        //prevRep -= curRep;
                    }
                }
                prevRep = curRep;
            }
            return res;
        }

        /* propertyInfo[] ReferencePropetries based on them the substraction will take place
           prevReport - on this object data will be manipulated 
           curRep - the report we will substract from */
        public static void ReportsSubstract(PropertyInfo[] propertyInfo, Report prevRep, Report curRep)
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

        public float GetTerminalValue(Company cmp)
        {
            var TV = new TvCalculationFormula();
            TV.Ebit4q = cmp.Reports.Take(4).Select(a => a.IncomeStatement.EBIT).ToList();
            TV.Cash = cmp.Reports.Take(1).Select(r => r.Balance.Cash).FirstOrDefault();
            String totalLoans = cmp.Reports.Take(1).Select(r => new  {
                totalLoans = r.Balance.LoansAndAdvancesLT + r.Balance.LoansAndAdvancesST
            }).ToString();
           
            //TODO : StartFromHERE pljanotx.
            //Int64.TryParse(totalLoans, TV.Loans);

            TV.ShareNumbers = 0;
            TV.CalculateNetDebt();
            return TV.Calculate();
        }

        public Company ToQuarter(Company cmp)
        {
            throw new NotImplementedException();
        }

        public Company ToPercentage(Company cmp)
        {
            throw new NotImplementedException();
        }
    }
}
