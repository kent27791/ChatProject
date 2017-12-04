using Chat.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Data.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext
    {
        private readonly IDatabaseContext<TContext> _databaseContext;

        public UnitOfWork(IDatabaseContext<TContext> databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Commit()
        {
            _databaseContext.Commit();
        }
    }
}
