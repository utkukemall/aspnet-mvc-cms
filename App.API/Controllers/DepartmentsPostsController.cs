using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsPostsController : ControllerBase
    {
        private readonly IService<DepartmentPost> _service;

        public DepartmentsPostsController(IService<DepartmentPost> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DepartmentsPostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentsPostsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentsPostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsPostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
