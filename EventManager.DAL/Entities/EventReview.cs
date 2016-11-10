using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.DAL.Entities
{
    /// <summary>
    /// EventReview contains user rating and author name.
    /// </summary>
    public class EventReview : IEntity<int>
    {
        public int ID { get; set; }
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
        public virtual Event Event { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Rating: {Rating}, Author: {Author}";
        }
    }
}
