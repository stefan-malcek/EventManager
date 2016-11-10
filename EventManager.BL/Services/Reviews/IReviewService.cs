using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs.EventReview;

namespace EventManager.BL.Services.Reviews
{
    public interface IReviewService
    {
        void AddReview(EventReviewCreateDTO reviewDto);
        void UpdateReview(EventReviewUpdateDTO reviewDto);
        void DeleteReview(int reviewId);
        IEnumerable<EventReviewDTO> GetAllReviewsForEvent(int eventId);
    }
}
