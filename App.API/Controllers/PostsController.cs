using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IService<Post> _service;

        public PostsController(IService<Post> service)
        {
            _service = service;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public async Task<IEnumerable<Post>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public async Task<Post> GetAsync(int id)
        {
            Post model = await _service.FindAsync(id);

            return model;
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Post value)
        {
            await _service.AddAsync(value);
            var response = await _service.SaveAsync();
            if (response > 0)
            {
                return Ok();

            }
            return Problem();
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] string value)
        {
            Post mainModel = await _service.FindAsync(id);



            return Ok();
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
