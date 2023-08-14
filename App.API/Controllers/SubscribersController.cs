using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly IService<Subscriber> _service;

        public SubscribersController(IService<Subscriber> service)
        {
            _service = service;
        }

        // GET: api/<SubscribbersController>
        [HttpGet]
        public async Task<IEnumerable<Subscriber>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<SubscribbersController>/5
        [HttpGet("{id}")]
        public async Task<Subscriber> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<SubscribbersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Subscriber value)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(value);
                var response = await _service.SaveAsync();
                if (response > 0)
                {
                    return Ok();
                }
            }
            return Problem();
        }

        // PUT api/<SubscribbersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Subscriber value)
        {
            Subscriber mainModel = await _service.FindAsync(id);

            if (mainModel != null)
            {
                mainModel.Email = value.Email;
             

                _service.Update(mainModel);
                var response = await _service.SaveAsync();
                if (response > 0)
                {
                    return Ok();
                }

            }
            return Problem();
        }

        // DELETE api/<SubscribbersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Subscriber mainModel = await _service.FindAsync(id);

            if (mainModel != null)
            {
                _service.Delete(mainModel);
                var response = await _service.SaveAsync();
                if (response > 0)
                {
                    return Ok();
                }
            }
            return Problem();
        }
    }
}
