using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustRentItPapi.Entities;
using JustRentItPapi.Services;
using AutoMapper;
using JustRentItPapi.Models;

namespace JustRentItPapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ICarRentRepository _carRentRepository;
        private readonly IMapper _mapper;

        public UserController(ICarRentRepository carRentRepository,  IMapper mapper)
        {
            _carRentRepository = carRentRepository;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var userEntities =await _carRentRepository.GetUsers();
            var results = _mapper.Map<IEnumerable<UserWithoutCarDto>>(userEntities);

            return Ok(results);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(string id)
        {
            var userEntities =await _carRentRepository.GetUsers(id);
            var results = _mapper.Map<IEnumerable<UserWithoutCarDto>>(userEntities);

            return Ok(results);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(string id, User users)
        {
            if (id != users.Userid)
            {
                return BadRequest();
            }


            var result = await _carRentRepository.PutUsers(id, users);

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers(User users)
        {
            await _carRentRepository.PostUsers(users);

            return CreatedAtAction("GetUsers", new { id = users.Userid }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUsers(string id)
        {
            var users = await _carRentRepository.DeleteUsers(id);
            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        private bool UsersExists(string id)
        {
            return _carRentRepository.UsersExists(id);
        }
    }
}
