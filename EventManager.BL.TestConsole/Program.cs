using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using EventManager.BL.Bootstrap;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Services.Addresses;

namespace EventManager.BL.TestConsole
{
    public class Program
    {
        private static IAddressService _addressService;

        private static IWindsorContainer _container;

        static void Main(string[] args)
        {
            _container = new WindsorContainer();
            _container.Install(new BussinessLayerInstaller());
            AutoMapperConfig.Initialize();

            TestAddressService();

            Console.ReadKey();
        }

        private static void TestAddressService()
        {
            _addressService = _container.Resolve<IAddressService>();

            Console.WriteLine("AddressService");

            //create
            Console.WriteLine("\nCreate");
            _addressService.CreateAddress(new AddressCreateDTO
            {
                Building = "TestBuilding",
                Street = "TestStreet",
                StreetNumber = "1",
                City = "TestCity"
            });

            //get
            var address = _addressService.GetAddress(1);
            Console.WriteLine(address);

            //update
            
            string newCity = "Ostrava";
            address.City = newCity;
            _addressService.UpdateAddress(address);
            _addressService.GetAddress(1);
            Console.WriteLine(address);

            //list
            Console.WriteLine("\nListing");
            var addresses = _addressService.ListAddresses(new AddressFilter { City = newCity });
            Console.WriteLine(addresses.Count() == 1 ? "Is working" : "Is not working");

            //delete
            Console.WriteLine("\nDelete");
            _addressService.DeleteAddress(address.Id);
        }
    }
}
