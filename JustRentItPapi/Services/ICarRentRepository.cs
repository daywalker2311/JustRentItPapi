using JustRentItPapi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustRentItPapi.Services
{
    public interface ICarRentRepository
    {
        //for UserController
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUsers(string id);
        bool UsersExists(string id);
        Task<User> DeleteUsers(string id);
        Task<User> PostUsers(User users);
        Task<IActionResult> PutUsers(string id, User users);


        //for CarController
        Task<IEnumerable<Car>> GetCars();
        Task<Car> GetCars(string id);
        Task<IActionResult> PutCars(string id, Car cars);
        Task<Car> PostCars(Car cars);
        Task<Car> DeleteCars(string id);
        bool CarsExists(string id);

        //for RentController
        Task<ActionResult<IEnumerable<Rents>>> GetRents();
        Task<ActionResult<Rents>> GetRents(string id);
        Task<Rents> PutRents(string id, Rents rents);
        Task<ActionResult<Rents>> PostRents(Rents rents);
        Task<ActionResult<Rents>> DeleteRents(string id);
        bool RentsExists(string id);

    }
}
