using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace DBModule
{
    public interface IRepository<E>
    {
        void Add(E entity);
        void Update(E entity);
        void Remove(E entity);
        IQueryable<E> Query();
        //DbSet<E> GetAll();    // TODO: problem with DbSet<E> ???
        BindingList<E> GetAll();
    }
    
    public abstract class EFRepository<E> : IRepository<E>
        where E : class
    {
        #region Members
        
        protected readonly DbSet<E> dbSet;

        #endregion

        #region Ctor

        public EFRepository(DbContext context)
        {
            dbSet = context.Set<E>();
        }

        #endregion

        #region IRepository members

        public abstract E GetById(int id);

        public virtual void Add(E entity)
        {
            dbSet.Add(entity);
        }

        public void Update(E entity)
        {
            dbSet.Attach(entity);
        }

        public void Remove(E entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<E> Query()
        {
            return dbSet;
        }

        //public DbSet<E> GetAll()
        //{
        //    return dbSet;
        //}

        public BindingList<E> GetAll()
        {
            return dbSet.Local.ToBindingList();
        }

        //public void Load()
        //{
        //    return dbSet.Load
        //}

        #endregion
    }

    public class CompanyRepository : EFRepository<Company>
    {
        public CompanyRepository(DbContext context) : base(context) { }

        public override Company GetById(int id)
        {
            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public Company GetBySymbol(string shortcut)
        {
            return dbSet.SingleOrDefault(x => x.Shortcut == shortcut);
        }

        public override void Add(Company company)
        {
            // TODO: Add Cashing Entites (.NET 4.5 contains in automatically)
            if (dbSet.All(c => c.Shortcut != company.Shortcut)) //dbSet.Contains(company))
                base.Add(company);
        }
    }

    public class ReportRepository : EFRepository<Report>
    {
        public ReportRepository(DbContext context) : base(context) { }

        public override Report GetById(int id)
        {
            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public override void Add(Report report)
        {
            //if(dbSet.)
            //TODO: Add using ReportComparer
            if (dbSet.Any(r => r.CompanyId == report.CompanyId && r.Year == report.Year && r.Quarter == report.Quarter))    // TODO: Add comparer functions
                throw new InvalidOperationException("Can not add existing report to the database");
                // base.Update(report);    // TODO: Jakis fuck-up z update'owaniem raportow w bazie !!!!!!!
            else
                base.Add(report);
        }
    }


    // In .NET exists 
    // System.Data.Objects.IObjectSet<T> 
    // which is equal to Repository<T>
    // but has another type ObjectContext != DbContext
    interface IDataStore
    {
        IUnitOfWork EFUnitOfWork();
        System.Data.Objects.IObjectSet<T> Set<T>() where T : class;
    }
}
