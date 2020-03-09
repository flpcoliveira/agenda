using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Entities
{
    public class Appointment
    {
        public int? Id { get; set; }

        public Patient Patient { get; set; }

        public string Description { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }        
    }
}
