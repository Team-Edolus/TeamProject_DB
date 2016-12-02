namespace LostRPG_MonoGame.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using LostRPG_MonoGame.Data.Interfaces;
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly LostRPGContext context;


        public Repository(LostRPGContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var element in entities)
            {
                this.context.Set<TEntity>().Remove(element);
            }
        }

        public TEntity GetById(int id)
        {
            return this.context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where(predicate);
        }
    }
}
