using System.Collections.Generic;
using System.Linq;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Services.Addresses;
using EventManager.BL.Services.Events;
using EventManager.BL.Services.Registrations;
using EventManager.BL.Services.Reviews;

namespace EventManager.BL.Facades
{
    public class EventFacade
    {
        private readonly IEventService _eventService;
        private readonly IAddressService _addressService;
        private readonly IReviewService _reviewService;
        private readonly IRegistrationService _registrationService;

        public EventFacade(IEventService eventService, IAddressService addressService, IReviewService reviewService,
            IRegistrationService registrationService)
        {
            _eventService = eventService;
            _addressService = addressService;
            _reviewService = reviewService;
            _registrationService = registrationService;
        }

        /// <summary>
        /// Create new event address.
        /// </summary>
        /// <param name="addressDto">address</param>
        public void CreateAddress(AddressCreateDTO addressDto)
        {
            _addressService.CreateAddress(addressDto);
        }

        /// <summary>
        /// Update address data.
        /// </summary>
        /// <param name="addressDto">address</param>
        public void UpdateAddress(AddressDTO addressDto)
        {
            _addressService.UpdateAddress(addressDto);
        }

        /// <summary>
        /// Delete address with given addressId.
        /// </summary>
        /// <param name="addressId">address id</param>
        public void DeleteAddress(int addressId)
        {
            _addressService.DeleteAddress(addressId);
        }

        /// <summary>
        /// Return address with given id.
        /// </summary>
        /// <param name="addressId">address id</param>
        /// <returns>address</returns>
        public AddressDTO GetAddress(int addressId)
        {
            return _addressService.GetAddress(addressId);
        }

        /// <summary>
        /// List addresses with given filter.
        /// </summary>
        /// <param name="filter">address filter</param>
        /// <returns>collection of addresses</returns>
        public IEnumerable<AddressDTO> ListAddresses(AddressFilter filter)
        {
            return _addressService.ListAddresses(filter);
        }

        /// <summary>
        /// Create new event.
        /// </summary>
        /// <param name="eventDto">event</param>
        public void CreateEvent(EventDTO eventDto)
        {
            _eventService.CreateEvent(eventDto);
        }

        /// <summary>
        /// Update event data.
        /// </summary>
        /// <param name="eventDto">event</param>
        public void UpdateEvent(EventDTO eventDto)
        {
            _eventService.UpdateEvent(eventDto);
        }

        /// <summary>
        /// Delete event with given eventId.
        /// </summary>
        /// <param name="eventId">event id</param>
        public void DeleteEvent(int eventId)
        {
            _eventService.DeleteEvent(eventId);
        }

        /// <summary>
        /// Return event with given eventId.
        /// </summary>
        /// <param name="eventId">event id</param>
        /// <returns>event</returns>
        public EventDTO GetEvent(int eventId)
        {
            return _eventService.GetEvent(eventId);
        }

        /// <summary>
        /// Return detail of event with given eventId.
        /// </summary>
        /// <param name="eventId">event id</param>
        /// <returns>event detail</returns>
        public EventDetailDTO GetEventDetail(int eventId)
        {
            var @event = GetEvent(eventId);
            var reviews = _reviewService.ListReviewsForEvent(eventId).ToList();
            var isEnded = _registrationService.AreRegistrationsAllowed(eventId);
            var registrations = _registrationService.ListRegistrations(new RegistrationFilter { EventId = eventId });
            var averageRating = reviews.Any() ? reviews.Average(a => a.Rating) as double? : null;

            return new EventDetailDTO
            {
                Event = @event,
                AverageRating = averageRating,
                IsEnded = isEnded,
                Registrations = registrations,
                Reviews = reviews
            };
        }

        /// <summary>
        /// Return page of events with given filter.
        /// </summary>
        /// <param name="filter">event filter</param>
        /// <param name="page">number of page</param>
        /// <returns>page of events</returns>
        public EventPagedListResultDTO ListEvents(EventFilter filter, int page = 1)
        {
            return _eventService.ListEvents(filter, page);
        }

        /// <summary>
        /// Create new review.
        /// </summary>
        /// <param name="reviewCreateDto">review</param>
        public void CreateReview(EventReviewCreateDTO reviewCreateDto)
        {
            _reviewService.AddReview(reviewCreateDto);
        }

        /// <summary>
        /// Update review data.
        /// </summary>
        /// <param name="reviewUpdateDto">review</param>
        public void UpdateReview(EventReviewUpdateDTO reviewUpdateDto)
        {
            _reviewService.UpdateReview(reviewUpdateDto);
        }

        /// <summary>
        /// Delete review with given reviewId.
        /// </summary>
        /// <param name="reviewId">review id</param>
        public void DeleteReview(int reviewId)
        {
            _reviewService.DeleteReview(reviewId);
        }
    }
}
