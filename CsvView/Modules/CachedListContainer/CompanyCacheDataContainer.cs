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
        public CompanyCacheDataContainer(IList<Company> lst) : base(lst) { }

        public void SortReports()
        {
            _cacheLst.ToList().ForEach(c => SortReports(c.Reports));
        }

        public static void SortReports(IList<Report> rep)
        {
            rep.OrderByDescending(r => r.Year) //2013-2012..
                .ThenByDescending(r => r.Quarter);//Q1-Q4-Q3-Q2...
        }

    }
}
