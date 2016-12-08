using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.Facades;
using EventManager.BL.Miscellaneous;
using EventManager.PL.ViewModels.Events;
using X.PagedList;

namespace EventManager.PL.Controllers
{
    public class EventController : Controller
    {
        public EventFacade EventFacade { get; set; }
        public UserFacade UserFacade { get; set; }
        public RegistrationFacade RegistrationFacade { get; set; }

        public ActionResult Index(int page = 1)
        {
            var events = EventFacade.ListEvents(new EventFilter { SortCriteria = EventSortCriteria.Date }, page);
            var eventListViewModel = new EventListViewModel
            {
                Events = new StaticPagedList<EventDTO>(events.ResultPageData, events.RequestedPage, EventFacade.EventPageSize, events.TotalResultCount)
            };

            return View(eventListViewModel);
        }

        public ActionResult Detail(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var eventDetail = EventFacade.GetEventDetail(id);
            var organizer = UserFacade.GetUser(eventDetail.Event.UserId);
            var address = EventFacade.GetAddress(eventDetail.Event.AddressId);

            var eventDetailViewModel = new EventDetailViewModel
            {
                EventDetail = eventDetail,
                Organizer = organizer,
                Address = address
            };
            return View(eventDetailViewModel);
        }

        public ActionResult Create()
        {
            var addresses = EventFacade.ListAddresses(new AddressFilter());
            var organizers = UserFacade.ListUsers(new UserFilter());
            var eventViewModel = new EventViewModel
            {
                EventData = new EventDTO(),
                AddressList = new SelectList(addresses, "Id", "FullAddress"),
                Organizers = new SelectList(organizers, "Id", "Id")
            };
            return View(eventViewModel);
        }

        [HttpPost]
        public ActionResult Create(EventViewModel @event)
        {
            if (!ModelState.IsValid)
            {
                var addresses = EventFacade.ListAddresses(new AddressFilter());
                var organizers = UserFacade.ListUsers(new UserFilter());
                @event.AddressList = new SelectList(addresses, "Id", "FullAddress");
                @event.Organizers = new SelectList(organizers, "Id", "Id");
                return View(@event);
            }

            EventFacade.CreateEvent(@event.EventData);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Register(int userid, int eventid)
        {
            if (eventid <= 0)
            {
                return RedirectToAction("Index");
            }

            try
            {
                RegistrationFacade.Register(new RegistrationCreateDTO
                {
                    EventId = eventid,
                    UserId = userid
                });
            }
            catch (Exception ex)
            {
                //TODO log
            }

            return RedirectToAction("Detail", new { id = eventid });
        }

        public ActionResult Unregister(int registrationid, int eventid)
        {
            if (eventid <= 0 && registrationid <= 0)
            {
                return RedirectToAction("Index");
            }

            try
            {
                RegistrationFacade.Unregister(registrationid);
            }
            catch (Exception ex)
            {
                //TODO log
            }

            return RedirectToAction("Detail", new { id = eventid });
        }

        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var @event = EventFacade.GetEvent(id);
            var addresses = EventFacade.ListAddresses(new AddressFilter());
            var organizers = UserFacade.ListUsers(new UserFilter());
            var eventViewModel = new EventViewModel
            {
                EventData = @event,
                AddressList = new SelectList(addresses, "Id", "FullAddress"),
                Organizers = new SelectList(organizers, "Id", "Id")
            };
            return View(eventViewModel);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EventViewModel @event)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }

            try
            {
                EventFacade.UpdateEvent(@event.EventData);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(@event);
            }
        }
    }
}