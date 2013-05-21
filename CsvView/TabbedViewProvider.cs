using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvReaderModule.Controllers;
using DBModule;

namespace WindowsFormsApplication1
{
    class TabbedViewProvider : IViewProvider
    {
        public TabbedViewProvider()
        {
            ServiceLocator.Instance.Register(new CsvView());
            ServiceLocator.Instance.Register(new DBView());
            Task.Factory.StartNew(() => ServiceLocator.Instance.Register(new EFUnitOfWork(/*new Context(new CreateDatabaseIfNotExists<Context>())*/)));
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
