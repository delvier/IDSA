using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataCalculation
{
    class ReportDataCalculation : DataCalculation<Report>
    {
        public IList<Report> CalculateToQuraterReport(IList<Report>)
        {
            var res = new List<Report>();
            return res;
        }
        public override void CalculationPerform()
        {
            throw new NotImplementedException();
        }
    }
}
