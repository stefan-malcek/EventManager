using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManager.BL.Miscellaneous.AccountPolicy
{
    /// <summary>
    /// Defines various roles used within authentication
    /// </summary>
    public static class Claims
    {
        public const string Member = "Member";

        public const string Organizer = "Organizer";

        public const string Admin = "Administrator";

        public const string AuthenticatedUsers = "Member, Organizer, Administrator";
    }
}
