using CommonServiceLocator.NinjectAdapter;
using IDSA.Events;
using IDSA.Models.Repository;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            IKernel ninject = new StandardKernel();
            var provider = new NinjectServiceLocator(ninject);
            ServiceLocator.SetLocatorProvider(() => provider);

            var kernel = ServiceLocator.Current.GetInstance<IKernel>();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            kernel.Bind<IViewProvider>().To<TabbedViewProvider>();
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();

            //ServiceLocator.Instance.Register<IEventAggregator>(new EventAggregator());
            //ServiceLocator.Instance.Register<IViewProvider>(new TabbedViewProvider());
            //ServiceLocator.Instance.Register(new DBView());
            //ServiceLocator.Instance.Register(new VCsvLoad());
            //ServiceLocator.Instance.Register(new VCompany(ServiceLocator.Instance.Resolve<IEventAggregator>()));
            //ServiceLocator.Instance.Register(new DataFromHtmlView());
            //ServiceLocator.Instance.Register(new Shell(ServiceLocator.Instance.Resolve<IViewProvider>()));

            //kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>();//.InScope().WithConstructorArgument(;
            //dbCreate = Task.Factory.StartNew(() => kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>()).ContinueWith
            //    ((t) =>
            //    ServiceLocator.Current.GetInstance<EventAggregator>()
            //            .GetEvent<DatabaseCreatedEvent>().Publish(true)
            //    );
            // ServiceLocator.Instance.Register<IUnitOfWork>(new EFUnitOfWork(/*new Context(new CreateDatabaseIfNotExists<Context>())*/)));
            //dbCreate.ContinueWith((t) =>
            //    //ServiceLocator.Instance.Resolve<IEventAggregator>()
            //        ServiceLocator.Current.GetInstance<EventAggregator>()
            //            .GetEvent<DatabaseCreatedEvent>().Publish(true)
                        //, System.Threading.CancellationToken.None, TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext()
                //);
            
            Application.Run(ServiceLocator.Current.GetInstance<Shell>());//ServiceLocator.Instance.Resolve<Shell>());
        }

        public static Task dbCreate { get; private set; }
    }
}
