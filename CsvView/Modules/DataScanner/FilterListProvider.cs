using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Reflection;
using IDSA.Models.DataStruct;

namespace IDSA.Modules.DataScanner
{
    public class FilterListProvider
    {
        private IList<FilterDescriptor> FilterList { get; set; }

        public FilterListProvider()
        {
            FilterList = new List<FilterDescriptor>();

            this.FilterList.Add(
             new FilterDescriptor()
             {
                 Filter = null,
                 Name = "--- Filter Select ---"
             });

            GenerateNullBreakLineFilter();
            GenerateFilters<IncomeStatmentData>();

            GenerateNullBreakLineFilter();
            GenerateFilters<BalanceData>();

            GenerateNullBreakLineFilter();
            GenerateFilters<CashFlowData>();

        }
        private void GenerateNullBreakLineFilter()
        {
            this.FilterList.Add(
            new FilterDescriptor()
            {
                Filter = null,
                Name = "\n"
            });
        }

        private void GenerateFilters<T>() where T : class
        {
            var propertyLst = typeof(T).GetProperties().ToList();

            foreach (var property in propertyLst)
            {
                if (property.PropertyType == typeof(Int64))
                {
                    this.FilterList.Add(
                        new FilterDescriptor()
                            {
                                Filter = new BasicPropertyFilter(property, typeof(T), 0, 0),
                                Name = property.Name.ToString()
                            }
                        );
                }
            }
        }

        public IList<FilterDescriptor> GetFilters()
        {
            return FilterList;
        }
    }
}
