using Agenda.Api.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Repositories
{
    public abstract class AbstractRepository<T, U> : IRepository<U> where T : DbContext
    {
        protected T Context { get; private set; }

        public AbstractRepository(T context)
        {
            Context = context;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public abstract IEnumerable<U> GetAll();
        public abstract U GetById(int id);
        public abstract U Create(U model);
        public abstract U Update(U model);
        public abstract void Delete(int id);
    }
}
