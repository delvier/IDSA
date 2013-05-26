using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBModule;
using IDSA.Views;

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
            ServiceLocator.Instance.Register(new Initialization());
            ServiceLocator.Instance.Register<IViewProvider>(new TabbedViewProvider());
            ServiceLocator.Instance.Register(new DBView());
            ServiceLocator.Instance.Register(new VCsvLoad());
            ServiceLocator.Instance.Register(new VCompany());
            ServiceLocator.Instance.Register(new DataFromHtmlView());
            ServiceLocator.Instance.Register(new Shell(ServiceLocator.Instance.Resolve<IViewProvider>()));
            dbCreate = Task.Factory.StartNew(() => ServiceLocator.Instance.Register<IUnitOfWork>(new EFUnitOfWork(new Context(new DropCreateDatabaseAlways<Context>()))));
            dbCreate.ContinueWith((t) =>
                    ServiceLocator.Instance.Resolve<Initialization>().Initialize(true),
                    System.Threading.CancellationToken.None, TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext()
                );
            
            Application.Run(ServiceLocator.Instance.Resolve<Shell>());
        }

        public static Task dbCreate { get; private set; }
    }
}
