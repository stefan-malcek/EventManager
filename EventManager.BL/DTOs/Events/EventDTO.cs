using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BL.DTOs.Events
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
        public int? Capacity { get; set; }
        public int Fee { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
