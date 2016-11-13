using System;
using System.Linq;
using Castle.Windsor;
using EventManager.BL.Bootstrap;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Facades;
using EventManager.BL.Services.Addresses;
using EventManager.BL.Services.Events;
using EventManager.BL.Services.Registrations;
using EventManager.BL.Services.Reviews;
using EventManager.BL.Services.Users;
using EventManager.BL.TestData;
using EventManager.DAL.Enums;

namespace EventManager.BL.TestConsole
{
    public class Program
    {
        private static IAddressService _addressService;
        private static IUserService _userService;
        private static IEventService _eventService;
        private static IReviewService _reviewService;
        private static IRegistrationService _registrationService;
        private static EventFacade _eventFacade;

        private static IWindsorContainer _container;


        static void Main(string[] args)
        {
            _container = new WindsorContainer();
            _container.Install(new BussinessLayerInstaller());
            AutoMapperConfig.Initialize();

            TestAddressService();
            TestUserService();
            TestEventService();
            TestReviewService();
            TestRegistrationService();
            TestEventDetail();

            Console.ReadKey();
        }

        private static void TestAddressService()
        {
            _addressService = _container.Resolve<IAddressService>();

            Console.WriteLine("AddressService");

            //create
            Console.Write("Create - ");
            _addressService.CreateAddress(Factory.GetAddress1());

            //get
            var address = _addressService.GetAddress(1);
            Console.WriteLine(address != null);

            //update
            Console.Write("Update - ");
            //arrange
            string newCity = "Ostrava";
            address.City = newCity;
            //act
            _addressService.UpdateAddress(address);
            //assert
            address = _addressService.GetAddress(1);
            Console.WriteLine(Equals(newCity, address.City));

            //list
            Console.Write("Listing - ");
            //arrange
            _addressService.CreateAddress(Factory.GetAddress2());
            _addressService.CreateAddress(Factory.GetAddress3());
            //act
            var addresses = _addressService.ListAddresses(new AddressFilter());
            //assert
            Console.WriteLine(addresses.Count() == 3);

            Console.Write("Listing with filter - ");
            //act
            addresses = _addressService.ListAddresses(new AddressFilter { City = newCity });
            //assert
            Console.WriteLine(addresses.Count() == 1);

            //delete
            Console.Write("Delete - ");
            //act
            _addressService.DeleteAddress(1);
            //assert
            address = _addressService.GetAddress(1);
            Console.WriteLine(address == null);
        }

        private static void TestUserService()
        {
            _userService = _container.Resolve<IUserService>();

            Console.WriteLine("\nUserService");

            //create
            Console.Write("Create - ");
            _userService.CreateUser(Factory.GetMember1());

            //get
            var user = _userService.GetUser(1);
            Console.WriteLine(user != null);

            //update
            Console.Write("Update - ");
            //arrange
            user.Role = UserRole.Administrator;
            //act
            _userService.UpdateUser(user);
            //assert
            user = _userService.GetUser(1);
            Console.WriteLine(UserRole.Administrator == user.Role);

            //list
            Console.Write("Listing - ");
            //arrange
            _userService.CreateUser(Factory.GetOrganizer());
            //act
            var users = _userService.ListUsers(new UserFilter());
            //assert
            Console.WriteLine(users.Count() == 2);

            Console.Write("Listing with filter - ");
            //act
            users = _userService.ListUsers(new UserFilter { Role = UserRole.Member });
            //assert
            Console.WriteLine(!users.Any());

            //delete
            Console.Write("Delete - ");
            //act
            _userService.DeleteUser(user.Id);
            //assert
            user = _userService.GetUser(user.Id);
            Console.WriteLine(user == null);
        }

        public static void TestEventService()
        {
            Console.WriteLine("\nEventService");
            _eventService = _container.Resolve<IEventService>();

            //create
            Console.Write("Create - ");
            _eventService.CreateEvent(Factory.GetEvent1());

            //get
            var @event = _eventService.GetEvent(1);
            Console.WriteLine(@event != null);

            //update
            Console.Write("Update - ");
            //arrange
            var newDate = new DateTime(2016, 12, 15);
            @event.Date = newDate;
            var newLecturer = "Jirka Maly";
            @event.Lecturer = newLecturer;
            @event.AddressId = 3;
            //act
            _eventService.UpdateEvent(@event);
            //assert
            @event = _eventService.GetEvent(1);
            Console.WriteLine(Equals(@event.Date, newDate) && Equals(@event.Lecturer, newLecturer) && @event.AddressId == 3);

            //list
            Console.Write("Listing - ");
            //arrange
            _eventService.CreateEvent(Factory.GetEvent2());
            _eventService.CreateEvent(Factory.GetEvent3());
            //act
            var events = _eventService.ListEvents(new EventFilter());
            //assert
            Console.WriteLine(events.TotalResultCount == 3);

            Console.Write("Listing with filter - ");
            //act
            events = _eventService.ListEvents(new EventFilter { MaximumFee = 30 });
            //assert
            Console.WriteLine(events.TotalResultCount == 3);

            //delete
            Console.Write("Delete - ");
            //act
            _eventService.DeleteEvent(1);
            //assert
            @event = _eventService.GetEvent(1);
            Console.WriteLine(@event == null);
        }


        private static void TestReviewService()
        {
            Console.WriteLine("\nReviewService");
            _reviewService = _container.Resolve<IReviewService>();

            //create
            Console.Write("Create - ");
            _reviewService.AddReview(Factory.GetReview1());
            _reviewService.AddReview(Factory.GetReview2());
            _reviewService.AddReview(Factory.GetReview3());
            _reviewService.AddReview(Factory.GetReview4());
            _reviewService.AddReview(Factory.GetReview5());

            Console.Write("Listing with filter - ");
            //act
            var reviews = _reviewService.ListReviewsForEvent(2);
            //assert
            Console.WriteLine(reviews.Count() == 5);
        }

        private static void TestRegistrationService()
        {
            Console.WriteLine("\nRegistrationService");
            _registrationService = _container.Resolve<IRegistrationService>();

            //create valid
            _userService.CreateUser(Factory.GetMember2());
            _registrationService.Register(Factory.GetValidRegistration());

            var registration = _registrationService.GetRegistration(1);

            try
            {
                //user can not have two registrations for same event
                _registrationService.Register(Factory.GetValidRegistration());
            }
            catch (InvalidOperationException ex) { }

            _registrationService.Unregister(1);

            try
            {
                //event is closed
                //_addressService.CreateAddress(Factory.GetAddress3());
                _registrationService.Register(Factory.GetOldRegistration());
            }
            catch (InvalidOperationException ex) { }

            //false
            var isEventClosed = _registrationService.AreRegistrationsAllowed(3);
        }

        private static void TestEventDetail()
        {
            _eventFacade = _container.Resolve<EventFacade>();
            var eventDetail = _eventFacade.GetEventDetail(2);
        }
    }
}
