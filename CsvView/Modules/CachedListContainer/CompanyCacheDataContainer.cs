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
                cmp.Reports  = cmp.Reports
                                  .OrderByDescending(r => r.Year)
                                  .ThenByDescending(r => r.Quarter)
                                  //.OrderByDescending(r=>r.FinancialReportReleaseDate)
                                  .ToObservableListSource<FinancialData>();
            }
        }

        public Company GetCompany(String name)
        {
            return _cacheLst.Where(c => c.Name == name).FirstOrDefault();
        }

        public Company GetCompanyByFullName(String fullName)
        {
            return _cacheLst.Where(c => c.FullName == fullName).FirstOrDefault();
        }

        public void AddCompany(Company company)
        {
            _cacheLst.Add(company);
        }

        public void Recreate(IList<Company> cacheLst)
        {
            _cacheLst = cacheLst;
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

        public static ObservableListSource<T> ToObservableListSource<T>(this IEnumerable<T> coll) where T : class
        {
            var observableSource = new ObservableListSource<T>();
            foreach (var e in coll)
                observableSource.Add(e);
            return observableSource;
        }
    }
}
