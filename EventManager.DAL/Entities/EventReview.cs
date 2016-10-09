using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.DAL.Entities
{
    public class EventReview : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rating { get; set; }
        [MaxLength(128)]
        public string User { get; set; }
        [Required]
        public virtual Event Event { get; set; }
    }
}
