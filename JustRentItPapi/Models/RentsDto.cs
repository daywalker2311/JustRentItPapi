using System;
using System.Collections.Generic;

namespace JustRentItPapi.Models
{
    public partial class RentsDto
    {
        public string Id { get; set; }
        public string Rentperiod { get; set; }
        public int? Price { get; set; }
        public string Confirmation { get; set; }
    }
}
