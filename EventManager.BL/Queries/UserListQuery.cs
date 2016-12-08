using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using AutoMapper.QueryableExtensions;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.Relational;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Users;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Queries
{
    public class UserListQuery : AppQuery<UserDTO>
    {
        public UserFilter Filter { get; set; }

        public UserListQuery(IUnitOfWorkProvider provider) : base(provider) { }

        protected override IQueryable<UserDTO> GetQueryable()
        {
            IQueryable<User> query = Context.Users;

            if (!string.IsNullOrEmpty(Filter.Role))
            {
                query = query.Where(w => w.Account.ClaimCollection.Any(a => Equals(a.Value, Filter.Role)));
            }

            return query.ProjectTo<UserDTO>();
        }
    }
}
