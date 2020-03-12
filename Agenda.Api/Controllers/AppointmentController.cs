using System.Collections.Generic;
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
        public IEnumerable<AppointmentDto> GetAll()
        {
            return _service.GetAll();
        }

                [HttpGet("{id}")]
        public AppointmentDto GetById([FromQuery]int id)
        {
            return _service.GetById(id);
        }

        [Route("{id}")]
        [HttpPost]
        public AppointmentDto Create([FromBody]AppointmentDto data)
        {
            return _service.Create(data);
        }

        [Route("{id}")]
        [HttpPut]
        public AppointmentDto Update(int id, [FromBody]AppointmentDto data)
        {
            return _service.Update(data);
        }
    }
}