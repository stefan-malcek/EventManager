using System.Diagnostics;
using System.Web.Mvc;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.Facades;

namespace EventManager.PL.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        public RegistrationFacade RegistrationFacade { get; set; }

        public ActionResult Pay(int registrationid, int eventid)
        {
            if (eventid <= 0 && registrationid <= 0)
            {
                return RedirectToAction("Detail", "Event", new { id = eventid });
            }

            var registration = RegistrationFacade.GetRegistration(registrationid);
            return View(registration);
        }

        [HttpPost]
        public ActionResult Pay(RegistrationDTO registrationDto)
        {
            Debug.WriteLine(registrationDto);
            RegistrationFacade.UpdateRegistration(registrationDto);
            return RedirectToAction("Detail", "Event", new { id = registrationDto.EventId });
        }
    }
}