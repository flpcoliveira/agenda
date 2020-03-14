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
        }

        private void CreateAppointmentsMap()
        {
            CreateMap<Appointment, AppointmentDto>()            
            .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Patient.Id))
            .ReverseMap()
            .ForPath(dest => dest.Patient.Id, opt => opt.MapFrom(src => src.PatientId))
            .ForPath(dest => dest.Patient.Name, opt => opt.MapFrom(src => src.PatientName))
            .ForPath(dest => dest.Patient.BirthDate, opt => opt.MapFrom(src => src.PatientBirthDate));
        }

    }
}