using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Package.Core.Entity;
using Package.Core.PagedList;
using Package.EntityFrameworkCore;
using Package.EntityFrameworkCore.EF;

namespace Package.Service
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : Entity, new()
    {
        protected readonly IRepository<TEntity> Repository;

        protected BaseService(IRepository<TEntity> repository)
        {
            Repository = repository;
        }

        public virtual void Insert(TEntity entity)
        {
            Repository.Insert(entity);
            Repository.SaveChanges();

        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            Repository.Insert(entities);
            Repository.SaveChanges();

        }

        public virtual void Update(TEntity entity)
        {
            Repository.Update(entity);
            Repository.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            Repository.Update(entities);
            Repository.SaveChanges();
        }

        public virtual void DeleteById(object id)
        {
            Repository.Delete(id);
            Repository.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity is IVirtualDelete)
            {
                (entity as IVirtualDelete).Deleted = true;
                Repository.Update(entity);
            }
            else
            {
                Repository.Delete(entity);
            }
            Repository.SaveChanges();
        }

        public IEnumerable<TEntity> Select()
        {
            //return Repository.Select();
            return null;
        }

        public virtual TEntity GetById(object id)
        {
            return Repository.Find(id);
        }

        public virtual void Dispose()
        {
            Repository.Dispose();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await Repository.InsertAsync(entity);
            Repository.SaveChanges();
        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            await Repository.InsertAsync(entities);
            Repository.SaveChanges();
        }

        public async Task<TEntity> FindAsync(params object[] entities)
        {
            return await Repository.FindAsync(entities);

        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return Repository.GetPagedList(predicate: filter, include: include).Items;
        }

        public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         int pageIndex = 0,
                                         int pageSize = 20,
                                         bool disableTracking = true)
        {
            return Repository.GetPagedList(predicate, orderBy, include, pageIndex, pageSize, disableTracking);
        }
    }
}

