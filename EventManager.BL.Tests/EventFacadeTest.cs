using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.Facades;
using EventManager.BL.Repositories;
using EventManager.BL.Services.Addresses;
using EventManager.BL.Services.Events;
using EventManager.BL.Services.Reviews;
using EventManager.BL.TestData;
using Moq;
using NUnit.Framework;

namespace EventManager.BL.Tests
{
    [TestFixture]
    public class EventFacadeTest
    {
        private Mock<IEventService> _eventServiceMock;
        private Mock<IAddressService> _addressServiceMock;
        private Mock<IReviewService> _reviewServiceMock;
        private EventFacade _eventFacade;

        [SetUp]
        public void Setup()
        {
            _eventServiceMock = new Mock<IEventService>();
            _addressServiceMock = new Mock<IAddressService>();
            _reviewServiceMock = new Mock<IReviewService>();

            _eventFacade = new EventFacade(_eventServiceMock.Object, _addressServiceMock.Object,
                _reviewServiceMock.Object);
        }

        [Test]
        public void CreateAddress_ValidAddress_CorrectResult()
        {
            //arrange
            var addressCreateDto = Factory.GetAddress1();

            //act
            _eventFacade.CreateAddress(addressCreateDto);

            //assert
            _addressServiceMock.Verify(x => x.CreateAddress(addressCreateDto), Times.Once, "CreateAddress was not called.");
        }
    }
}
