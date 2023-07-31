using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCommentsController : ControllerBase
    {
        private readonly IService<PostComment> _service;

        public PostCommentsController(IService<PostComment> service)
        {
            _service = service;
        }

        // GET: api/<PostCommentsController>
        [HttpGet]
        public async Task<IEnumerable<PostComment>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<PostCommentsController>/5
        [HttpGet("{id}")]
        public async Task<PostComment> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<PostCommentsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostComment value)
        {
            await _service.AddAsync(value);
            await _service.SaveAsync();
            return Ok(value);
        }

        // PUT api/<PostCommentsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostComment value)
        {
            var postComment = await _service.FindAsync(id);

            if (postComment != null)
            {
                postComment = value;
                _service.Update(postComment);
                await _service.SaveAsync();
                return Ok(postComment);
            }
            return NotFound();
        }

        // DELETE api/<PostCommentsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var postComment = await _service.FindAsync(id);
            if (postComment != null)
            {
                _service.Delete(postComment);
                _service.SaveAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
