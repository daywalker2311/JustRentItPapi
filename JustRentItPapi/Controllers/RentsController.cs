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

namespace JustRentItPapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private ICarRentRepository _carRentRepository;
        private readonly IMapper _mapper;

        public RentsController(ICarRentRepository carRentRepository, IMapper mapper)
        {
            _carRentRepository = carRentRepository;
            _mapper = mapper;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rents>>> GetRents()
        {
            return await _carRentRepository.GetRents();
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rents>> GetRents(string id)
        {
            var rents = await _carRentRepository.GetRents(id);

            if (rents == null)
            {
                return NotFound();
            }

            return rents;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRents(string id, Rents rents)
        {
            if (id != rents.Id)
            {
                return BadRequest();
            }

            var rentEntity = await _carRentRepository.PutRents(id, rents);

            if (rentEntity == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // POST: api/Rents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rents>> PostRents(Rents rents)
        {
            var rentEntities = await _carRentRepository.PostRents(rents);

            if (rentEntities == null)
            {
                return Conflict();
            }

            return CreatedAtAction("GetRents", new { id = rents.Id }, rents);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rents>> DeleteRents(string id)
        {
            var rents = await _carRentRepository.DeleteRents(id);
            if (rents == null)
            {
                return NotFound();
            }

            return rents;
        }

        private bool RentsExists(string id)
        {
            return _carRentRepository.RentsExists(id);        }
    }
}
