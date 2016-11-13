﻿using System;
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

            if (Filter.UserId > 0)
            {
                query = query.Where(w => w.EventOrganizer.User.ID == Filter.UserId);
            }

            if (Filter.ListOnlyActual)
            {
                query = query.Where(w => w.Date >= DateTime.Today);
            }

            return query.ProjectTo<EventDTO>();
        }
    }
}
