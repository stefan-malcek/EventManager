using System;
using System.Collections.Generic;
using AutoMapper;
using EventManager.BL.DTOs.EventReviews;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Queries;
using EventManager.BL.Repositories;
using EventManager.DAL.Entities;

namespace EventManager.BL.Services.Reviews
{
    public class ReviewService : EventManagerService, IReviewService
    {
        private readonly EventReviewRepository _eventReviewRepository;
        private readonly EventRepository _eventRepository;
        private readonly EventReviewListQuery _eventReviewListQuery;

        public ReviewService(EventReviewRepository eventReviewRepository, EventRepository eventRepository, 
            EventReviewListQuery eventReviewListQuery)
        {
            _eventReviewRepository = eventReviewRepository;
            _eventRepository = eventRepository;
            _eventReviewListQuery = eventReviewListQuery;
        }

        public void AddReview(EventReviewCreateDTO reviewDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var review = Mapper.Map<EventReview>(reviewDto);
                review.Event = GetEvent(reviewDto.EventId);
                _eventReviewRepository.Insert(review);
                uow.Commit();
            }
        }

        public void UpdateReview(EventReviewDTO reviewDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var review = _eventReviewRepository.GetById(reviewDto.Id, g => g.Event);
                Mapper.Map(reviewDto, review);
                _eventReviewRepository.Update(review);
                uow.Commit();
            }
        }

        public void DeleteReview(int reviewId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                _eventReviewRepository.Delete(reviewId);
                uow.Commit();
            }
        }

        public EventReviewDTO GetReview(int reviewId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var review = _eventReviewRepository.GetById(reviewId, i => i.Event);
                return review == null ? null : Mapper.Map<EventReviewDTO>(review);
            }
        }

        public IEnumerable<EventReviewDTO> ListReviewsForEvent(int eventId = 0)
        {
            using (UnitOfWorkProvider.Create())
            {
                _eventReviewListQuery.Filter = new EventReviewFilter { EventId = eventId };
                return _eventReviewListQuery.Execute();
            }
        }

        private Event GetEvent(int eventId)
        {
            var @event = _eventRepository.GetById(eventId);
            if (@event == null)
            {
                throw new ArgumentException("Invalid parameter value.", nameof(eventId));
            }

            return @event;
        }
    }
}
