using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        public IEnumerable<Appointment> AppointmentsBetween(DateTime initialDate, DateTime endDate);
    }
}
