using System;
using Agenda.Api;
using Agenda.Api.Domain.Interfaces;
using Agenda.Api.Domain.Services;
using Agenda.Api.Infrastructure.Contexts;
using Agenda.Api.Infrastructure.Interfaces;
using Agenda.Api.Infrastructure.Repositories;
using Agenda.Api.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Agenda.Test
{
    public class AppointmentTest
    {

        private readonly IAppointmentService _service;

        private readonly IPatientService _patientService;

        public AppointmentTest()
        {

            var services = new ServiceCollection();

            services.AddAutoMapper(typeof(Startup));

            var serviceProvider = services.BuildServiceProvider();

            //services.AddDbContext<AgendaContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            services.AddDbContext<AgendaContext>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AgendaTest;Trusted_Connection=True;MultipleActiveResultSets=true"));


            var context = services.BuildServiceProvider().GetService<AgendaContext>();

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            _service = services.BuildServiceProvider().GetRequiredService<IAppointmentService>();
            _patientService = services.BuildServiceProvider().GetRequiredService<IPatientService>();
        }

        [Fact]
        public void CreateAppointmentSuccessfully()
        {

            var patient = new PatientDto
            {
                Name = "Felipe Cristo de Oliveira",
                BirthDate = new DateTime(1991, 2, 3)
            };

            patient = _patientService.Create(patient);

            var appointment = new AppointmentDto
            {
                PatientId = patient.Id,
                StartedAt = new DateTime(2020, 04, 01, 15, 30, 0),
                FinishedAt = new DateTime(2020, 04, 01, 16, 0, 0),
                Comments = "Comment test"
            };

            var appointmentCreated = _service.Create(appointment);

            Assert.NotEqual(0, appointmentCreated.Id);
            Assert.Equal(appointment.PatientId, appointmentCreated.PatientId);
            Assert.Equal(appointment.StartedAt, appointmentCreated.StartedAt);
            Assert.Equal(appointment.FinishedAt, appointmentCreated.FinishedAt);
            Assert.Equal(appointment.Comments, appointmentCreated.Comments);
        }
    }
}
