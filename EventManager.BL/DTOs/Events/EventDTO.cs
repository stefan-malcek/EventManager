using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.BL.DTOs.Events
{
    public class EventDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Title { get; set; }
        [Required]
        [MaxLength(65536)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [MaxLength(128)]
        public string Lecturer { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Today;
        [Required]
        public TimeSpan Start { get; set; }
        [Required]
        public TimeSpan End { get; set; }
        public int? Capacity { get; set; }
        public int Fee { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
