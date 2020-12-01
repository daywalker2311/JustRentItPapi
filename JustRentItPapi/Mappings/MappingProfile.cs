using AutoMapper;
using JustRentItPapi.Entities;
using JustRentItPapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustRentItPapi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserWithoutCarDto>();
            CreateMap<Car, CarDto>();
            CreateMap<Rents, RentsDto>();
        }
    }
}
