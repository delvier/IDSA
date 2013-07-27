using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Reflection;
using IDSA.Models.DataStruct;
using System;

namespace IDSA.Modules.DataCalculation
{
    class IncomeStatmentsDataCalculation : DataCalculation<IncomeStatmentData>
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

        /* propertyInfo[] ReferencePropetries based on the substraction will take place
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

        /* Calculation of terminal value based on external report list (must be sorted) */
        public static float CalculateTerminalValue(long shareNumbers, IList<Report> repList)
        {
            var TV = new TvCalculationFormula();
            TV.Ebit4q = repList.Take(4).Select(a => a.EBIT).ToList();
            TV.Cash = 0;
            TV.Loans = 0;
            TV.ShareNumbers = 0;
            TV.CalculateNetDebt();
            return TV.Calculate();
        }

        /* Calculate to Quarter on the default base.Data Report List */
        public override void CalculationPerform()
        {
           // SetData(CalculateToQurater(this.Data));
        }

        public override float CalculateTerminalValue(long shareNumbers)
        {
            return (float)1;
            //return CalculateTerminalValue(shareNumbers, Data);
        }

    }
}
