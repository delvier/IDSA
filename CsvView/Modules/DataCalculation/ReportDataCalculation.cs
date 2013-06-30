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

        public static void ReportsSubstract(PropertyInfo[] propertyInfo, Report prevRep, Report curRep)
        {
            PropertyInfo[] ReportPropetries = prevRep.GetType().GetProperties();
            PropertyInfo[] ReferencePropetries = propertyInfo;
            foreach (PropertyInfo rprop in ReportPropetries)
            {
                if (ReferencePropetries.Contains(rprop))
                {
                    throw new NotImplementedException();
                }
            }
        }

        public override void CalculationPerform()
        {
            throw new NotImplementedException();
        }
    }
}
