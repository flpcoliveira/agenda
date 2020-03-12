using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Models;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
    }
}
