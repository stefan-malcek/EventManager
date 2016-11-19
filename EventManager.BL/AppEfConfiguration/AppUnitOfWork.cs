using System;
using System.Data.Entity;
using EventManager.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFramework;

namespace EventManager.BL.AppEfConfiguration
{
    public class AppUnitOfWork : EntityFrameworkUnitOfWork
    {
        public new EventManagerDbContext Context => (EventManagerDbContext)base.Context;

        public AppUnitOfWork(IUnitOfWorkProvider provider, Func<DbContext> dbContextFactory, DbContextOptions options)
             : base(provider, dbContextFactory, options)
        { }
    }
}
