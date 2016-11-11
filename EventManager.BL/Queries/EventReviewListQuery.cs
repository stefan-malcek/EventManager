using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Filters;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Queries
{
   public class EventReviewListQuery : AppQuery<EventReviewDTO>
    {
        public EventReviewFilter Filter { get; set; }

        public EventReviewListQuery(IUnitOfWorkProvider provider) : base(provider) { }

        protected override IQueryable<EventReviewDTO> GetQueryable()
        {
            IQueryable<EventReview> query = Context.EventReviews;

            if (Filter.EventId > 0)
            {
                query = query.Where(w => w.Event.ID == Filter.EventId);
            }

            return query.ProjectTo<EventReviewDTO>();
        }
    }
}
