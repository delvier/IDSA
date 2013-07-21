using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using IDSA.Models.DataStruct;

namespace IDSA.Modules.CachedDataContainer
{
    public class CompanyCacheDataContainer : CacheDataContainer<Company>
    {
        public CompanyCacheDataContainer() : base() {}
        public CompanyCacheDataContainer(IList<Company> lst) : base(lst) { }

        public void SortReports()
        {
            foreach (var cmp in _cacheLst)
            {
               // cmp.Reports = cmp.Reports.OrderByDescending(r => r.Year).ThenByDescending(r => r.Quarter).ToList<FinancialData>();
            }
        }

        public static IList<FinancialData> SortReports(IList<FinancialData> rep)
        {
           return rep.OrderByDescending(r => r.Year) //2013-2012..
                    .ThenByDescending(r => r.Quarter).ToList<FinancialData>();//Q1-Q4-Q3-Q2...
        }

    }
}
