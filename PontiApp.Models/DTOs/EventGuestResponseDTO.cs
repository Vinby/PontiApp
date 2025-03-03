﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class EventGuestResponseDTO : PontiBaseDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? PlaceEntityId { get; set; }

        public EventReviewDTO EventReview { get; set; }

        public List<EventCategoryDTO> EventCategories { get; set; }
    }
}
