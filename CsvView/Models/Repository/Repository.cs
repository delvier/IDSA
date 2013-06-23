using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;

namespace IDSA.Models.Repository
{
    public interface IRepository<E>
    {
        void Add(E entity);
        void Update(E entity);
        void Remove(E entity);
        void RemoveAll();
        IQueryable<E> Query();
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

        public virtual void Update(E entity)
        {
            dbSet.Attach(entity);
        }

        public void Remove(E entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveAll()
        {
            dbSet.Local.Clear();
            //foreach (var item in dbSet.ToList())
            //{
            //    this.Remove(item);
            //}
        }

        public IQueryable<E> Query()
        {
            return dbSet;
        }

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
            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public Company GetBySymbol(string shortcut)
        {
            return dbSet.SingleOrDefault(x => x.Shortcut == shortcut);
        }

        public override void Add(Company company)
        {
            // TODO: Add Cashing Entites (.NET 4.5 contains in automatically)
            //if (dbSet.Any(c => c.Id == company.Id)) //dbSet.Contains(company))
            //    this.Update(company);
            //else
            base.Add(company);
        }

        public override void Update(Company company)
        {
            using (var dbNew = new Context())
            {
                Company temp = dbNew.Companies.Find(company.Id);
                dbNew.Entry<Company>(temp).CurrentValues.SetValues(company);
                dbNew.SaveChanges();
            }
        }
    }

    public class ReportRepository : EFRepository<Report>
    {
        public ReportRepository(DbContext context) : base(context) { }

        public override Report GetById(int id)
        {
            return dbSet.SingleOrDefault(x => x.ReportId == id);
        }

        public override void Add(Report report)
        {
            //TODO: Add using ReportComparer
            //if (dbSet.Any(r => r.CompanyId == report.CompanyId && r.Year == report.Year && r.Quarter == report.Quarter))    // TODO: Add comparer functions
            //if(dbSet.Any(r => r.Id == report.Id))
            //    this.Update(report);
            //else
            base.Add(report);
        }

        public override void Update(Report report)
        {
            using (var dbNew = new Context())
            {
                Report temp = dbNew.Reports.Find(report.ReportId);
                dbNew.Entry<Report>(temp).CurrentValues.SetValues(report);
                dbNew.SaveChanges();
            }
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
