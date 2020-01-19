using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MFEC.SQ.Repository.Bases
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected DbContext DbContext;
        protected DbSet<T> DbSet;

        protected Repository(DbContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }


        public int GetSequence(string name, bool isReset = false)
        {
            if (isReset)
            {
                DbContext.Database.ExecuteSqlRaw($@"ALTER SEQUENCE {name} RESTART WITH 1");
            }

            SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };
            DbContext.Database.ExecuteSqlRaw($"SELECT @result = (NEXT VALUE FOR {name})", result);
            return (int)result.Value;
        }

        public T Add(T entity)
        {
            //clear change tracker that not related to input
            foreach (var entry in DbContext.ChangeTracker.Entries().Where(m => m.Entity != entity))
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is the Deleted, reload the date from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
            DbSet.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
            DbContext.SaveChanges();
            return entities;
        }

        public T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.FirstOrDefault(where);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = DbSet;
            foreach (var inc in includes)
            {
                query = query.Include(inc);
            }
            return query.Where(where);
        }

        public T Update(T entity)
        {
            //clear change tracker that not related to input
            foreach (var entry in DbContext.ChangeTracker.Entries().Where(m => m.Entity != entity))
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    //case EntityState.Added:
                    //    entry.State = EntityState.Detached;
                    //    break;
                    // If the EntityState is the Deleted, reload the date from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
            DbSet.Update(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public TResult Query<TResult>(Func<IQueryable<T>, TResult> queryFunction)
        {
            IQueryable<T> query = DbSet;
            return queryFunction(query);
        }


        public bool Any(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = DbSet;
            return query.Any(where);
        }

        public int Count(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = DbSet;
            return where == null ? query.Count() : query.Count(where);
        }

        public void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
            DbContext.SaveChanges();
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            DbContext.UpdateRange(entities);
            DbContext.SaveChanges();
            return entities;
        }
    }
}
