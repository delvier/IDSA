using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models.DataStruct;
using IDSA.Modules.CachedDataContainer;

namespace IDSA.Modules.CachedListContainer
{
    class ReportsCacheDataContainner : DataContainer<FinancialData>
    {
        public ReportsCacheDataContainner() : base() {}
        public ReportsCacheDataContainner(IList<FinancialData> lst) : base(lst) { }
    }
}
