using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustRentItPapi.Entities;
using AutoMapper;
using JustRentItPapi.Services;
using JustRentItPapi.Models;

namespace JustRentItPapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private ICarRentRepository _carRentRepository;
        private readonly IMapper _mapper;
        public CarController(ICarRentRepository carRentRepository, IMapper mapper)
        {
            _carRentRepository = carRentRepository;
            _mapper = mapper;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var carEntities = await _carRentRepository.GetCars();
            var results = _mapper.Map<IEnumerable<CarDto>>(carEntities);

            return Ok(results);
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCars(string id)
        {
            var result = await _carRentRepository.GetCars(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCars(string id, Car cars)
        {
            if (id != cars.Carid)
            {
                return BadRequest();
            }

            var result = await _carRentRepository.PutCars(id, cars);

            return NoContent();
        }

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCars(Car cars)
        {
            await _carRentRepository.PostCars(cars);

            return CreatedAtAction("GetCars", new { id = cars.Carid }, cars);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCars(string id)
        {
            var cars = await _carRentRepository.DeleteCars(id);
            if (cars == null)
            {
                return NotFound();
            }

            return cars;
        }

        private bool CarsExists(string id)
        {
            return _carRentRepository.CarsExists(id);
        }
    }
}
