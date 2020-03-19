using Agenda.Api.Domain.Interfaces;
using Agenda.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Infrastructure.Interfaces;
using Agenda.Api.Exceptions;

namespace Agenda.Api.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private IMapper _mapper;
        private IAppointmentRepository _repository;

        public AppointmentService(IMapper mapper, IAppointmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public AppointmentDto Create(AppointmentDto data)
        {
            var entity = _mapper.Map<AppointmentDto, Appointment>(data);

            ValidateAppointmentInterval(entity.StartedAt, entity.FinishedAt);

            entity = _repository.Create(entity);
            _repository.SaveChanges();

            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public async Task<List<AppointmentDto>> GetAll()
        {
            var entities = await _repository.GetAll();
            List<AppointmentDto> items = new List<AppointmentDto>();
            foreach (var entity in entities)
            {
                var item = _mapper.Map<Appointment, AppointmentDto>(entity);
                items.Add(item);
            }

            return items;
        }

        public AppointmentDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }

        public AppointmentDto Update(int id, AppointmentDto data)
        {
            var entity = this._repository.GetById(id);
            _mapper.Map<AppointmentDto, Appointment>(data, entity);

            ValidateAppointmentInterval(entity.StartedAt, entity.FinishedAt, id);

             entity = _repository.Update(entity);
            _repository.SaveChanges();

            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }

        private void ValidateAppointmentInterval(DateTime initialDate, DateTime finalDate, int? id = null)
        {
            if(initialDate >= finalDate)
                throw new DomainException("Appointment start must be before finish");

            var appointments = _repository
                    .AppointmentsBetween(initialDate, finalDate);

            if (id.HasValue)            
                appointments = appointments.Where(a => a.Id != id);            

            if (appointments.Count() > 0)
                throw new DomainException("Exists another appointment at selected interval");
        }
    }   
}
