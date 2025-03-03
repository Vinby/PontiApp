﻿using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.PontiRepository.EventRepository
{
    public class EventRepository : BaseRepository<EventEntity>
    {
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public async Task InsertGuesting(EventGuestRequestDTO currEventGuestDTO)
        {
            EventEntity currEvent = await GetByID(currEventGuestDTO.EventId);
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currEventGuestDTO.UserGuestId);

            UserGuestEvent guestOnEvent = new UserGuestEvent()
            {
                EventEntity = currEvent,
                UserEntity = currUser
            };

            _applicationDbContext.UserGuestEvents.Add(guestOnEvent);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGuesting(EventGuestRequestDTO currEventGuestDTO)
        {
            EventEntity currEvent = await GetByID(currEventGuestDTO.EventId);
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currEventGuestDTO.UserGuestId);

            UserGuestEvent currBond = await _applicationDbContext.UserGuestEvents.Where(o => o.EventEntityId == currEvent.Id && o.UserEntityId == currUser.Id).FirstAsync();

            _applicationDbContext.UserGuestEvents.Remove(currBond);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<EventEntity>> GetAllGuesting(int userId)
        {
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == userId);

            return await _applicationDbContext.UserGuestEvents.Where(ug => ug.UserEntityId == currUser.Id).Select(e => e.EventEntity).ToListAsync();
        }

        public async Task<List<EventEntity>> GetAllHosting(int userId)
        {
            var currUser = await _applicationDbContext.Users.Include(u => u.UserHostEvents).SingleAsync(u => u.Id == userId);

            return currUser.UserHostEvents;
        }

        public async Task UpdateGuestingEvent(EventReviewDTO eventReviewDTO)
        {
            EventEntity currEvent = await entities.Include(p => p.Reviews).SingleAsync(p => p.Id == eventReviewDTO.EventEntityId);
            EventReviewEntity currReview = new()
            {
                ReviewRanking = eventReviewDTO.ReviewRanking,
                EventEntity = currEvent,
                EventEntityId = eventReviewDTO.EventEntityId,
                UserEntityId = eventReviewDTO.UserEntityId,
                UserEntity = await _applicationDbContext.Users.SingleAsync(u => u.Id == eventReviewDTO.UserEntityId)
            };

            if (currEvent.Reviews.Contains(currReview))
            {
                currEvent.Reviews.Remove(currReview);
            }

            currEvent.Reviews.Add(currReview);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
