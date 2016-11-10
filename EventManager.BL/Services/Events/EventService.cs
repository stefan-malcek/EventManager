using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Event;
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

        public int EventPageSize => 7;

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
                @event.Address = GetAddress(eventDto.AddressId);
                @event.EventOrganizer = new EventOrganizer
                {
                    Event = @event,
                    User = GetOrganizer(eventDto.EventOrganizerId)
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
                //TODO @event.EventOrganizer = GetOrganizer(eventDto.EventOrganizerId);

                //TODO eventReviews

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
                var @event = _addressRepository.GetById(eventId);
                return @event == null ? null : Mapper.Map<EventDTO>(@event);
            }
        }

        public PagedListResultDTO<EventDTO> ListEvents(EventFilter filter, int page = 1)
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
            var organizer = _userRepository.GetById(organizerId);

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
