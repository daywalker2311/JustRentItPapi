using System;
using System.Collections.Generic;

namespace JustRentItPapi.Models
{
    public partial class CarForCreationDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public string Yearmade { get; set; }
        public string FkUserid { get; set; }

        //public virtual User FkUser { get; set; }
    }
}
