using Agenda.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure
{
    public class AgendaContext: DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }


        public AgendaContext(DbContextOptions options): base(options)
        {

        }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
    }
}
