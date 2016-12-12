using System.Web.Mvc;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Facades;

namespace EventManager.PL.Controllers
{
    [Authorize(Roles = Claims.Organizer + ", " + Claims.Admin)]
    public class AddressController : Controller
    {
        public EventFacade EventFacade { get; set; }

        public ActionResult Index()
        {
            var addresses = EventFacade.ListAddresses(new AddressFilter());
            return View(addresses);
        }

        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var address = EventFacade.GetAddress(id);
            return View(address);
        }

        public ActionResult Create()
        {
            return View(new AddressCreateDTO());
        }

        [HttpPost]
        public ActionResult Create(AddressCreateDTO address)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", address);
            }

            try
            {
                EventFacade.CreateAddress(address);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create", address);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var address = EventFacade.GetAddress(id);
            return View(address);
        }

        [HttpPost]
        public ActionResult Edit(int id, AddressDTO address)
        {
            if (!ModelState.IsValid)
            {
                return View(address);
            }

            try
            {
                EventFacade.UpdateAddress(address);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(address);
            }
        }

        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            EventFacade.DeleteAddress(id);
            return RedirectToAction("Index");
        }
    }
}
