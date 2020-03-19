using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Interfaces
{
    public interface IRepository <T>
    {
        public void SaveChanges();

        public Task SaveChangesAsync();

        public Task<List<T>> GetAll();

        public T GetById(int id);

        public T Create(T model);

        public T Update(T model);

        public void Delete(int id);
    }
}
