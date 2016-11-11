using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;

namespace EventManager.BL.Services.Registrations
{
    public interface IRegistrationService
    {
        void CreateRegistration(RegistrationCreateDTO registrationDto);
        void UpdateRegistration(RegistrationUpdateDTO registrationDto);
        void DeleteRegistration(int registrationId);
        //TODO nieco ze registracia je v queuee
        IEnumerable<RegistrationDTO> ListRegistrations(RegistrationFilter filter);
    }
}
