using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBModule.DataBase
{
    //TODO: pin to compare Reports
    public class ReportComparer : IEqualityComparer<Report>
    {
        public bool Equals(Report x, Report y)
        {
            return (x.CompanySymbol == y.CompanySymbol && x.Year == y.Year && x.Period == y.Period);
        }

        public int GetHashCode(Report obj)
        {
            return obj.ID.GetHashCode();
        }
    }
}
