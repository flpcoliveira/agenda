using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Infrastructure.Interfaces;
using Agenda.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Agenda.Api.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace Agenda.Api.Infrastructure.Repositories
{
    public class AppointmentRepository : AbstractRepository<AgendaContext, Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AgendaContext context) : base(context) { }

        public override Appointment Create(Appointment entity)
        {
            return Context.Appointments.Add(entity).Entity;
        }

        public override void Delete(int id)
        {
            var entity = this.GetById(id);
            Context.Remove(entity);
        }

        public override IEnumerable<Appointment> GetAll()
        {
            return Context
                .Appointments
                .Include(appointment => appointment.Patient)
                .AsNoTracking()
                .ToList();
        }

        public bool ExistsAppointmentBetween(DateTime initialDate, DateTime endDate)
        {
            return Context.Appointments.Any(OverflowedAppointments(initialDate, endDate));
        }

        public override Appointment GetById(int id)
        {
            var appointment = Context
                .Appointments
                .Include(appointment => appointment.Patient)
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (appointment == null) throw new EntitynotfoundException($"Appointment {id} not found");

            return appointment;
        }

        public override Appointment Update(Appointment entity)
        {
            return Context.Appointments.Update(entity).Entity;
        }

        private Expression<Func<Appointment, bool>> OverflowedAppointments(DateTime initialDate, DateTime endDate)
        {
            return appointment => (initialDate >= appointment.StartedAt && initialDate <= appointment.FinishedAt) ||
            (endDate >= appointment.StartedAt && endDate <= appointment.FinishedAt);
        }
    }
}
