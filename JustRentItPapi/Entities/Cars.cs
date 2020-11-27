using System;
using System.Collections.Generic;

namespace JustRentItPapi.Entities
{
    public partial class Cars
    {
        public string Carid { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public DateTime Yearmade { get; set; }
    }
}
