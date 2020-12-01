using JustRentItPapi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustRentItPapi.Services
{
    public class CarRentRepository : ICarRentRepository
    {
        private readonly projectContext _context;

        public CarRentRepository(projectContext context)
        {
            _context = context;
        }

        //for UserController
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = _context.Users.OrderBy(c => c.Username);
            return await result.ToListAsync();
        }
        public async Task<User> GetUsers(string id)
        {
            //if (includeCars)
            //{
                //var result = _context.Users.Include(c => c.Cars)
                //    .Where(c => c.Userid == id);
            //}
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return null;
            }
            return users;
        }
        public async Task<User> PostUsers(User users)
        {
            _context.Users.Add(users);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersExists(users.Userid))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return users;
        }
        public bool UsersExists(string id)
        {
            return _context.Users.Any(e => e.Userid == id);
        }
        public async Task<IActionResult> PutUsers(string id, User users)
        {

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }
        public async Task<User> DeleteUsers(string id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return null;
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return users;
        }

        //for CarController
        public async Task<Car> GetCars(string id)
        {
            var cars = await _context.Cars.FindAsync(id);

            if (cars == null)
            {
                return null;
            }

            return cars;
        }
        public async Task<IEnumerable<Car>> GetCars()
        {
            var result = _context.Cars.OrderBy(c => c.Brand);
            return await result.ToListAsync();
        }
        public async Task<Car> PostCars(Car cars)
        {
            _context.Cars.Add(cars);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarsExists(cars.Carid))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return cars;
        }
        public async Task<IActionResult> PutCars(string id, Car cars)
        {
            _context.Entry(cars).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarsExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return null;
        }
        public async Task<Car> DeleteCars(string id)
        {
            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return null;
            }

            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();

            return cars;
        }
        public bool CarsExists(string id)
        {
            return _context.Cars.Any(e => e.Carid == id);
        }

        //for RentController
        public async Task<ActionResult<IEnumerable<Rents>>> GetRents()
        {
            return await _context.Rents.ToListAsync();
        }
        public async Task<ActionResult<Rents>> GetRents(string id)
        {
            return await _context.Rents.FindAsync(id);
        }
        public async Task<Rents> PutRents(string id, Rents rents)
        {
            _context.Entry(rents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentsExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return rents;
        }
        public async Task<ActionResult<Rents>> PostRents(Rents rents)
        {
            _context.Rents.Add(rents);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RentsExists(rents.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return rents;
        }
        public async Task<ActionResult<Rents>> DeleteRents(string id)
        {
            var rents = await _context.Rents.FindAsync(id);
            if (rents == null)
            {
                return null;
            }

            _context.Rents.Remove(rents);
            await _context.SaveChangesAsync();

            return rents;
        }
        public bool RentsExists(string id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
    }
}
