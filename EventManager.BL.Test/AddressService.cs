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
using EventManager.DAL;
using EventManager.DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventManager.BL.Test
{
    [TestClass]
    public class AddressService
    {
        private readonly string _oldCity = "TestCity";
        private readonly string _newCity = "Ostrava";
        private IWindsorContainer _container;
        private IAddressService _addressService;
        private EventManagerDbContext _dbContext;

        [TestInitialize]
        public void SetUp()
        {
            _container = new WindsorContainer();
            _container.Install(new BussinessLayerInstaller());
            AutoMapperConfig.Initialize();

            _addressService = _container.Resolve<IAddressService>();
            _dbContext = new EventManagerDbContext();
        }

        [TestCleanup]
        public void Clean()
        {
            foreach (var address in _dbContext.Addresses)
            {
                _dbContext.Addresses.Remove(address);
            }

            _dbContext.Dispose();
        }

        [TestMethod]
        public void CreateAddress_ValidAddress_CorrectResult()
        {
            var addressCreateDto = new AddressCreateDTO
            {
                Building = "TestBuilding",
                Street = "TestStreet",
                StreetNumber = "1",
                City = _oldCity
            };


            _addressService.CreateAddress(addressCreateDto);



            //Assert.AreEqual(, addresses.Count(), "Count should be 1.");
        }

        [TestMethod]
        public void UpdateAddress_ValidAddress_CorrectResult()
        {
            InsertTestAddress();
            var address = GetFirstAddress();
            address.City = _newCity;

            _addressService.UpdateAddress(address);
            address = GetFirstAddress();

            Assert.AreEqual(_newCity, address.City, "City is different.");
        }

        [TestMethod]
        public void DeleteAddess_ValidAddressId_CorrectResult()
        {
            InsertTestAddress();
            var address = GetFirstAddress();

            _addressService.DeleteAddress(address.Id);
            address = GetFirstAddress();

            Assert.AreEqual(null, address, "Address should be null.");
        }

        [TestMethod]
        public void ListAddresses_ValidFilter_CorrectResult()
        {
            InsertTestAddress();
            var addresses = _addressService.ListAddresses(new AddressFilter { City = _oldCity });

            Assert.AreEqual(1, addresses.Count(), "Count should be 1.");
        }

        private void InsertTestAddress()
        {

        }

        private AddressDTO GetFirstAddress()
        {
            return _addressService.ListAddresses(null).FirstOrDefault();
        }
    }
}
