using System.Collections.Generic;
using EventManager.BL.DTOs.EventReviews;

namespace EventManager.BL.Services.Reviews
{
    public interface IReviewService
    {
        void AddReview(EventReviewCreateDTO reviewDto);

        void UpdateReview(EventReviewUpdateDTO reviewDto);

        void DeleteReview(int reviewId);

        IEnumerable<EventReviewDTO> ListReviewsForEvent(int eventId = 0);
    }
}
