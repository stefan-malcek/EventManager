using System.Linq;
using AutoMapper;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.DTOs.Users;
using EventManager.DAL.Entities;

namespace EventManager.BL.Bootstrap
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                //address
                config.CreateMap<Address, AddressDTO>()
                     .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                     .ReverseMap();

                config.CreateMap<AddressCreateDTO, Address>();


                config.CreateMap<UserRegistrationDTO, UserAccount>();
                config.CreateMap<UserRegistrationDTO, User>();
                // config.CreateMap<UserCreateDTO, User>();

                config.CreateMap<User, UserDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                    .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Account.Email))
                    .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.Account.FirstName))
                    .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.Account.LastName))
                    .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Account.Birthday))
                     .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Account.ClaimCollection.FirstOrDefault().Value))
                    .ReverseMap();

                //config.CreateMap<User, UserDTO>()
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                //    .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Account.Email))
                //    .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.Account.FirstName))
                //    .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.Account.LastName))
                //    .ForMember(dest => dest.Birthday, opts => opts.MapFrom(src => src.Account.Birthday))
                //    .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Account.ClaimCollection.FirstOrDefault().Value));
                //config.CreateMap<UserDTO, User>()
                //.ForMember(d => d.ID, opt => opt.MapFrom(s => s.Id))
                //.for

                config.CreateMap<UserAccount, UserAccountDTO>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                .ReverseMap();

                config.CreateMap<UserRegistrationDTO, UserAccount>();

                //event
                config.CreateMap<Event, EventDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                    .ForMember(d => d.AddressId, opt => opt.MapFrom(s => s.Address.ID))
                    .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.EventOrganizer.User.ID))
                    //.ForMember(d => d.Date, opt => opt.MapFrom(s => s.Date + s.Start))
                    .ReverseMap();

                //event review
                config.CreateMap<EventReview, EventReviewDTO>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                    .ForMember(d => d.EventId, opt => opt.MapFrom(s => s.Event.ID));

                config.CreateMap<EventReviewCreateDTO, EventReview>();

                config.CreateMap<EventReviewUpdateDTO, EventReview>()
                    .ForMember(d => d.ID, opt => opt.MapFrom(s => s.Id));

                //registration
                config.CreateMap<Registration, RegistrationDTO>()
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ID))
                   .ForMember(d => d.EventId, opt => opt.MapFrom(s => s.Event.ID))
                   .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.User.ID));

                config.CreateMap<RegistrationCreateDTO, Registration>();

                config.CreateMap<RegistrationDTO, Registration>()
                .ForMember(d => d.ID, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.State));

            });
        }
    }
}
