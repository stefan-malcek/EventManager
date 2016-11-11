using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.DTOs.Registrations;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Queries
{
    public class RegistrationListQuery : AppQuery<RegistrationDTO>
    {
        public RegistrationFilter Filter { get; set; }

        public RegistrationListQuery(IUnitOfWorkProvider provider) : base(provider) { }

        protected override IQueryable<RegistrationDTO> GetQueryable()
        {
            IQueryable<Registration> query = Context.Registrations;

            if (Filter.EventId > 0)
            {
                query = query.Where(w => w.Event.ID == Filter.EventId);
            }

            if (Filter.UserId > 0)
            {
                query = query.Where(w => w.User.ID == Filter.UserId);
            }

            if (Filter.State.HasValue)
            {
                query = query.Where(w => w.State == Filter.State.Value);
            }

            return query.ProjectTo<RegistrationDTO>();
        }
    }
}
