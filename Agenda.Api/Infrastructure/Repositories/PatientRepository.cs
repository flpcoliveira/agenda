using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Infrastructure.Interfaces;
using Agenda.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Agenda.Api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Api.Infrastructure.Repositories
{
    public class PatientRepository : AbstractRepository<AgendaContext, Patient>, IPatientRepository
    {
        public PatientRepository(AgendaContext context) : base(context) { }

        public override Patient Create(Patient entity)
        {
            return Context.Patients.Add(entity).Entity;
        }

        public override void Delete(int id)
        {
            var entity = this.GetById(id);
            Context.Patients.Remove(entity);
        }

        public override IEnumerable<Patient> GetAll()
        {
            return Context
                .Patients
                .AsNoTracking()
                .ToList();
        }

        public override Patient GetById(int id)
        {
            var entity = Context
                .Patients
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (entity == null) throw new EntitynotfoundException($"Patient {id} not found");

            return entity;
        }

        public override Patient Update(Patient entity)
        {            
            return Context.Patients.Update(entity).Entity;
        }
    }
}
