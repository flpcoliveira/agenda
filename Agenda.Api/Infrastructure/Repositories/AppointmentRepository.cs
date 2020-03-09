using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Infrastructure.Interfaces;
using Agenda.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private AgendaContext Context { get; set; }

        public AppointmentRepository(AgendaContext context)
        {
            Context = context;
        }

        public Appointment Create(Appointment model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Appointment GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Appointment Update(Appointment model)
        {
            throw new System.NotImplementedException();
        }
    }
}
