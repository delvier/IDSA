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

        public void Add(E entity)
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

        #endregion
    }

    public class CompanyRepository : EFRepository<Company>
    {
        public CompanyRepository(DbContext context) : base(context) { }

        public override Company GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Company GetBySymbol(string symbol)
        {
            return dbSet.SingleOrDefault(x => x.Symbol == symbol);
        }

        public void Add(Company company)
        {
            // TODO: My part is here

            base.Add(company);
        }
    }

    public class ReportRepository : EFRepository<Report>
    {
        public ReportRepository(DbContext context) : base(context) { }

        public override Report GetById(int id)
        {
            return dbSet.SingleOrDefault(x => x.ID == id);
        }

        public void Add(Report report)
        {
            // TODO: My part is here
            //if report exists, then update
            //TODO: Add using ReportComparer
            //if (base.Query().Contains(report))
            //base.Update(report);
            //else

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
