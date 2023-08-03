using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IService<Image> _service;

        public ImagesController(IService<Image> service)
        {
            _service = service;
        }

        // GET: api/<ImagesController>
        [HttpGet]
        public async Task<IEnumerable<Image>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<ImagesController>/5
        [HttpGet("{id}")]
        public async Task<Image> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<ImagesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Image value)
        {
            await _service.AddAsync(value);
            var response = await _service.SaveAsync();

            if (response > 0)
            {
                return Ok();

            }
            return Problem();
        }

        // PUT api/<ImagesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Image value)
        {
            Image mainModel = await _service.FindAsync(id);

            if (mainModel != null)
            {
                mainModel.ImageTitle = value.ImageTitle;
                mainModel.ImagePath = value.ImagePath;

                _service.Update(mainModel);

                var response = await _service.SaveAsync();

                if (response>0)
                {
                    return Ok();
                }
                return Problem();
            }

            return NotFound();
        }

        // DELETE api/<ImagesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Image model = await _service.FindAsync(id);
            if (model != null)
            {
                _service.Delete(model);
                var response = await _service.SaveAsync();
                if (response>0)
                {
                    return Ok();
                }
                return Problem();
            }
            return NotFound();
        }
    }
}
