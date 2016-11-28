namespace LostRPG.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using LostRPG.Data.Interfaces;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly LostRPGDbContext Context;
        
        public Repository(LostRPGDbContext context)
        {
            this.Context = context;
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var el in entities)
            {
                this.Context.Set<TEntity>().Remove(el);
            }
        }

        public TEntity GetById(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expr)
        {
            return this.Context.Set<TEntity>().Where(expr);
        }
    }
}
