using System;
using System.Collections.Generic;

namespace JustRentItPapi.Entities
{
    public partial class Users
    {
        public string Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? Joiningdate { get; set; }
    }
}
