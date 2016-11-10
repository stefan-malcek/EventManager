using AutoMapper;
using EventManager.BL.DTOs;
using EventManager.DAL.Entities;

namespace EventManager.BL.Bootstrap
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Address, AddressDTO>().ReverseMap();

                config.CreateMap<User, UserDTO>().ReverseMap();
            });
        }
    }
}
