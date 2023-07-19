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
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PostsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<PostsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PostsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
