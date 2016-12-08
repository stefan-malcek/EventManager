using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.Facades;
using EventManager.PL.Helpers;

namespace EventManager.PL.Controllers
{
    public class PaymentController : Controller
    {
        public RegistrationFacade RegistrationFacade { get; set; }

        public ActionResult Pay(int registrationid, int eventid)
        {
            if (eventid <= 00 && registrationid <= 0)
            {
                return RedirectToAction("Detail", "Event", new { id = eventid });
            }

            var registration = RegistrationFacade.GetRegistration(registrationid);
            return View(registration);
        }

        [HttpPost]
        //[MultiPostAction(Name = "action", Argument = "Pay")]
        public ActionResult Pay(RegistrationDTO registrationDto)
        {
            Debug.WriteLine(registrationDto);
            RegistrationFacade.UpdateRegistration(registrationDto);
            return RedirectToAction("Detail", "Event", new { id = registrationDto.EventId });
        }
    }
}