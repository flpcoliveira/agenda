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

namespace Agenda.Api.Domain.Services
{
    public class PatientService : IPatientService
    {
        private IMapper _mapper;
        private IPatientRepository _repository;

        public PatientService(IMapper mapper, IPatientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public PatientDto Create(PatientDto data)
        {
            var entity = _mapper.Map<PatientDto, Patient>(data);
            entity = _repository.Create(entity);
            _repository.SaveChanges();
            return _mapper.Map<Patient, PatientDto>(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<PatientDto> GetAll()
        {
            var entities = _repository.GetAll();
            List<PatientDto> items = new List<PatientDto>();
            foreach (var entity in entities)
            {
                var item = _mapper.Map<Patient, PatientDto>(entity);
                items.Add(item);
            }

            return items;
        }

        public PatientDto GetById(int id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<Patient, PatientDto>(entity);
        }

        public PatientDto Update(int id, PatientDto data)
        {
            var entity = _mapper.Map<PatientDto, Patient>(data);
            entity.Id = id;
            entity = _repository.Update(entity);
            return _mapper.Map<Patient, PatientDto>(entity);
        }
    }
}
