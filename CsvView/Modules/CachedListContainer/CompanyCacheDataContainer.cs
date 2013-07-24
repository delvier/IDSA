using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using IDSA.Models.DataStruct;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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
                ObservableCollection<FinancialData> observableColection = 
                                                cmp.Reports.OrderByDescending(r=>r.FinancialReportReleaseDate)
                                                           .ToObservableCollection<FinancialData>();
                var sortedReports = new ObservableListSource<FinancialData>(observableColection);
                cmp.Reports = sortedReports;
                                
            }
        }

        public static IList<FinancialData> SortReports(IList<FinancialData> rep)
        {
           return rep.OrderByDescending(r => r.Year) //2013-2012..
                    .ThenByDescending(r => r.Quarter).ToList<FinancialData>();//Q1-Q4-Q3-Q2...
        }

    }

    public static class CollectionExtensions
    {

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> coll)
        {
            var c = new ObservableCollection<T>();
            foreach (var e in coll)
                c.Add(e);
            return c;
        }

    }

}
