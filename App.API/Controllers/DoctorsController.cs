using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsService _service;

        public DoctorsController(IDoctorsService service)
        {
            _service = service;
        }



        // GET: api/<DoctorsController>
        [HttpGet]
        public async Task<IEnumerable<Doctors>> Get()
        {
            return await _service.GetAllDoctorsByIncludeAsync();
        }

        // GET api/<DoctorsController>/5
        [HttpGet("{id}")]
        public async Task<Doctors> Get(int id)
        {
            return await _service.GetDoctorByIncludeAsync(id);
        }

        // POST api/<DoctorsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Doctors value)
        {
            await _service.AddAsync(value);
            await _service.SaveAsync();
            return Ok(value);
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Doctors value)
        {
            var doctor = await _service.GetDoctorByIncludeAsync(id);

            if (doctor != null)
            {
                doctor = value;
                _service.Update(doctor);
                await _service.SaveAsync();
                return Ok(doctor);

            }

            return NotFound();
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var doctor = await _service.GetDoctorByIncludeAsync(id);

            if (doctor != null)
            {
                _service.Delete(doctor);
                _service.SaveAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
