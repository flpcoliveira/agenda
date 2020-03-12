using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Domain.Interfaces
{
    public interface IService <T>
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public T Create(T model);

        public T Update(T model);

        public void Delete(int id);
    }
}
