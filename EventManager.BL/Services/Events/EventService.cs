using System;
using System.Collections.Generic;
using AutoMapper;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Queries;
using EventManager.BL.Repositories;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Services.Events
{
    public class EventService : EventManagerService, IEventService
    {
        private readonly EventRepository _eventRepository;
        private readonly AddressRepository _addressRepository;
        private readonly UserRepository _userRepository;
        private readonly EventListQuery _eventListQuery;

        public int EventPageSize => 5;

        public EventService(EventRepository eventRepository, AddressRepository addressRepository,
            UserRepository userRepository, EventListQuery eventListQuery)
        {
            _eventRepository = eventRepository;
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _eventListQuery = eventListQuery;
        }

        public void CreateEvent(EventDTO eventDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var @event = Mapper.Map<Event>(eventDto);
                var organizer = GetOrganizer(eventDto.UserId);
                @event.Address = GetAddress(eventDto.AddressId);
                @event.EventOrganizer = new EventOrganizer
                {
                    Event = @event,
                    User = organizer
                };

                _eventRepository.Insert(@event);
                uow.Commit();
            }
        }

        public void UpdateEvent(EventDTO eventDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var @event = _eventRepository.GetById(eventDto.Id, g => g.EventOrganizer);
                Mapper.Map(eventDto, @event);
                @event.Address = GetAddress(eventDto.AddressId);
                @event.EventOrganizer.User = GetOrganizer(eventDto.UserId);

                _eventRepository.Update(@event);
                uow.Commit();
            }
        }

        public void DeleteEvent(int eventId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                _eventRepository.Delete(eventId);
                uow.Commit();
            }
        }

        public EventDTO GetEvent(int eventId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var @event = _eventRepository.GetById(eventId);
                return @event == null ? null : Mapper.Map<EventDTO>(@event);
            }
        }

        public IEnumerable<EventDTO> ListEvents()
        {
            using (UnitOfWorkProvider.Create())
            {
                _eventListQuery.Filter = new EventFilter();
                return _eventListQuery.Execute() ?? new List<EventDTO>();
            }
        }

        public EventPagedListResultDTO ListEvents(EventFilter filter, int page = 1)
        {
            using (UnitOfWorkProvider.Create())
            {
                var query = _eventListQuery;
                query.ClearSortCriterias();
                query.Filter = filter;
                query.Skip = Math.Max(0, page - 1) * EventPageSize;
                query.Take = EventPageSize;

                var sortOrder = filter.SortAscending ? SortDirection.Ascending : SortDirection.Descending;
                query.AddSortCriteria(filter.SortCriteria.ToString(), sortOrder);

                return new EventPagedListResultDTO
                {
                    RequestedPage = page,
                    TotalResultCount = query.GetTotalRowCount(),
                    ResultPageData = query.Execute(),
                    Filter = filter
                };
            }
        }


        private User GetOrganizer(int organizerId)
        {
            var organizer = _userRepository.GetById(organizerId, x => x.EventOrganizers);
            if (organizer == null)
            {
                throw new ArgumentException("Invalid pamater value.", nameof(organizerId));
            }

            return organizer;
        }

        private Address GetAddress(int addressId)
        {
            var address = _addressRepository.GetById(addressId);
            if (address == null)
            {
                throw new ArgumentException("Invalid pamater value.", nameof(addressId));
            }

            return address;
        }
    }
}
