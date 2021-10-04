﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class EventReviewEntity
    {
        public int EventReviewEntityId { get; set; }
        public float ReviewRanking { get; set; }

        public int UserEntityId { get; set; }
        public int EventEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
        public EventEntity EventEntity { get; set; }
    }
}
