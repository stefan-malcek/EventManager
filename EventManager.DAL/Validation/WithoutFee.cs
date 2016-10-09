using System.ComponentModel.DataAnnotations;

namespace EventManager.DAL.Validation
{
    public class WithoutFee : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
            //RegistrationState state;

            //if (Enum.TryParse(value?.ToString(), out state))
            //{


            //    return ;
            //}

            //return false;
        }
    }
}
