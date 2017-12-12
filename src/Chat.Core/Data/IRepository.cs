using Chat.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Chat.Core.Data
{
    public interface IRepository<TContext, TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : class
    {
        IQueryable<TEntity> Query();

        TEntity Find(TKey key);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey key);

        void Delete(TEntity entity);

        IQueryable<TEntity> FromSql(RawSqlString sql, params object[] parameters);


    }
}
