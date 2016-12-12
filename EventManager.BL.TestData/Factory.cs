using System;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.DTOs.UserAccounts;
using EventManager.BL.DTOs.Users;
using EventManager.DAL.Enums;

namespace EventManager.BL.TestData
{
    public static class Factory
    {
        public static AddressCreateDTO GetAddress1()
        {
            return new AddressCreateDTO
            {
                Building = "Školící místnost společnosti Edhouse s.r.o. (Vědeckotechnický park ICT, budova A, 3. Patro)",
                Street = "Nad Stráněmi",
                StreetNumber = "5656",
                City = "Zlín"
            };
        }

        public static AddressCreateDTO GetAddress2()
        {
            return new AddressCreateDTO
            {
                Building = "Technologické centrum Hradec Králové",
                Street = "Piletická",
                StreetNumber = "486 / 19",
                City = "Hradec Králové"
            };
        }

        public static AddressCreateDTO GetAddress3()
        {
            return new AddressCreateDTO
            {
                Building = "Budova Gotex",
                Street = "Botanicka",
                StreetNumber = "12",
                City = "Brno"
            };
        }

        public static UserRegistrationDTO GetMember()
        {
           return new UserRegistrationDTO
           {
               FirstName = "Jan",
               LastName = "Maly",
               Email = "janmaly@seznam.cz",
               Birthday = new DateTime(1990,2,3),
               Password = "123456"
           };
        }

        public static EventDTO GetEvent1()
        {
            return new EventDTO
            {
                AddressId = 2,
                Title = "Entity Framework basics",
                Description = "Just basic stuff.",
                Lecturer = "Pavel Novák",
                Date = new DateTime(2016, 12, 1),
                Start = new TimeSpan(14, 0, 0),
                End = new TimeSpan(16, 0, 0),
                UserId = 2
            };
        }

        public static EventDTO GetEvent2()
        {
            return new EventDTO
            {
                AddressId = 2,
                Title = "Entity Framework advanced",
                Description = "Some cool definition of advanced topics in Entity framework.",
                Lecturer = "Jan Adamec",
                Date = new DateTime(2016, 12, 1),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                UserId = 2,
                Capacity = 100,
                Fee = 20
            };
        }

        public static EventDTO GetEvent3()
        {
            return new EventDTO
            {
                AddressId = 2,
                Title = "Windows 10",
                Description = "Basic work with operation system Windows 10.",
                Lecturer = "Eugen Novotny",
                Date = new DateTime(2017, 2, 1),
                Start = new TimeSpan(16, 30, 0),
                End = new TimeSpan(19, 0, 0),
                UserId = 2
            };
        }

        public static EventReviewCreateDTO GetReview1()
        {
            return new EventReviewCreateDTO
            {
                EventId = 6,
                Rating = 5,
                Author = "User1",
                Review = "Very good examples."
            };
        }

        public static EventReviewCreateDTO GetReview2()
        {
            return new EventReviewCreateDTO
            {
                EventId = 6,
                Rating = 5,
                Author = "User2",
                Review = "Very good examples."
            };
        }

        public static EventReviewCreateDTO GetReview3()
        {
            return new EventReviewCreateDTO
            {
                EventId = 6,
                Rating = 5,
                Author = "User3",
                Review = "Very good examples."
            };
        }

        public static EventReviewCreateDTO GetReview4()
        {
            return new EventReviewCreateDTO
            {
                EventId = 6,
                Rating = 5,
                Author = "User4",
                Review = "Very good examples."
            };
        }

        public static EventReviewCreateDTO GetReview5()
        {
            return new EventReviewCreateDTO
            {
                EventId = 6,
                Rating = 1,
                Author = "User5",
                Review = "Very bad examples."
            };
        }

        public static RegistrationCreateDTO GetValidRegistration()
        {
            return new RegistrationCreateDTO
            {
                EventId = 9,
                UserId = 4
            };
        }

        public static RegistrationCreateDTO GetOldRegistration()
        {
            return new RegistrationCreateDTO
            {
                EventId = 6,
                UserId = 4
            };
        }
    }
}
