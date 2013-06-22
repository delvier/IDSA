using IDSA.Events;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Data.Entity;
using System.Linq;

namespace IDSA.Models.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Company> Companies { get; }
        IRepository<Report> Reports { get; }
        void Commit();
        void Load();
        void Clean();
        void DetachAll();
    }

    public class EFUnitOfWork : IUnitOfWork
    {
        #region Members

        private readonly DbContext context;
        private CompanyRepository companies;
        private ReportRepository reports;

        #endregion

        #region Ctors

        public EFUnitOfWork()
        {
            this.context = new Context();
        }

        public EFUnitOfWork(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context wasn't supplied");

            this.context = context;
        }

        #endregion

        #region IUnitOfWork members

        public IRepository<Company> Companies
        {
            get
            {
                if (companies == null)
                    companies = new CompanyRepository(context);
                return companies;
            }
        }

        public IRepository<Report> Reports
        {
            get
            {
                if (reports == null)
                    reports = new ReportRepository(context);
                return reports;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
            //ServiceLocator.Current.GetInstance<IEventAggregator>()
            //    .GetEvent<DatabaseUpdatedEvent>().Publish(true);
        }

        public void Load()
        {
            Companies.Query().Load();
            Reports.Query().Load();
        }

        public void Clean()
        {
            var objCtx = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)context).ObjectContext;
            objCtx.ExecuteStoreCommand("DELETE FROM Reports");
            objCtx.ExecuteStoreCommand("DELETE FROM Companies");
            this.Commit();
        }

        public void DetachAll()
        {
            //foreach (var item in context.Set<Report>().Local.ToList())
            //{
            //    context.Entry(item).State = System.Data.EntityState.Detached;
            //}
            //foreach (var item in context.Set<Company>().Local.ToList())
            //{
            //    context.Entry(item).State = System.Data.EntityState.Detached;
            //}
        }

        #endregion

        #region IDisposable members

        public void Dispose()
        {
            context.Dispose();
        }

        #endregion
    }
}
