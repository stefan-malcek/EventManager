using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void CreateRegistration(RegistrationCreateDTO registrationCreateDto)
        {
            _registrationService.CreateRegistration(registrationCreateDto);
        }

        public void UpdateRegistration(RegistrationUpdateDTO registrationUpdateDto)
        {
            _registrationService.UpdateRegistration(registrationUpdateDto);
        }

        public void DeleteRegistration(int registrationId)
        {
            _registrationService.DeleteRegistration(registrationId);
        }

        public IEnumerable<RegistrationDTO> ListRegistrations(RegistrationFilter filter)
        {
            return _registrationService.ListRegistrations(filter);
        }
    }
}
