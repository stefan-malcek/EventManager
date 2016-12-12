using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Events;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.BL.DTOs.Users;
using EventManager.BL.Facades;
using EventManager.BL.Miscellaneous;
using EventManager.PL.ViewModels.Events;
using X.PagedList;

namespace EventManager.PL.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly string filterSessionKey = "filter";
        
        public EventFacade EventFacade { get; set; }
        public UserFacade UserFacade { get; set; }
        public RegistrationFacade RegistrationFacade { get; set; }

        public ActionResult Index(int page = 1)
        {
            var filter = Session[filterSessionKey] as EventFilter ?? new EventFilter();
            var events = EventFacade.ListEvents(new EventFilter { SortCriteria = EventSortCriteria.Date }, page);

            return View(CreateEventListViewModel(events, filter));
        }

        [HttpPost]
        public ActionResult Index(EventListViewModel model)
        {
            Session[filterSessionKey] = model.Filter;
            var events = EventFacade.ListEvents(model.Filter);

            return View(CreateEventListViewModel(events, model.Filter));
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
            
            return View(CreateEventDetailViewModel(eventDetail, address, organizer));
        }

        [Authorize(Roles = Claims.Organizer + ", " + Claims.Admin)]
        public ActionResult Create()
        {
            var addresses = EventFacade.ListAddresses(new AddressFilter());
            var organizers = UserFacade.ListUsers(new UserFilter { Role = Claims.Organizer });

            return View(CreateEventViewModel(new EventDTO(), addresses, organizers));
        }

        [HttpPost]
        [Authorize(Roles = Claims.Organizer + ", " + Claims.Admin)]
        public ActionResult Create(EventViewModel @event)
        {
            if (!ModelState.IsValid)
            {
                var addresses = EventFacade.ListAddresses(new AddressFilter());
                var organizers = UserFacade.ListUsers(new UserFilter { Role = Claims.Organizer });

                return View(CreateEventViewModel(@event.EventData, addresses, organizers));
            }

            EventFacade.CreateEvent(@event.EventData);

            return RedirectToAction("Index");
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
            catch (Exception)
            {
               
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

        [Authorize(Roles = Claims.Organizer + ", " + Claims.Admin)]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var @event = EventFacade.GetEvent(id);
            var addresses = EventFacade.ListAddresses(new AddressFilter());
            var organizers = UserFacade.ListUsers(new UserFilter {Role = Claims.Organizer});

            return View(CreateEventViewModel(@event, addresses, organizers));
        }
        
        [HttpPost]
        [Authorize(Roles = Claims.Organizer + ", " + Claims.Admin)]
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

        public ActionResult ClearFilter()
        {
            Session[filterSessionKey] = null;
            return RedirectToAction(nameof(Index));
        }

        private EventViewModel CreateEventViewModel(EventDTO eventDto, IEnumerable<AddressDTO> addresses,
            IEnumerable<UserDTO> organizers)
        {
            return new EventViewModel
            {
                EventData = eventDto,
                AddressList = new SelectList(addresses, "Id", "FullAddress"),
                Organizers = new SelectList(organizers, "Id", "FullName")
            };
        }

        private EventDetailViewModel CreateEventDetailViewModel(EventDetailDTO eventDto, AddressDTO address,
            UserDTO organizer)
        {
            return new EventDetailViewModel
            {
                EventDetail = eventDto,
                Address = address,
                Organizer = organizer
            };
        }

        private EventListViewModel CreateEventListViewModel(EventPagedListResultDTO events, EventFilter filter)
        {
            return  new EventListViewModel
            {
                Filter = filter,
                EventsPage = new StaticPagedList<EventDTO>(events.ResultPageData, events.RequestedPage, 
                EventFacade.EventPageSize, events.TotalResultCount)
            };
        }
    }
}