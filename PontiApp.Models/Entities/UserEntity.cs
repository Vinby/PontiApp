﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surename { get; set; }

        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public float AverageRanking { get; set; }
        public int TotalReviewerCount { get; set; }
        public bool IsVerifiedUser { get; set; }

        //For Profile pic one to one
        public string MongoKey { get; set; }

        //One to Many
        public ICollection<EventEntity> UserHostEvents { get; set; }
        public ICollection<PlaceEntity> UserHostPlaces { get; set; }

        //Many to many
        public ICollection<EventEntity> UserGuestEvents { get; set; }
        public ICollection<PlaceEntity> UserGuestPlaces { get; set; }
        


    }
}
