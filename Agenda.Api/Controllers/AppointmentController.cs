using System.Collections.Generic;
using System.Threading.Tasks;
using Agenda.Api.Domain.Interfaces;
using Agenda.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {

        private IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }


        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<AppointmentDto>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public AppointmentDto GetById(int id)
        {
            return _service.GetById(id);
        }

        [Route("")]
        [HttpPost]
        public AppointmentDto Create([FromBody]AppointmentDto data)
        {
            return _service.Create(data);
        }

        [Route("{id}")]
        [HttpPut]
        public AppointmentDto Update(int id, [FromBody]AppointmentDto data)
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