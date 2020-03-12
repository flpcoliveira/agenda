using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Infrastructure.Interfaces;
using Agenda.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Agenda.Api.Exceptions;

namespace Agenda.Api.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AgendaContext _context;

        public AppointmentRepository(AgendaContext context)
        {
            _context = context;
        }

        public Appointment Create(Appointment entity)
        {
            return _context.Appointments.Add(entity).Entity;
        }

        public void Delete(int id)
        {
            var entity = this.GetById(id);
            _context.Remove(entity);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) throw new EntitynotfoundException("Appointment not found");
            return appointment;
        }

        public Appointment Update(Appointment entity)
        {
            return _context.Appointments.Update(entity).Entity;
        }
    }
}
