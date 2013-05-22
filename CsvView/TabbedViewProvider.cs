using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvReaderModule.Controllers;
using DBModule;
using CsvReaderModule.Views;

namespace WindowsFormsApplication1
{
    class TabbedViewProvider : IViewProvider
    {
        public TabbedViewProvider()
        {
            
            ServiceLocator.Instance.Register(new DBView());
            ServiceLocator.Instance.Register(new VCsvLoad());
            ServiceLocator.Instance.Register(new VCompany());
            Task.Factory.StartNew(() => ServiceLocator.Instance.Register(new EFUnitOfWork(new Context(new DropCreateDatabaseAlways<Context>()) /*new Context(new CreateDatabaseIfNotExists<Context>())*/)));
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
            

            return lst;
        }
    }
}
