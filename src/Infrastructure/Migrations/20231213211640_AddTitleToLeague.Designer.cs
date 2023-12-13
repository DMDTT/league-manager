﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(LeagueManagerContext))]
    [Migration("20231213211640_AddTitleToLeague")]
    partial class AddTitleToLeague
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Application.Entities.GameDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("GameDays");
                });

            modelBuilder.Entity("Application.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Application.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AwayId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameDayId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoalsAway")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GoalsHome")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HomeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AwayId");

                    b.HasIndex("GameDayId");

                    b.HasIndex("HomeId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Application.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Application.Entities.GameDay", b =>
                {
                    b.HasOne("Application.Entities.League", "League")
                        .WithMany("GameDays")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");
                });

            modelBuilder.Entity("Application.Entities.Match", b =>
                {
                    b.HasOne("Application.Entities.Team", "Away")
                        .WithMany()
                        .HasForeignKey("AwayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Entities.GameDay", "GameDay")
                        .WithMany("Matches")
                        .HasForeignKey("GameDayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Application.Entities.Team", "Home")
                        .WithMany()
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Away");

                    b.Navigation("GameDay");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("Application.Entities.Team", b =>
                {
                    b.HasOne("Application.Entities.League", null)
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId");
                });

            modelBuilder.Entity("Application.Entities.GameDay", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Application.Entities.League", b =>
                {
                    b.Navigation("GameDays");

                    b.Navigation("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
