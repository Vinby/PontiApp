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
    public class PlaceCategoryConfiguration : IEntityTypeConfiguration<PlaceCategory>
    {
        public void Configure(EntityTypeBuilder<PlaceCategory> builder)
        {
            builder.HasKey(o => new { o.PlaceEntityId, o.CategoryEntityId });

            builder.HasOne(o => o.placeEntity)
                    .WithMany(p => p.PlaceCategories)
                    .HasForeignKey(o => o.PlaceEntityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.categoryEntity)
                    .WithMany(c => c.PlaceCategories)
                    .HasForeignKey(o => o.CategoryEntityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
