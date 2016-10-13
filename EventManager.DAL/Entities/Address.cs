using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.DAL.Entities
{
    /// <summary>
    /// Entity represents address where events can be realized.
    /// Only available in Czech republic. 
    /// </summary>
    public class Address : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(512)]
        public string Building { get; set; }
        [Required]
        [MaxLength(256)]
        public string Street { get; set; }
        [Required]
        [MaxLength(16)]
        public string StreetNumber { get; set; }
        [Required]
        [MaxLength(128)]
        public string City { get; set; }
        public virtual List<Event> Events { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Building: {Building}, Street: {Street}, StreetNumber: {StreetNumber}, City: {City}";
        }
    }
}
