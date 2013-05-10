using System;
using System.Data.Entity;

namespace DBModule
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Company> Companies { get; }
        IRepository<Report> Reports { get; }
        void Commit();
    }

    public class EFUnitOfWork : IUnitOfWork
    {
        #region Members

        private readonly DbContext context;
        private CompanyRepository companies;
        private ReportRepository reports;
        
        #endregion

        #region Ctor

        public EFUnitOfWork(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context wasn't supplied");

            this.context = context;
        }
        
        #endregion
        
        //internal DbSet<E> GetDbSet<E>() where E : class
        //{
        //    return context.Set<E>();
        //}

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
