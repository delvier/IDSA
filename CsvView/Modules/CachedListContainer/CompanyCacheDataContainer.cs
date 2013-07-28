using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using IDSA.Models.DataStruct;
using System.Collections.ObjectModel;

namespace IDSA.Modules.CachedDataContainer
{
    public class CompanyDataContainer : DataContainer<Company>
    {
        public CompanyDataContainer() : base() {}
        public CompanyDataContainer(IList<Company> lst) : base(lst) { }

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

        public Company GetCompany(String name)
        {
            return _cacheLst.Where(c => c.Name == name).FirstOrDefault();
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
