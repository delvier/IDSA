﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Reflection;

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

            var rpropList = new Report().GetType().GetProperties().ToList();
            foreach (PropertyInfo rpor in rpropList)
            {
                if (rpor.PropertyType == typeof(Int64))
                {
                    this.FilterList.Add(
                    new FilterDescriptor()
                    {
                        Filter = new ReportPropertiesFilter(rpor, 0, 0),
                        Name = rpor.Name.ToString()
                    }
                );
                }
            }

           
            //this.FilterList.Add(
            //   new FilterDescriptor()
            //   {
            //       Filter = new EbitBasicFilter(),
            //       Name = "EBIT Basic Filter"
            //   });

            //this.FilterList.Add(
            //    new FilterDescriptor()
            //    {
            //        Filter = new EbitBasicFilter(),
            //        Name = "EBIT 2 Basic Filter"
            //    });


            //this.FilterList.Add(
            //    new FilterDescriptor()
            //    {
            //        Filter = new EbitBasicFilter(),
            //        Name = "EBIT 3 Basic Filter"
            //    });

        }

        public IList<FilterDescriptor> GetFilters()
        {
            return FilterList;
        }
    }
}