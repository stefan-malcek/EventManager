using Riganti.Utils.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.DAL.Entities
{
    /// <summary>
    /// Event definition.
    /// </summary>
    public class Event : IEntity<int>
    {
        public int ID { get; set; }
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
        [NotMapped]
        public TimeSpan Duration => End - Start;
        public int? Capacity { get; set; }
        public int Fee { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required]
        public virtual EventOrganizer EventOrganizer { get; set; }
        public virtual List<EventReview> EventReviews { get; set; }
        public virtual List<Registration> Registrations { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Title: {Title}, Description: {Description}, Lecturer: {Lecturer}, Date: {Date}, Start: {Start}, End: {End}, Duration: {Duration}, Capacity: {Capacity}, Fee: {Fee}";
        }
    }
}
