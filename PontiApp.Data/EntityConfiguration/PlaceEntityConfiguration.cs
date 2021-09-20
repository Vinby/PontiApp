﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Data.EntityConfiguration
{
    public class PlaceEntityConfiguration : IEntityTypeConfiguration<PlaceEntity>
    { 

        public void Configure(EntityTypeBuilder<PlaceEntity> builder)
        {
            builder.HasMany(pl => pl.WeekSchedule)
                    .WithOne(w => w.Place);

            builder.HasMany(pl => pl.PictureUries)
                    .WithOne(pic => pic.PlaceEntity);

            builder.HasMany(pl => pl.PlaceReviews)
                    .WithOne(r => r.PlaceEntity);
        }
    }
}
