using System.Linq;
using AutoMapper.QueryableExtensions;
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

            if (Filter.Role.HasValue)
            {
                query = query.Where(w => w.Role == Filter.Role);
            }

            return query.ProjectTo<UserDTO>();
        }
    }
}
