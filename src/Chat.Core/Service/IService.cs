using Chat.Common.Datatable;
using Chat.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Service
{
    public interface IService<TContext, TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TContext : class
    {
        TEntity Find(TKey key);

        IEnumerable<TEntity> FindAll();

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TKey key);

        void Delete(TEntity entity);

        DataTableResponse<TEntity> Paging(DataTableRequest request);

    }
}
