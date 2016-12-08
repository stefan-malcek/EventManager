using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs.Users;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Queries
{
    public class UserAccordingToEmailQuery : AppQuery<UserDTO>
    {
        public UserAccordingToEmailQuery(IUnitOfWorkProvider provider) : base(provider) { }

        public string Email { get; set; }

        protected override IQueryable<UserDTO> GetQueryable()
        {
            if (string.IsNullOrEmpty(Email) || !new EmailAddressAttribute().IsValid(Email))
            {
                throw new InvalidOperationException("UserAccordingToUserIdQuery - Email must be valid.");
            }

            // Single result is expected so client side execution is not a problem
            var user = Context.Users.Include(nameof(User.Account))
                .FirstOrDefault(c => c.Account.Email.Equals(Email));

            if (user == null)
            {
                return new EnumerableQuery<UserDTO>(new List<UserDTO> ());
            }

            var userDto = AutoMapper.Mapper.Map<UserDTO>(user);

            return new EnumerableQuery<UserDTO>(new List<UserDTO> { userDto });
        }
    }
}
