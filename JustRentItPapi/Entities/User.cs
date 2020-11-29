using System;
using System.Collections.Generic;

namespace JustRentItPapi.Entities
{
    public partial class User
    {
        public User()
        {
            Cars = new HashSet<Car>();
        }

        public string Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
