using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Reflection;
using IDSA.Models.DataStruct;

namespace IDSA.Modules.DataCalculation
{
    public class ReportDataCalculation : DataCalculation<Report>
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
                    //substract the prevRep.(rpror) -= curRep(rprop)
                    //throw new NotImplementedException();
                }
            }
        }

        /* Calculate to Quarter on the default base.Data Report List */
        public override void CalculationPerform()
        {
           SetData(CalculateToQurater(this.Data));
        }
    }
}
