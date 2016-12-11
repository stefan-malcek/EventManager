using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs.Events;
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

            if (!string.IsNullOrEmpty(Filter.Title))
            {
                query = query.Where(w => w.Title.ToLower().Contains(Filter.Title.ToLower()));
            }

            if (Filter.IsNotFull)
            {
                query = query.Where(w => !w.Capacity.HasValue || w.Capacity < w.Registrations.Count);
            }

            if (Filter.IsFree)
            {
                query = query.Where(w => w.Fee == 0);
            }

            if (Filter.AddressId > 0)
            {
                query = query.Where(w => w.Address.ID == Filter.AddressId);
            }

            if (Filter.UserId > 0)
            {
                query = query.Where(w => w.EventOrganizer.User.ID == Filter.UserId);
            }

            if (Filter.OnlyActual)
            {
                query = query.Where(w => w.Date >= DateTime.Today);
            }

            if (Filter.Rating > 0)
            {
                query = query.Where(w => w.EventReviews.Average(a => a.Rating) >= Filter.Rating);
            }

            return query.ProjectTo<EventDTO>();
        }
    }
}
