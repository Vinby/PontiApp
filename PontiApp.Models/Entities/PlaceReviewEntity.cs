﻿using PontiApp.Models.Entities.Interfaces;

namespace PontiApp.Models.Entities
{
    public class PlaceReviewEntity : BaseEntity, IReviewEntity
    {
        public float ReviewRanking { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int PlaceEntityId { get; set; }
        public PlaceEntity PlaceEntity { get; set; }
    }
}
