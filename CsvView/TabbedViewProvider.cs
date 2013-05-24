using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DBModule;
using IDSA.Views;

namespace IDSA
{
    class TabbedViewProvider : IViewProvider
    {
        public TabbedViewProvider()
        {
            
            ServiceLocator.Instance.Register(new DBView());
            ServiceLocator.Instance.Register(new VCsvLoad());
            ServiceLocator.Instance.Register(new VCompany());
            ServiceLocator.Instance.Register(new DataFromHtmlView());
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
