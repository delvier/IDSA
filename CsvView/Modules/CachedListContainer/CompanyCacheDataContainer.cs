using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.CachedDataContainer
{
    public class CompanyCacheDataContainer : CacheDataContainer<Company>
    {
        public CompanyCacheDataContainer() : base() {}

        public void SortReports()
        {
            foreach (var cmp in _cacheLst)
            {
                cmp.Reports
                    .OrderBy(r => r.Year)
                    .ThenByDescending(r => r.Quarter);
            }
        }

    }
}
