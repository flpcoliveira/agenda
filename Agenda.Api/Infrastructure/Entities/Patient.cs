using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Infrastructure.Entities
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string BirthDate { get; set; }
    }
}
