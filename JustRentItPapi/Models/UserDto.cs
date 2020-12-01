using System;
using System.Collections.Generic;

namespace JustRentItPapi.Models
{
    public partial class UserDto
    {
        public string Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int NumberOfCars { 
            get
            {
                return Cars.Count;
            } }
        public ICollection<CarDto> Cars { get; set; }
        = new List<CarDto>();
    }
}
