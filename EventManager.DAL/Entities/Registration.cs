using Riganti.Utils.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.DAL.Entities
{
    public class Registration : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        [Range(0, 1)]
        public virtual RegistrationState State { get; set; }
        [Required]
        public virtual Event Event { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
