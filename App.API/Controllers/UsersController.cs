﻿using App.Data.Entity;
using App.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _service;

        public UsersController(IService<User> service)
        {
            _service = service;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _service.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _service.FindAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] User value)
        {
            await _service.AddAsync(value);

            await _service.SaveAsync();
            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] User value)
        {
              User mainUser =   await _service.FindAsync(id);
            if (mainUser!=null)
            {
                mainUser = value;

                _service.Update(mainUser);
                await _service.SaveAsync();
                return Ok();
            }

            return Problem();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            User mainUser = await _service.FindAsync(id);

            if (mainUser is not null)
            {
                _service.Delete(mainUser);
                await _service.SaveAsync();
            }
            return BadRequest();
        }
    }
}