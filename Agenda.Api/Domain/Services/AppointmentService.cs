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
            entity = _repository.Create(entity);
            _repository.SaveChanges();
            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public IEnumerable<AppointmentDto> GetAll()
        {
            var entities = _repository.GetAll();
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
            var entity = _mapper.Map<AppointmentDto, Appointment>(data);
            entity.Id = id;
            if (_repository.ExistsAppointmentBetween(entity.StartedAt, entity.FinishedAt))
                throw new DomainException("Exists another appointment at the selected interval");
            entity = _repository.Update(entity);
            _repository.SaveChanges();
            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }
    }
}
