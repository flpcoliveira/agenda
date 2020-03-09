using Agenda.Api.Infrastructure;
using Agenda.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Data.Interfaces
{
    interface IAppointmentRepository : IRepository<Appointment, AgendaContext>
    {
    }
}
