using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.Api.Domain.Interfaces;
using Agenda.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {

        private IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpGet]
        public async Task<List<PatientDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public PatientDto GetById(int id)
        {
            return _service.GetById(id);
        }

        [Route("")]
        [HttpPost]
        public PatientDto Create([FromBody]PatientDto data)
        {
            return _service.Create(data);
        }

        [Route("{id}")]
        [HttpPut]
        public PatientDto Update(int id, [FromBody]PatientDto data)
        {
            return _service.Update(id, data);
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}