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
                    View = typeof(Companies)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Dane finansowe",
                    //View = ServiceLocator.Instance.Resolve<DataFromHtmlView>()
                    View = typeof(InternalTabTest)
                }
            );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Skaner danych",
                    View = typeof(DataScanner)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Csv",
                    //View = null
                    //View = ServiceLocator.Instance.Resolve<VCsvLoad>()
                    View = typeof(CsvLoad)
                }
                );

            //TEST ONLYs
            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Baza Danych",
                    //View = null
                    //View = ServiceLocator.Instance.Resolve<DBView>()
                    View = typeof(DBView)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Dane z weba",
                    //View = ServiceLocator.Instance.Resolve<DataFromHtmlView>()
                    View = typeof(DataFromHtmlView)
                }
            );

            return lst;
        }
    }
}
