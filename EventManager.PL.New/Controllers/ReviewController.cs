using System.Web.Mvc;
using EventManager.AccountPolicy;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.Facades;

namespace EventManager.PL.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        public EventFacade EventFacade { get; set; }

        public ActionResult Create(int eventId)
        {
            return View(new EventReviewCreateDTO { EventId = eventId });
        }

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

        [Authorize(Roles = Claims.Admin)]
        public ActionResult Edit(int id, int reviewId)
        {
            if (reviewId <= 0)
            {
                return RedirectToAction("Detail", "Event", new { id = id });
            }

            var review = EventFacade.GetReview(reviewId);
            return View(review);
        }

        [HttpPost]
        [Authorize(Roles = Claims.Admin)]
        public ActionResult Edit(int id, EventReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return View(reviewDto);
            }

            try
            {
                EventFacade.UpdateReview(reviewDto);
                return RedirectToAction("Detail", "Event", new { id = reviewDto.EventId });
            }
            catch
            {
                return View(reviewDto);
            }
        }

        [Authorize(Roles = Claims.Admin)]
        public ActionResult Delete(int id, int reviewId)
        {
            if (reviewId <= 0)
            {
                return RedirectToAction("Detail", "Event", new { id = id });
            }

            EventFacade.DeleteReview(reviewId);
            return RedirectToAction("Detail", "Event", new { id = id });
        }
    }
}