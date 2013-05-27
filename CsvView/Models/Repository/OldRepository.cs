using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace IDSA.Models.Repository
{
    public interface IEntityRepository : IDisposable
    {
        void Add<E>(E entity) where E : class;
        void Add<E>(List<E> entity) where E : class;
        void Update<E>(E entity) where E : class;
        void Delete<E>(E entity) where E : class;
        IQueryable<E> Select<E>() where E : class;
        E Select<E>(object key) where E : class;
        bool SaveChanges();
    }

    public abstract class BaseRepository : IEntityRepository
    {
        public abstract void Add<E>(E entity) where E : class;
        public abstract void Add<E>(List<E> entity) where E : class;
        public abstract void Update<E>(E entity) where E : class;
        public abstract void Delete<E>(E entity) where E : class;
        public abstract IQueryable<E> Select<E>() where E : class;
        public abstract E Select<E>(object key) where E : class;
        public abstract bool SaveChanges();
        public abstract void Dispose();
    }

    public class DbContextRepository<T> : BaseRepository where T : DbContext
    {
        #region Fields

        private T context;

        #endregion

        #region Properties

        public T Context
        {
            get
            {
                if (this.context == null)
                    this.context = Activator.CreateInstance<T>();
                return this.context;
            }
        }

        #endregion

        #region Methods

        public override void Add<E>(E entity)
        {
            context.Set<E>().Add(entity);
            // alternative way
            //Entry(entity).State = EntityState.Added;
        }

        public override void Add<E>(List<E> entities)
        {
            foreach (var item in entities)
            {
                context.Set<E>().Add(item);    
            }
        }

        public override void Update<E>(E entity)
        {
            context.Set<E>().Attach(entity);
            context.Entry<E>(entity).State = EntityState.Modified;
        }

        public override void Delete<E>(E entity)
        {
            context.Set<E>().Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public override bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public override IQueryable<E> Select<E>()
        {
            return context.Set<E>();
        }

        public override E Select<E>(object key)
        {
            return context.Set<E>().Find(key);
        }

        public override void Dispose()
        {
            if (context != null)
                context.Dispose();
        }

        #endregion
    }

    public abstract class GenericEntityRepository<T>
        where T : class
    {
        #region Properties
        public BaseRepository Repository
        {
            get
            {
                return Activator.CreateInstance(BaseRepositoryType) as BaseRepository;
            }
        }

        public abstract Type BaseRepositoryType { get; }

        #endregion

        public virtual void Delete(T entity)
        {
            ExecuteQuery(query =>
            {
                query.Delete<T>(entity);
                query.SaveChanges();
            });
        }

        internal void ExecuteQuery(Action<IEntityRepository> query)
        {
            if (query == null)
                throw new ArgumentException("The query argument can not be null.");

            using (var queryRepository = Repository)
            {
                query(queryRepository);
            }
        }

        public virtual void Add(T entity)
        {
            ExecuteQuery(query =>
                {
                    query.Add<T>(entity);
                    query.SaveChanges();
                });
        }

        public virtual void Add(List<T> entities)
        {
            foreach (var item in entities)
            {
                ExecuteQuery(query =>
                {
                    query.Add<T>(item);
                }); 
            }

            ExecuteQuery(query =>
            {
                query.SaveChanges();
            });
        }

        public virtual void Update(T entity)
        {
            ExecuteQuery(query =>
            {
                query.Update<T>(entity);
                query.SaveChanges();
            });
        }

        public virtual IList<T> Select()
        {
            List<T> results = new List<T>();

            ExecuteQuery(query =>
                {
                    results = query.Select<T>().ToList();
                });

            return results;
        }

        public virtual IList<T> Select(Expression<Func<T, bool>> where)
        {
            if (where == null)
                return Select();

            List<T> results = new List<T>();

            ExecuteQuery(query =>
            {
                results = query.Select<T>().Where<T>(where).ToList();
            });

            return results;
        }

        public virtual T Select(object key)
        {
            if (key == null)
                throw new ArgumentException("The key argument can not be null.");
            
            T entity = null;
            
            ExecuteQuery(query =>
                {
                    entity = query.Select<T>(key);
                });

            return entity;
        }

        public virtual int RowCount()
        {
            int rowCount = -1;

            ExecuteQuery(query =>
            {
                rowCount = query.Select<T>().Count();
            });

            return rowCount;
        }

        public virtual int RowCount(Expression<Func<T, bool>> where)
        {
            if (where == null)
                return RowCount();

            int rowCount = -1;

            ExecuteQuery(query =>
            {
                rowCount = query.Select<T>().Where<T>(where).Count();
            });

            return rowCount;
        }
    }
}
