using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.BL.DTOs.Event
{
    public class EventDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1024)]
        public string Title { get; set; }
        [MaxLength(65536)]
        public string Description { get; set; }
        [Required]
        [MaxLength(128)]
        public string Lecturer { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Start { get; set; }
        [Required]
        public TimeSpan End { get; set; }
        public TimeSpan Duration => End - Start;
        public int? Capacity { get; set; }
        public int? Fee { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int EventOrganizerId { get; set; }
    }
}
