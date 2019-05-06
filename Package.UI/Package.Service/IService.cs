using Microsoft.EntityFrameworkCore.Query;
using Package.Core.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Package.Service
{
    public interface IService<TEntity>
    {
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        Task InsertAsync(TEntity entity);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> FindAsync(params object[] entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void DeleteById(object id);
        void Delete(TEntity entity);
        //IEnumerable<TEntity> Select();
        //IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        TEntity GetById(object id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         int pageIndex = 0,
                                         int pageSize = 20,
                                         bool disableTracking = true);
        void Dispose();


    }
}
