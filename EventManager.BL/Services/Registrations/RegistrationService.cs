using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.Miscellaneous;
using EventManager.BL.Miscellaneous.DateTimeProvider;
using EventManager.BL.Queries;
using EventManager.BL.Repositories;
using EventManager.DAL.Entities;
using EventManager.DAL.Enums;

namespace EventManager.BL.Services.Registrations
{
    public class RegistrationService : EventManagerService, IRegistrationService
    {
        private readonly RegistrationRepository _registrationRepository;
        private readonly EventRepository _eventRepository;
        private readonly UserRepository _userRepository;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly RegistrationListQuery _registrationListQuery;

        public RegistrationService(RegistrationRepository registrationRepository, EventRepository eventRepository,
            UserRepository userRepository, IDateTimeProvider dateTimeProvider, RegistrationListQuery registrationListQuery)
        {
            _registrationRepository = registrationRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _dateTimeProvider = dateTimeProvider;
            _registrationListQuery = registrationListQuery;
        }

        public void Register(RegistrationCreateDTO registrationDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var @event = GetEvent(registrationDto.EventId);

                //user cannot have two registrations on same event
                if (@event.Registrations.Select(s => s.User.ID).Contains(registrationDto.UserId))
                {
                    throw new InvalidOperationException("User is already registred on this event.");
                }

                //check if event is closed
                CheckEventDate(registrationDto.EventId);

                if (@event.Capacity.HasValue)
                {
                    var registeredUsersCount = ListRegistrations(new RegistrationFilter { EventId = registrationDto.EventId }).Count();

                    //check even capacity
                    if (registeredUsersCount >= @event.Capacity.Value)
                    {
                        //TODO implement queuee
                        throw new InvalidOperationException("User cannot be registred now.");
                    }
                }

                var registration = Mapper.Map<Registration>(registrationDto);
                registration.Event = @event;
                registration.User = GetUser(registrationDto.UserId);

                //set registration state based on fee value
                registration.State = @event.Fee == 0 ? RegistrationState.Accepted : RegistrationState.Unpaid;

                _registrationRepository.Insert(registration);
                uow.Commit();
            }
        }

        public void UpdateRegistration(RegistrationDTO registrationDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                CheckEventDate(registrationDto.EventId);

                var registration = _registrationRepository.GetById(registrationDto.Id, x => x.Event, x => x.User);

                //registration state can not be unpaid when event fee is 0
                if (registration.Event.Fee == 0 && registrationDto.State == RegistrationState.Unpaid)
                {
                    throw new InvalidOperationException("Action is invalid.");
                }

                Mapper.Map(registrationDto, registration);
                _registrationRepository.Update(registration);
                uow.Commit();
            }
        }

        public void Unregister(int registrationId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var registration = _registrationRepository.GetById(registrationId);
                CheckEventDate(registration.Event.ID);

                _registrationRepository.Delete(registrationId);
                uow.Commit();
            }
        }

        public RegistrationDTO GetRegistration(int eventId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var registration = _registrationRepository.GetById(eventId, i => i.Event, i => i.User);
                return registration == null ? null : Mapper.Map<RegistrationDTO>(registration);
            }
        }

        public bool IsEnded(int eventId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var @event = GetEvent(eventId);
                return @event.GetStartDateTime() <= _dateTimeProvider.GetCurrectDateTime();
            }
        }

        public IEnumerable<RegistrationDTO> ListRegistrations(RegistrationFilter filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                _registrationListQuery.Filter = filter;
                return _registrationListQuery.Execute() ?? new List<RegistrationDTO>();
            }
        }

        private User GetUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                throw new ArgumentException("Invalid parameter value.", nameof(userId));
            }

            return user;
        }

        private Event GetEvent(int eventId)
        {
            var @event = _eventRepository.GetById(eventId);
            if (@event == null)
            {
                throw new ArgumentException("Invalid parameter value.", nameof(eventId));
            }

            return @event;
        }

        private void CheckEventDate(int eventId)
        {
            var @event = GetEvent(eventId);

            //event provider for test purpose
            if (@event.GetStartDateTime() <= _dateTimeProvider.GetCurrectDateTime())
            {
                throw new InvalidOperationException("Registrations are closed.");
            }
        }
    }
}
