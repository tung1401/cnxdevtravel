using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MFEC.SQ.Repository.Bases
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        bool Any(Expression<Func<T, bool>> where);
        int Count(Expression<Func<T, bool>> where = null);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        int GetSequence(string name, bool isReset = false);
        TResult Query<TResult>(Func<IQueryable<T>, TResult> queryFunction);
        T Update(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
    }
}
