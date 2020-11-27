using System;
using System.Collections.Generic;

namespace JustRentItPapi.Entities
{
    public partial class Rents
    {
        public string Id { get; set; }
        public string Rentperiod { get; set; }
        public int? Price { get; set; }
        public string Confirmation { get; set; }
    }
}
