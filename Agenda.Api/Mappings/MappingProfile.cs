using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Models;
using AutoMapper;

namespace Agenda.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateAppointmentsMap();
            CreatePatientsMap();
        }

        private void CreateAppointmentsMap()
        {
            CreateMap<Appointment, AppointmentDto>()
            .ReverseMap()
            .ForMember(dest => dest.Patient, src => src.Ignore())
            .ForMember(dest => dest.Id, src=> src.Ignore());
        }

        private void CreatePatientsMap()
        {
            CreateMap<Patient, PatientDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, src => src.Ignore());
        }
    }
}