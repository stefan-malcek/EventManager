using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registration;
using EventManager.BL.Queries;
using EventManager.BL.Repositories;
using EventManager.DAL.Entities;

namespace EventManager.BL.Services.Registrations
{
    public class RegistrationService : EventManagerService, IRegistrationService
    {
        private readonly RegistrationRepository _registrationRepository;
        private readonly EventRepository _eventRepository;
        private readonly UserRepository _userRepository;
        private readonly RegistrationListQuery _registrationListQuery;

        public RegistrationService(RegistrationRepository registrationRepository, EventRepository eventRepository,
            UserRepository userRepository, RegistrationListQuery registrationListQuery)
        {
            _registrationRepository = registrationRepository;
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _registrationListQuery = registrationListQuery;
        }

        public void CreateRegistration(RegistrationCreateDTO registrationDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var registration = Mapper.Map<Registration>(registrationDto);
                registration.Event = GetEvent(registrationDto.EventId);
                registration.User = GetUser(registrationDto.UserId);

                _registrationRepository.Insert(registration);
                uow.Commit();
            }
        }

        public void UpdateRegistration(RegistrationUpdateDTO registrationDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var registration = _registrationRepository.GetById(registrationDto.Id);
                Mapper.Map(registrationDto, registration);

                _registrationRepository.Update(registration);
                uow.Commit();
            }
        }

        public void DeleteRegistration(int registrationId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                _registrationRepository.Delete(registrationId);
                uow.Commit();
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
    }
}
