using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribbersController : ControllerBase
    {
        private readonly IService<Subscribber> _service;

        public SubscribbersController(IService<Subscribber> service)
        {
            _service = service;
        }

        // GET: api/<SubscribbersController>
        [HttpGet]
        public async Task<IEnumerable<Subscribber>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<SubscribbersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubscribbersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubscribbersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubscribbersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
