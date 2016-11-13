using System.Collections.Generic;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.Services.Registrations;

namespace EventManager.BL.Facades
{
    public class RegistrationFacade
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationFacade(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        /// <summary>
        /// Register user on event.
        /// </summary>
        /// <param name="registrationCreateDto">registration data</param>
        public void Register(RegistrationCreateDTO registrationCreateDto)
        {
            _registrationService.Register(registrationCreateDto);
        }

        /// <summary>
        /// Update registration.
        /// </summary>
        /// <param name="registrationDto">registration data</param>
        public void UpdateRegistration(RegistrationDTO registrationDto)
        {
            _registrationService.UpdateRegistration(registrationDto);
        }

        /// <summary>
        /// Unregister user from event.
        /// </summary>
        /// <param name="registrationId">registration id</param>
        public void Unregister(int registrationId)
        {
            _registrationService.Unregister(registrationId);
        }

        /// <summary>
        /// Return registration for given registrationId.
        /// </summary>
        /// <param name="registrationId"> registration id</param>
        /// <returns>registration</returns>
        public RegistrationDTO GetRegistration(int registrationId)
        {
            return _registrationService.GetRegistration(registrationId);
        }

        /// <summary>
        /// List registrations for given filter.
        /// </summary>
        /// <param name="filter">registration filter</param>
        /// <returns>collection of registrations</returns>
        public IEnumerable<RegistrationDTO> ListRegistrations(RegistrationFilter filter)
        {
            return _registrationService.ListRegistrations(filter);
        }
    }
}
