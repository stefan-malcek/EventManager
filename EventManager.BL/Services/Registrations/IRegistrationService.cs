using System.Collections.Generic;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;

namespace EventManager.BL.Services.Registrations
{
    public interface IRegistrationService
    {
        void Register(RegistrationCreateDTO registrationDto);

        void UpdateRegistration(RegistrationDTO registrationDto);

        void Unregister(int registrationId);

        RegistrationDTO GetRegistration(int eventId);

        bool IsEnded(int eventId);

        IEnumerable<RegistrationDTO> ListRegistrations(RegistrationFilter filter);
    }
}
