using App.API.Abstract;
using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUpsController : ControllerBase
    {
        private readonly IService<ImageUp> _service;
        private readonly IFileService _fileService;

        public ImageUpsController(IService<ImageUp> service, IFileService fileService)
        {
            _service = service;
            _fileService = fileService;
        }

        // GET: api/<ImageUpsController>
        [HttpGet]
        public async Task<IEnumerable<ImageUp>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<ImageUpsController>/5
        [HttpGet("{id}")]
        public async Task<ImageUp> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<ImageUpsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ImageUp value)
        {
            if (value.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(value.ImageFile);
                if (fileResult.Item1 ==1)
                {
                    value.EntityImage = fileResult.Item2;
                }

                _service.Add(value);
               var response =  await _service.SaveAsync();

                if (response>0)
                {
                    return Ok();
                }
                
            }

            return Problem();
        }

        // PUT api/<ImageUpsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImageUpsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
