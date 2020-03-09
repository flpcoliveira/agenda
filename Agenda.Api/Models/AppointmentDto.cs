using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Models
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public int? PatientId { get; set; }

        public string PatientName { get; set; }

        public string PatientBirthDate { get; set; }

    }
}
