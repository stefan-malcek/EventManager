using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Facades;

namespace EventManager.PL.Controllers
{
    [Authorize(Roles = Claims.Organizer)]
    [Authorize(Roles = Claims.Admin)]
    public class AddressController : Controller
    {
        public EventFacade EventFacade { get; set; }

        // GET: Address
        public ActionResult Index()
        {
            var addresses = EventFacade.ListAddresses(new AddressFilter());
            return View(addresses);
        }

        // GET: Address/Detail/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var address = EventFacade.GetAddress(id);
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View(new AddressCreateDTO());
        }

        // POST: Address/Create
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

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var address = EventFacade.GetAddress(id);
            return View(address);
        }

        // POST: Address/Edit/5
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

        // GET: Address/Delete/5
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
