using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models
{
    //TODO: pin to compare Reports
    public class ReportComparer : IEqualityComparer<Report>
    {
        public bool Equals(Report x, Report y)
        {
            return true;// (x.CompanyId == y.CompanyId && x.Year == y.Year && x.Quarter == y.Quarter);
        }

        public int GetHashCode(Report obj)
        {
            return obj.ReportId.GetHashCode();
        }
    }
}
