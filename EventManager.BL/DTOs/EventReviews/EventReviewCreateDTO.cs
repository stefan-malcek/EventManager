using System.ComponentModel.DataAnnotations;

namespace EventManager.BL.DTOs.EventReviews
{
    public class EventReviewCreateDTO
    {
        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
        [Required]
        [MaxLength(128)]
        public string Author { get; set; } = "Anonym";
        [Required]
        [MaxLength(65536)]
        public string Review { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
