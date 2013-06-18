using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public class EbitBasicFilter : BaseFilter
    {
        public EbitBasicFilter(int low, int high)
            : base(low, high)
        { }

        public EbitBasicFilter() : base()
        {
            
        }

        public override IList<Company> FilterAction(IList<Company> lst)
        {
            foreach (Company cmp in lst)
            {
                int matchNum = cmp.Reports.Count(r => r.EBIT > _lowValue && r.EBIT < _highValue);
                if (matchNum == 0)
                    lst.Remove(cmp);
            }
            return lst;
        }
    }
}
