﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PontiApp.Data.DbContexts;

namespace PontiApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210920143144_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PontiApp.Models.Entities.EventEntity", b =>
                {
                    b.Property<int>("EventEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TicketBuyUrl")
                        .HasColumnType("text");

                    b.HasKey("EventEntityId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventPicEntity", b =>
                {
                    b.Property<int>("EventPicEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EventEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Uri")
                        .HasColumnType("text");

                    b.HasKey("EventPicEntityId");

                    b.HasIndex("EventEntityId");

                    b.ToTable("EventPicEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventReviewEntity", b =>
                {
                    b.Property<int>("EventReviewEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EventEntityId")
                        .HasColumnType("integer");

                    b.Property<float>("ReviewRanking")
                        .HasColumnType("real");

                    b.HasKey("EventReviewEntityId");

                    b.HasIndex("EventEntityId");

                    b.ToTable("EventReviewEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceEntity", b =>
                {
                    b.Property<int>("PlaceEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("EventRef")
                        .HasColumnType("integer");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("TicketBuyUrl")
                        .HasColumnType("text");

                    b.HasKey("PlaceEntityId");

                    b.HasIndex("EventRef")
                        .IsUnique();

                    b.ToTable("PlaceEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlacePicEntity", b =>
                {
                    b.Property<int>("PlacePicEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Uri")
                        .HasColumnType("text");

                    b.HasKey("PlacePicEntityId");

                    b.HasIndex("PlaceEntityId");

                    b.ToTable("PlacePicEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceReviewEntity", b =>
                {
                    b.Property<int>("PlaceReviewEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<float>("ReviewRanking")
                        .HasColumnType("real");

                    b.HasKey("PlaceReviewEntityId");

                    b.HasIndex("PlaceEntityId");

                    b.ToTable("PlaceReviewEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.ProfilePicEntity", b =>
                {
                    b.Property<int>("ProfilePicEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Uri")
                        .HasColumnType("text");

                    b.Property<int>("UserRef")
                        .HasColumnType("integer");

                    b.HasKey("ProfilePicEntityId");

                    b.HasIndex("UserRef")
                        .IsUnique();

                    b.ToTable("ProfilePicEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<float>("AverageRanking")
                        .HasColumnType("real");

                    b.Property<bool>("IsVerifiedUser")
                        .HasColumnType("boolean");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surename")
                        .HasColumnType("text");

                    b.Property<int>("TotalReviewerCount")
                        .HasColumnType("integer");

                    b.HasKey("UserEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserGuestEventEntity", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("PlaceEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGuestEvents");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserHostEventEntity", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("PlaceEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserHostEvents");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.WeekEntity", b =>
                {
                    b.Property<int>("WeekEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("WeekEntityId");

                    b.HasIndex("PlaceEntityId");

                    b.ToTable("WeekEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventPicEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "EventEntity")
                        .WithMany("PictureUries")
                        .HasForeignKey("EventEntityId");

                    b.Navigation("EventEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventReviewEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "EventEntity")
                        .WithMany("EventReviews")
                        .HasForeignKey("EventEntityId");

                    b.Navigation("EventEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "EventEntity")
                        .WithOne("Place")
                        .HasForeignKey("PontiApp.Models.Entities.PlaceEntity", "EventRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlacePicEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "PlaceEntity")
                        .WithMany("PictureUries")
                        .HasForeignKey("PlaceEntityId");

                    b.Navigation("PlaceEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceReviewEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "PlaceEntity")
                        .WithMany("PlaceReviews")
                        .HasForeignKey("PlaceEntityId");

                    b.Navigation("PlaceEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.ProfilePicEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.UserEntity", "UserEntity")
                        .WithOne("PictureUri")
                        .HasForeignKey("PontiApp.Models.Entities.ProfilePicEntity", "UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserGuestEventEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "Event")
                        .WithMany("UserGuestEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", null)
                        .WithMany("UserGuestEvents")
                        .HasForeignKey("PlaceEntityId");

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "User")
                        .WithMany("UserGuestEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserHostEventEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "Event")
                        .WithMany("UserHostEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", null)
                        .WithMany("UserHostEvents")
                        .HasForeignKey("PlaceEntityId");

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "User")
                        .WithMany("UserHostEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.WeekEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "Place")
                        .WithMany("WeekSchedule")
                        .HasForeignKey("PlaceEntityId");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventEntity", b =>
                {
                    b.Navigation("EventReviews");

                    b.Navigation("PictureUries");

                    b.Navigation("Place");

                    b.Navigation("UserGuestEvents");

                    b.Navigation("UserHostEvents");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceEntity", b =>
                {
                    b.Navigation("PictureUries");

                    b.Navigation("PlaceReviews");

                    b.Navigation("UserGuestEvents");

                    b.Navigation("UserHostEvents");

                    b.Navigation("WeekSchedule");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("PictureUri");

                    b.Navigation("UserGuestEvents");

                    b.Navigation("UserHostEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
