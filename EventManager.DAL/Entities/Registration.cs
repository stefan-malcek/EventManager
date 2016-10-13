using Riganti.Utils.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Enums;

namespace EventManager.DAL.Entities
{
    /// <summary>
    /// Registration represents relationship between event and user.
    /// </summary>
    public class Registration : IEntity<int>
    {
        public int ID { get; set; }
        [Required]
        public RegistrationState State { get; set; }
        [Required]
        public virtual Event Event { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
