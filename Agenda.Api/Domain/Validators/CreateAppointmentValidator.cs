using Agenda.Api.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Api.Domain.Validators
{
    public class CreateAppointmentValidator:AbstractValidator<AppointmentDto>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.PatientId).NotNull();
            RuleFor(x => x.StartedAt).NotNull();
            RuleFor(x => x.FinishedAt).NotNull();
        }
    }
}
