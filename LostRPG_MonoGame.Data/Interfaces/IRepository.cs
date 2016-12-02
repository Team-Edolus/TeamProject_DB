namespace LostRPG_MonoGame.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity GetById(int id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where);


    }
}
