using System.Collections.Generic;
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
                    View = ServiceLocator.Instance.Resolve<VCompany>()
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Csv Upload",
                    //View = null
                    View = ServiceLocator.Instance.Resolve<VCsvLoad>()
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

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Data from html",
                    View = ServiceLocator.Instance.Resolve<DataFromHtmlView>()
                }
            );


            return lst;
        }
    }
}
