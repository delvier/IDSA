using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class TabbedViewProvider : IViewProvider
    {
        public TabbedViewProvider()
        {
            ServiceLocator.Instance.Register(new CsvView());
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

            return lst;
        }
    }
}
