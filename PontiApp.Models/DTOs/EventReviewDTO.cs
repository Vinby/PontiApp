﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class EventReviewDTO : IdDTO
    {
        public float ReviewRanking { get; set; }
        public int UserEntityId { get; set; }
        public int EventEntityId { get; set; }
    }
}
