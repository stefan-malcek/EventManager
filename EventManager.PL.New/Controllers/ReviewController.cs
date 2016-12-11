using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.Facades;

namespace EventManager.PL.Controllers
{
    public class ReviewController : Controller
    {
        public EventFacade EventFacade { get; set; }

        public ActionResult Create(int eventId)
        {
            return View(new EventReviewCreateDTO {EventId = eventId});
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int eventId, EventReviewCreateDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", reviewDto);
            }

            try
            {
                EventFacade.CreateReview(reviewDto);
                return RedirectToAction("Detail", "Event", new { id = reviewDto.EventId });
            }
            catch
            {
                return View("Create", reviewDto);
            }
        }
    }
}