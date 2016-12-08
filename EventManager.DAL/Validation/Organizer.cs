using System.ComponentModel.DataAnnotations;
using System.Linq;
using EventManager.AccountPolicy;
using EventManager.DAL.Entities;
using EventManager.DAL.Enums;

namespace EventManager.DAL.Validation
{
    public class Organizer : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var user = value as User;
            return user != null && user.Account.ClaimCollection.Any(a => Equals(a.Value, Claims.Organizer));
        }
    }
}
