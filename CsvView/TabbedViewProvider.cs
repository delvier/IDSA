﻿using System.Collections.Generic;
using IDSA.Views;

namespace IDSA
{
    class TabbedViewProvider : IViewProvider
    {
        public TabbedViewProvider()
        {
        }
        public EProjectionType ProjectionType
        {
            get { return EProjectionType.Tabbed; }
        }

        public IEnumerable<ViewItemDescriptor> GetViews()
        {
            var lst = new List<ViewItemDescriptor>();

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Spółki",
                    View = typeof(VCompany)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Csv Upload",
                    //View = null
                    //View = ServiceLocator.Instance.Resolve<VCsvLoad>()
                    View = typeof(VCsvLoad)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Database Tables",
                    //View = null
                    //View = ServiceLocator.Instance.Resolve<DBView>()
                    View = typeof(DBView)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Data from html",
                    //View = ServiceLocator.Instance.Resolve<DataFromHtmlView>()
                    View = typeof(DataFromHtmlView)
                }
            );


            return lst;
        }
    }
}
