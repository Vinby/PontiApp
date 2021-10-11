﻿using System.Collections.Generic;

namespace PontiApp.Models.Entities
{
    public class UserEntity
    {
        public int UserEntityId { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mail { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public float AverageRanking { get; set; }

        public int TotalReviewerCount { get; set; }

        public bool IsVerifiedUser { get; set; }

        public ProfilePicEntity PictureUri { get; set; }

        public ICollection<UserGuestEventEntity> UserGuestEvents { get; set; }

        public ICollection<UserHostEventEntity> UserHostEvents { get; set; }
    }
}
