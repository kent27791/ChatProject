﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Chat.Core.Domain;
namespace Chat.Core.Data
{
    public interface IDatabaseContext<TContext> where TContext : class
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Commit();
    }
}
