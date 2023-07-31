using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostImagesController : ControllerBase
    {
        private readonly IService<PostImage> _service;

        public PostImagesController(IService<PostImage> service)
        {
            _service = service;
        }

        // GET: api/<PostImagesController>
        [HttpGet]
        public async Task<IEnumerable<PostImage>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<PostImagesController>/5
        [HttpGet("{id}")]
        public async Task<PostImage> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<PostImagesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostImage value)
        {
            await _service.AddAsync(value);
            await _service.SaveAsync();
            return Ok(value);
        }

        // PUT api/<PostImagesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PostImage value)
        {
            var postImage = await _service.FindAsync(id);

            if (postImage != null)
            {
                postImage = value;
                _service.Update(postImage);
                await _service.SaveAsync();
                return Ok(postImage);
            }
            return NotFound();
        }

        // DELETE api/<PostImagesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var postImage = await _service.FindAsync(id);
            if (postImage != null)
            {
                _service.Delete(postImage);
                _service.SaveAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
