using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Data.Interfaces
{
    interface IRepository <T, U> where U : DbContext
    {
        protected U Context { get; }

        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public T Create(T model);

        public T Update(T model);

        public void Delete(int id);
    }
}
