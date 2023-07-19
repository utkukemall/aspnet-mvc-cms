using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace App.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentsController : ControllerBase
	{
		private readonly IService<Department> _service;

		public DepartmentsController(IService<Department> departmentContext)
		{
			_service = departmentContext;
		}

		// GET: api/<DepartmentsController>
		[HttpGet]
		public async Task<IEnumerable<Department>> Get()
		{
			return await _service.GetAllAsync();
		}

		// GET api/<DepartmentsController>/5
		[HttpGet("{id}")]
		public async Task<Department> Get(int id)
		{
			return await _service.FindAsync(id);
		}

		// POST api/<DepartmentsController>
		[HttpPost]
		public async Task<int> Post([FromBody] Department value)
		{
			await _service.AddAsync(value);

			return await _service.SaveAsync();
		}

		// PUT api/<DepartmentsController>/5
		[HttpPut("{id}")]
		public async Task<int> Put(int id, [FromBody] Department value)
		{
			Department mainDepartment = await _service.FindAsync(id);

			if(mainDepartment != null)
			{
				mainDepartment = value;

				_service.Update(mainDepartment);

				return await _service.SaveAsync();
			}

			return 304;
		}

		// DELETE api/<DepartmentsController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteAsync(int id)
		{
			Department mainDepartment = await _service.FindAsync(id);

			if (mainDepartment != null)
			{
				_service.Delete(mainDepartment);

				return await _service.SaveAsync();
			}

			return NotFound();
		}
	}
}
