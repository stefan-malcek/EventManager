using System.ComponentModel.DataAnnotations;
using EventManager.DAL.Entities;
using EventManager.DAL.Enums;

namespace EventManager.DAL.Validation
{
    public class Organizer : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var user = value as User;
            return user?.Role == UserRole.Organizer;
        }
    }
}
