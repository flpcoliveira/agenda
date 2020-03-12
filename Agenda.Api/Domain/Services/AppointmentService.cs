﻿using Agenda.Api.Domain.Interfaces;
using Agenda.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Agenda.Api.Infrastructure.Entities;
using Agenda.Api.Infrastructure.Interfaces;

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
            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<AppointmentDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public AppointmentDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }

        public AppointmentDto Update(AppointmentDto data)
        {
            var entity = _mapper.Map<AppointmentDto, Appointment>(data);
            entity = _repository.Update(entity);
            return _mapper.Map<Appointment, AppointmentDto>(entity);
        }
    }
}
