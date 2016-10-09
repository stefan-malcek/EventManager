using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.DAL.Entities
{
    public class Address : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Street { get; set; }
        [Required]
        [MaxLength(16)]
        public string StreetNumber { get; set; }
        [Required]
        [MaxLength(128)]
        public string City { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int ZipCode { get; set; }
        [Required]
        [MaxLength(128)]
        public string State { get; set; }
        public virtual List<Event> Events { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Street: {Street}, StreetNumber: {StreetNumber}, City: {City}, ZipCode: {ZipCode}, State: {State}";
        }
    }
}
