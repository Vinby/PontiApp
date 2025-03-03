﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class UserDTO : IdDTO
    {
        public string Name { get; set; }
        public string Surename { get; set; }

        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public float AverageRanking { get; set; }
        public int TotalReviewerCount { get; set; }
        public bool IsVerifiedUser { get; set; }
        public string MongoKey { get; set; }
    }
}
