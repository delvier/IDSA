using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvReaderModule.Controllers;

namespace WindowsFormsApplication1
{
    class TabbedViewProvider : IViewProvider
    {
        public TabbedViewProvider()
        {
            ServiceLocator.Instance.Register(new CsvView());
            ServiceLocator.Instance.Register(new DBView());
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
                    Header = "csv_reader",
                    //View = null
                    View = ServiceLocator.Instance.Resolve<CsvView>()
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Database Tables",
                    //View = null
                    View = ServiceLocator.Instance.Resolve<DBView>()
                }
                );

            return lst;
        }
    }
}
