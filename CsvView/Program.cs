using CommonServiceLocator.NinjectAdapter;
using IDSA.Models;
using IDSA.Models.Repository;
using IDSA.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using IDSA.Models.DataStruct;
using IDSA.Modules.CachedListContainer;
using IDSA.Modules.DataCalculation;

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

            IKernel ninject = new StandardKernel();
            var provider = new NinjectServiceLocator(ninject);
            ServiceLocator.SetLocatorProvider(() => provider);

            var kernel = ServiceLocator.Current.GetInstance<IKernel>();
            kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
            //Uncomment do Drop Database!!!!!!!!!!!
            //kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument("context", new Context(new DropCreateDatabaseAlways<Context>()));
            //, System.Threading.CancellationToken.None, TaskContinuationOptions.NotOnFaulted, TaskScheduler.FromCurrentSynchronizationContext()
            kernel.Bind<ICacheService>().To<CacheService>().InSingletonScope();
            kernel.Bind<IViewProvider<MixedViewItemDescriptor>>().To<MixedViewProvider>();
            kernel.Bind<IChartService>().To<ChartService>();
            kernel.Bind<ICalculationService>().To<CalculationService>();
            kernel.Bind<IRawData>().To<RawData>();
            kernel.Bind<IDisplayFormat>().To<DisplayFormatService>();
            kernel.Bind<IReportStoreService>().To<ReportStoreService>().InSingletonScope();
            
            Application.Run(ServiceLocator.Current.GetInstance<Shell>());
        }
    }
}
