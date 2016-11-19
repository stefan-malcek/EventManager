using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.Facades;

namespace EventManager.WebAPI.Controllers
{
    public class ReviewController : ApiController
    {
        public EventFacade EventFacade { get; set; }

        /// <summary>
        /// List all reviews.
        /// </summary>
        /// <returns>collection of all reviews</returns>
        public IEnumerable<EventReviewDTO> Get()
        {
            return EventFacade.ListReviewsForEvent();
        }

        /// <summary>
        /// List reviews for given event id.
        /// </summary>
        /// <param name="id">event id</param>
        /// <returns>collection of reviews</returns>
        [Route("~/api/Review/Event/{id}")]
        public IEnumerable<EventReviewDTO> Get(int id)
        {
            return id <= 0 ? null : EventFacade.ListReviewsForEvent(id);
        }

        /// <summary>
        /// Creates new review.
        /// </summary>
        /// <param name="review">new review</param>
        /// <returns>status code</returns>
        public IHttpActionResult Post([FromBody] EventReviewCreateDTO review)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            try
            {
                EventFacade.CreateReview(review);
                return StatusCode(HttpStatusCode.OK);
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }
    }
}
