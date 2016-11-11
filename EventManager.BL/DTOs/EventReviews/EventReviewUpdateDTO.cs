using System.ComponentModel.DataAnnotations;

namespace EventManager.BL.DTOs.EventReviews
{
   public class EventReviewUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
        [Required]
        [MaxLength(65536)]
        public string Review { get; set; }
    }
}
