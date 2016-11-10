using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BL.DTOs.EventReview
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
