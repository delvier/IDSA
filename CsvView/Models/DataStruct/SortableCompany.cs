using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace IDSA.Models.DataStruct
{
    public class SortableCompany : Company
    {
        public void SortReports() // simple reports sort.
        {
            base.Reports.OrderBy(r => r.Year).ThenByDescending(r => r.Quarter);
        }
    }
}
