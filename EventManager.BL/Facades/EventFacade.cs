using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Services.Addresses;
using EventManager.BL.Services.Events;
using EventManager.BL.Services.Reviews;

namespace EventManager.BL.Facades
{
    public class EventFacade
    {
        private readonly IEventService _eventService;
        private readonly IAddressService _addressService;
        private readonly IReviewService _reviewService;

        public EventFacade(IEventService eventService, IAddressService addressService, IReviewService reviewService)
        {
            _eventService = eventService;
            _addressService = addressService;
            _reviewService = reviewService;
        }

        #region Address functionality
        public void CreateAddress(AddressCreateDTO addressDto)
        {
            _addressService.CreateAddress(addressDto);
        }

        public void UpdateAddress(AddressDTO addressDto)
        {
            _addressService.UpdateAddress(addressDto);
        }

        public void DeleteAddress(int addressId)
        {
            _addressService.DeleteAddress(addressId);
        }

        public AddressDTO GetAddress(int addressId)
        {
            return _addressService.GetAddress(addressId);
        }

        public IEnumerable<AddressDTO> ListAddresses(AddressFilter filter)
        {
            return _addressService.ListAddresses(filter);
        }
        #endregion

        public void CreateEvent(EventDTO eventDto)
        {
            _eventService.CreateEvent(eventDto);
        }

        public void UpdateEvent(EventDTO eventDto)
        {
            _eventService.UpdateEvent(eventDto);
        }

        public void DeleteEvent(int eventId)
        {
            _eventService.DeleteEvent(eventId);
        }

        public EventPagedListResultDTO ListEventsForPage(EventFilter filter, int page = 1)
        {
            return _eventService.ListEvents(filter, page);
        }

        public void CreateReview(EventReviewCreateDTO reviewCreateDto)
        {
            _reviewService.AddReview(reviewCreateDto);
        }

        public void UpdateReview(EventReviewUpdateDTO reviewUpdateDto)
        {
            _reviewService.UpdateReview(reviewUpdateDto);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewService.DeleteReview(reviewId);
        }

        public IEnumerable<EventReviewDTO> ListReviewsForEvent(int eventId)
        {
            return _reviewService.ListReviewsForEvent(eventId);
        }
    }
}
