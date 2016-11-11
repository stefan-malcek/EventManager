using AutoMapper;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Registrations;
using EventManager.DAL.Entities;

namespace EventManager.BL.Bootstrap
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Address, AddressDTO>()
                     .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                     .ReverseMap();

                config.CreateMap<AddressDTO, Address>();

                config.CreateMap<User, UserDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                    .ReverseMap();

                config.CreateMap<Event, EventDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                    .ForMember(d => d.AddressId, opt => opt.MapFrom(s => s.Address.ID))
                    .ForMember(d => d.EventOrganizerId, opt => opt.MapFrom(s => s.EventOrganizer.ID))
                    .ReverseMap();   

                config.CreateMap<EventReview, EventReviewDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                    .ForMember(d => d.EventId, opt => opt.MapFrom(s => s.Event.ID));

                config.CreateMap<EventReviewCreateDTO, EventReview>();

                config.CreateMap<EventReviewUpdateDTO, EventReview>()
                    .ForMember(d => d.ID, opt => opt.MapFrom(s => s.Id));

                config.CreateMap<Registration, RegistrationDTO>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                   .ForMember(d => d.EventId, opt => opt.MapFrom(s => s.Event.ID))
                   .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.User.ID));

                config.CreateMap<RegistrationDTO, Registration>();

                config.CreateMap<RegistrationUpdateDTO, Registration>()
                    .ForMember(d => d.ID, opt => opt.MapFrom(s => s.Id));

            });
        }
    }
}
