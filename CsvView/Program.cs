using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDSA.Models.Repository;
using IDSA.Views;
using Microsoft.Practices.Prism.Events;
using IDSA.Events;

namespace IDSA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //TODO: Implement Ninject Kernel + CommonServiceLocator(kernel) + ServiceLocation

            // TODO: Should be .InSingletonScope()
            ServiceLocator.Instance.Register<IEventAggregator>(new EventAggregator());
            //ServiceLocator.Instance.Register(new EventDbCreate());
            ServiceLocator.Instance.Register(new EventDbUpdate());
            ServiceLocator.Instance.Register<IViewProvider>(new TabbedViewProvider());
            ServiceLocator.Instance.Register(new DBView());
            ServiceLocator.Instance.Register(new VCsvLoad());
            ServiceLocator.Instance.Register(new VCompany(ServiceLocator.Instance.Resolve<IEventAggregator>()));
            ServiceLocator.Instance.Register(new DataFromHtmlView());
            ServiceLocator.Instance.Register(new Shell(ServiceLocator.Instance.Resolve<IViewProvider>()));
            dbCreate = Task.Factory.StartNew(() => ServiceLocator.Instance.Register<IUnitOfWork>(new EFUnitOfWork(/*new Context(new CreateDatabaseIfNotExists<Context>())*/)));
            dbCreate.ContinueWith((t) =>
                    ServiceLocator.Instance.Resolve<IEventAggregator>()
                        .GetEvent<DatabaseCreatedEvent>().Publish(true),
                    System.Threading.CancellationToken.None, TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext()
                );
            
            Application.Run(ServiceLocator.Instance.Resolve<Shell>());
        }

        public static Task dbCreate { get; private set; }
    }
}
