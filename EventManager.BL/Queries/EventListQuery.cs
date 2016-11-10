using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Event;
using EventManager.BL.DTOs.Filters;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Queries
{
    public class EventListQuery : AppQuery<EventDTO>
    {
        public EventFilter Filter { get; set; }

        public EventListQuery(IUnitOfWorkProvider provider) : base(provider) { }

        protected override IQueryable<EventDTO> GetQueryable()
        {
            IQueryable<Event> query = Context.Events
                                             .Include(nameof(Event.Address))
                                             .Include(nameof(Event.EventOrganizer));
            
            if (!string.IsNullOrEmpty(Filter.Lecturer))
            {
                query = query.Where(w => w.Lecturer.ToLower().Contains(Filter.Lecturer.ToLower()));
            }
            
            if (!Filter.Date.Equals(new DateTime()))
            {
                query = query.Where(w => w.Date == Filter.Date);
            }

            if (Filter.MinimumCapacity > 0)
            {
                query = query.Where(w => w.Capacity >= Filter.MinimumCapacity);
            }

            if (Filter.MaximumFee > 0)
            {
                query = query.Where(w => w.Fee <= Filter.MaximumFee);
            }

            if (Filter.AddressId > 0)
            {
                query = query.Where(w => w.Address.ID == Filter.AddressId);
            }

            if (Filter.OrganizerId > 0)
            {
                query = query.Where(w => w.EventOrganizer.User.ID == Filter.OrganizerId);
            }

            return query.ProjectTo<EventDTO>();
        }
    }
}
